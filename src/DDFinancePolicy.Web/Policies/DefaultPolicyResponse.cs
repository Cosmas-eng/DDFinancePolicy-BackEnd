namespace DDFinancePolicy.Web.Policies;

public class DefaultPolicyResponse
{
  public int PolicyId { get; set; }
  public required string PolicyName { get; set; }
  public int PolicyHolderId { get; set; }
  public required string PolicyHolder { get; set; }
  public required string PhoneNumber { get; set; }
  public required string PolicyAmount { get; set; }
  public required string PolicyStatus { get; set; }
}
