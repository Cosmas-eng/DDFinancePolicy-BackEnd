namespace DDFinancePolicy.Core.PolicyAggregate;
public class PolicyStatus : SmartEnum<PolicyStatus>
{
  public static readonly PolicyStatus Active = new(nameof(Active), 1);
  public static readonly PolicyStatus Inactive = new(nameof(Inactive), 2);
  public static readonly PolicyStatus Pending = new(nameof(Pending), 3);
  public static readonly PolicyStatus Cancelled = new(nameof(Cancelled), 4);

  protected PolicyStatus(string name, int value) : base(name, value) { }
}
