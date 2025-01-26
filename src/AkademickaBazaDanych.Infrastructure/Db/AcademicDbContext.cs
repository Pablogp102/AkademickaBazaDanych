using AkademickaBazaDanych.Domain.Core;
using AkademickaBazaDanych.Domain.Students;
using Microsoft.EntityFrameworkCore;

using MoyaStation.Orchestrator.Infrastructure.Db;

using System.Diagnostics;

namespace AkademickaBazaDanych.Infrastructure.Db
{
    public interface IAcademicDbContext : IUnitOfWork
    {
        public DbSet<Student> Students { get; }
    }
    public class AcademicDbContext(DbContextOptions<AcademicDbContext> options) : DbContext(options), IAcademicDbContext
    {
        public static string DefaultSchema => "AcademicDb";
        public static string ConnectionStringName => "AkademickaBazaDanych";
        public DbSet<Student> Students { get; set; }

        public async Task InTransaction(Func<Task> operation)
        {
            if (this.Database.CurrentTransaction != null)
            {
                await operation();
                return;
            }

            await using var transaction = await this.Database.BeginTransactionAsync();

            try
            {
                await operation();

                await this.SaveChangesAsync();
                await transaction.CommitAsync();
                Debug.WriteLine("Save");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error during transaction: {ex.Message}");
                await transaction.RollbackAsync();
                throw;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyEnumToStringConversion();
            modelBuilder.HasDefaultSchema(DefaultSchema);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AcademicDbContext).Assembly);
        }
    }
}
