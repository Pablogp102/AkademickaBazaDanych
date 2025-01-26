using AkademickaBazaDanych.Domain.Students;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AkademickaBazaDanych.Infrastructure.Db.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public StudentConfiguration()
        {
            
        }
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students", AcademicDbContext.DefaultSchema);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(s => s.FirstName)
                .IsRequired()  
                .HasMaxLength(100);  

            builder.Property(s => s.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.PESEL)
                .IsRequired()
                .HasMaxLength(11)
                .HasConversion(
                    pesel => pesel!.Value,  
                    value => new Pesel(value)
                );
            builder.OwnsOne(s => s.IndexNumber, index =>
            {
                index.Property(s => s.Value)
                    .HasColumnName("IndexNumber")
                    .IsRequired();
            });

            builder.OwnsOne(s => s.Address, 
            address =>
            {
                address.ToJson();
                address.Property(a => a.Street).HasMaxLength(200);
                address.Property(a => a.City).HasMaxLength(100);
                address.Property(a => a.PostalCode).HasMaxLength(20);
            });

            
            builder.Property(s => s.Gender)
                .IsRequired();  

            builder.HasIndex(s => s.PESEL).IsUnique();
        }
    }
}
