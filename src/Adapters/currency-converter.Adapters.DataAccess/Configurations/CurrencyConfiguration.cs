using currency_converter.Modules.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace currency_converter.Adapters.DataAccess.Configurations
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Active).IsRequired().HasColumnType("bit");
            builder.Property(c => c.InsertDate).IsRequired().HasColumnType("datetime");
            builder.Property(c => c.Code).IsRequired().HasColumnType("varchar").HasMaxLength(Currency.CODE_SIZE);
            builder.Property(c => c.Name).IsRequired().HasColumnType("varchar").HasMaxLength(Currency.NAME_MAX_SIZE);
            
            builder.HasMany(c => c.Rates).WithOne(r => r.Currency);
        }
    }
}
