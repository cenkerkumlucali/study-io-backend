using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using Amazon.S3;
using Application;
using Application.Exceptions;
using Infrastructure;
using Infrastructure.Services.Storage.AWS;
using Infrastructure.Services.Storage.Local;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Persistence;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    policy.WithOrigins("http://localhost:4200", "https://localhost:4200/")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
));
builder.Services.AddDefaultAWSOptions(builder.Configuration.GetAWSOptions());
builder.Services.AddAWSService<IAmazonS3>();
builder.Services.AddStorage<AwsStorage>();

builder.Services.AddControllersWithViews()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("Admin", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience =
                true, //Oluşturulacak token değerinin kimlerin/hangi originlerin/sitelerin kullanacığını belirlediğimiz değerdir.
            ValidateIssuer = true, //Oluşturulacak token değerinin kimin dağıttığını ifade edeceğimiz alandır.
            ValidateLifetime = true, //Oluşturulan token değerinin süresini kontrol edicek olan doğrulamadır.
            ValidateIssuerSigningKey =
                true, //Üretilecek token değerinin uygulamamıza ait bir değer olduğunu ifade eden security key verisinin doğrulanmasıdır.

            ValidAudience = builder.Configuration["Token:Audience"],
            ValidIssuer = builder.Configuration["Token:Issuer"],
            IssuerSigningKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
            LifetimeValidator = (notBefore, expires, securityToken, validationParameters) =>
                expires != null ? expires > DateTime.UtcNow : false,
            NameClaimType =
                ClaimTypes.Name //JWT üzerinde Name claimne karşılık gelen değeri User.Identity.Name propertysinden elde edebiliriz.
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
    app.ConfigureCustomExceptionMiddleware();

app.UseStaticFiles();

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
