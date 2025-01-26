using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using AkademickaBazaDanych.Application.Students.Services;
using System.Reflection;
using AkademickaBazaDanych.Application.Core;

namespace AkademickaBazaDanych.Application
{
    public static class Registry
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IIdGenerator, IdGenerator>();
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            return services;
        }
    }
}
