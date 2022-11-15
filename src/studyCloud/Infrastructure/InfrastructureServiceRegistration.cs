using Application.Abstractions.Services.ElasticSearch;
using Application.Abstractions.Services.EmailAuthenticator;
using Application.Abstractions.Services.JWT;
using Application.Abstractions.Services.OtpAuthenticator;
using Infrastructure.Pipelines.Authorization;
using Infrastructure.Pipelines.Caching;
using Infrastructure.Services.ElasticSearch;
using Infrastructure.Services.EmailAuthenticator;
using Infrastructure.Services.JWT;
using Infrastructure.Services.OtpAuthenticator.OtpNet;
using MailKit;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IEmailAuthenticatorHelper, EmailAuthenticatorHelper>();
        services.AddScoped<IOtpAuthenticatorHelper, OtpNetOtpAuthenticatorHelper>();
        services.AddScoped<ITokenHelper, JwtHelper>();
        services.AddScoped<IElasticSearch, ElasticSearchManager>();

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheRemovingBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(Pipelines.Validation.RequestValidationBehavior<,>));
        return services;
    }
}