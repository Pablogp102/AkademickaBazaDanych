using AkademickaBazaDanych.Application.Core;
using AkademickaBazaDanych.Domain.Core;
using AkademickaBazaDanych.Domain.Students;
using AkademickaBazaDanych.Infrastructure.Db;
using AkademickaBazaDanych.Infrastructure.Studnets;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System.Data;

namespace AkademickaBazaDanych.Infrastructure
{
    public static class Registry
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(AcademicDbContext.ConnectionStringName);

            services.AddDbContext<AcademicDbContext>(options =>
            {
                options.UseSqlServer(connectionString,
                    x => x.MigrationsHistoryTable("MigrationsHistory", AcademicDbContext.DefaultSchema));
            });
            services.AddScoped<IAcademicDbContext>(sp => sp.GetRequiredService<AcademicDbContext>());
            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<AcademicDbContext>());
            services.AddScoped<IDbConnection>(sp => sp.GetRequiredService<AcademicDbContext>().Database.GetDbConnection());
            services.AddScoped<IStudentRepository, StudentRepository>();

            services.AddTransient<IApplicationInitializer, DbInitializer>();

            return services;
        }
    }
}
