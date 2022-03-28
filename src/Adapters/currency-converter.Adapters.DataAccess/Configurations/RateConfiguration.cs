using currency_converter.Modules.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace currency_converter.Adapters.DataAccess.Configurations
{
    public class RateConfiguration : IEntityTypeConfiguration<Rate>
    {
        public void Configure(EntityTypeBuilder<Rate> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Active).IsRequired().HasColumnType("bit");
            builder.Property(c => c.InsertDate).IsRequired().HasColumnType("datetime");
            builder.Property(c => c.Code).IsRequired().HasColumnType("varchar").HasMaxLength(Currency.CODE_SIZE);
            builder.Property(c => c.Value).IsRequired();

            builder.HasOne(r => r.Currency).WithMany(c => c.Rates).HasForeignKey(r => r.CurrencyId);
        }
    }
}
