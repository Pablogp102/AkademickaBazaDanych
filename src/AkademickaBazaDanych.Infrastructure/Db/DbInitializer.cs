using AkademickaBazaDanych.Application.Core;

using Microsoft.EntityFrameworkCore;
namespace AkademickaBazaDanych.Infrastructure.Db;

public sealed class DbInitializer(AcademicDbContext dbContext) : IApplicationInitializer
{
    public async Task Initialize(CancellationToken cancellationToken = default)
        => await dbContext.Database.MigrateAsync(cancellationToken);
}


