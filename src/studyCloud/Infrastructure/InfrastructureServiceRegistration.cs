using Amazon.S3;
using Application.Abstractions.Services.ElasticSearch;
using Application.Abstractions.Services.EmailAuthenticator;
using Application.Abstractions.Services.JWT;
using Application.Abstractions.Services.OtpAuthenticator;
using Application.Abstractions.Services.RabbitMQ;
using Application.Abstractions.Storage;
using Application.Abstractions.Storage.AWS;
using Application.Abstractions.Storage.Azure;
using Application.Abstractions.Storage.Local;
using Application.DTOs.RabbitMQ;
using Infrastructure.Pipelines.Authorization;
using Infrastructure.Pipelines.Caching;
using Infrastructure.Services.ElasticSearch;
using Infrastructure.Services.EmailAuthenticator;
using Infrastructure.Services.JWT;
using Infrastructure.Services.OtpAuthenticator.OtpNet;
using Infrastructure.Services.RabbitMQ;
using Infrastructure.Services.Storage;
using Infrastructure.Services.Storage.AWS;
using Infrastructure.Services.Storage.Azure;
using Infrastructure.Services.Storage.Local;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IStorageService, StorageService>();
        services.AddScoped<IAzureStorage, AzureStorage>();
        services.AddScoped<IAwsStorage, AwsStorage>();
        services.AddScoped<ILocalStorage, LocalStorage>();
        services.AddScoped<IEmailAuthenticatorHelper, EmailAuthenticatorHelper>();
        services.AddScoped<IOtpAuthenticatorHelper, OtpNetOtpAuthenticatorHelper>();
        services.AddScoped<ITokenHelper, JwtHelper>();
        services.AddScoped<IElasticSearch, ElasticSearchManager>();
        services.AddScoped<RabbitMQHelper>();
        services.AddTransient<IRabbitMQEmailSenderService, RabbitMQEmailSenderService>();
        
        services.AddScoped<IRabbitMQService, RabbitMQService>();
        services.AddScoped<IRabbitMQConfiguration, RabbitMQConfiguration>();
        services.AddScoped<IObjectConvertFormat, ObjectConvertFormatManager>();
        services.AddScoped<ISmtpConfiguration, SmtpConfiguration>();
        services.AddScoped<IPublisherService, PublisherManager>();

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheRemovingBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(Pipelines.Validation.RequestValidationBehavior<,>));
        
        return services;
    }
    public static IServiceCollection AddStorage<T>(this IServiceCollection services) where T : Storage, IStorage
    {
        services.AddScoped<IStorage, T>();
        return services;
    }
    
}