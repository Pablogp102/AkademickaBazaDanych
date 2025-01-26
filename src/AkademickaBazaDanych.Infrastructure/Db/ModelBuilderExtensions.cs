using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MoyaStation.Orchestrator.Infrastructure.Db;
public static class ModelBuilderExtensions
{
    public static void ApplyEnumToStringConversion(this ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var enumProperties = entityType.GetProperties()
                .Where(p => p.ClrType.IsEnum);

            foreach (var property in enumProperties)
            {
                var converterType = typeof(EnumToStringConverter<>).MakeGenericType(property.ClrType);
                var converter = Activator.CreateInstance(converterType) as ValueConverter;

                property.SetValueConverter(converter);
            }
        }
    }
}
