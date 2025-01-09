namespace DDFinancePolicy.Core.PolicyAggregate;
public class PolicyDto
{
  public int Id { get; set; }
  public required string PolicyName { get; set; }
  public required string Holder { get; set; }
  public required int Status { get; set; }
}
