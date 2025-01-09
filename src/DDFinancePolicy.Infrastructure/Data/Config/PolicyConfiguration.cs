using DDFinancePolicy.Core.PolicyAggregate;

namespace DDFinancePolicy.Infrastructure.Data.Config;
public class PolicyConfiguration : IEntityTypeConfiguration<Policy>
{
  public void Configure(EntityTypeBuilder<Policy> builder)
  {
    builder.Property(p => p.PolicyName)
      .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
      .IsRequired();
    builder.Property(p => p.PolicyHolderName)
      .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
      .IsRequired();
    builder.OwnsOne(p => p.PhoneNumber, x => 
    {
      x.Property(f => f.CountryCode).HasMaxLength(DataSchemaConstants.DEFAULT_COUNTRY_CODE_LENGTH).IsRequired();
      x.Property(f => f.Number).HasMaxLength(DataSchemaConstants.DEFAULT_PHONE_LENGTH).IsRequired();
      x.Property(f => f.Extension).HasMaxLength(DataSchemaConstants.DEFAULT_PHONE_EXT_LENGTH);
    });
    builder.Property(p => p.Premuim).HasPrecision(DataSchemaConstants.DEFAULT_DECIMAL_PRECISION, DataSchemaConstants.DEFAULT_DECIMAL_SCALE);
    builder.Property(p => p.PolicyStatus)
      .HasConversion(x => x.Value, x => PolicyStatus.FromValue(x));
  }
}
