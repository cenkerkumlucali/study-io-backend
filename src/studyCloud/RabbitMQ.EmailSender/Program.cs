using Application.Abstractions.Services.RabbitMQ;
using Application.DTOs.RabbitMQ;
using Infrastructure.Services.RabbitMQ;
using RabbitMQ.EmailSender.Services;
using IMailService = RabbitMQ.EmailSender.Services.IMailService;
using MailService = RabbitMQ.EmailSender.Services.MailService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IRabbitMQService, RabbitMQService>();
builder.Services.AddScoped<IRabbitMQConfiguration, RabbitMQConfiguration>();
builder.Services.AddScoped<IObjectConvertFormat, ObjectConvertFormatManager>();
builder.Services.AddScoped<ISmtpConfiguration, SmtpConfiguration>();
builder.Services.AddScoped<IConsumerService, ConsumerManager>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMailService, MailService>();
// builder.Services.AddTransient<RabbitMQHelper>();
// builder.Services.AddHostedService<ConsumeEmailSenderMessagingService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
var serviceProvider = new ServiceCollection()
    .AddSingleton<IConfiguration>(builder.Configuration)
    .AddSingleton<IRabbitMQConfiguration, RabbitMQConfiguration>()
    .AddSingleton<IMailService, MailService>()
    .AddSingleton<IRabbitMQService, RabbitMQService>()
    .AddSingleton<IObjectConvertFormat, ObjectConvertFormatManager>()
    .AddSingleton<ISmtpConfiguration, SmtpConfiguration>()
    .AddSingleton<IConsumerService, ConsumerManager>()
    .BuildServiceProvider();
var consumerService = serviceProvider.GetService<IConsumerService>();
await consumerService.Start();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Start();


app.WaitForShutdown();

