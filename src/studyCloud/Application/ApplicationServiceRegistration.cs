using System.Reflection;
using Application.Features.Auths.Rules;
using Application.Features.Categories.Rules;
using Application.Features.Users.User.Rules;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddScoped<CategoryBusinessRules>();
        services.AddScoped<UserBusinessRules>();
        services.AddScoped<AuthBusinessRules>();
        
        return services;

    }
}