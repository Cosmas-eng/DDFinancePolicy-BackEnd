namespace DDFinancePolicy.Web.Policies;

public class CheckPolicyHolderIdRequest
{
  public const string Route = "/Policies/checkHolderIdunique";

  public int PolicyHolderId { get; set; }
}
