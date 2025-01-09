namespace DDFinancePolicy.Web.Policies;

public class UpdatePolicyStatusRequest
{
  public const string Route = "/Policies/{PolicyId:int}/Status";
  public static string BuildRoute(int policyId) => Route.Replace("{PolicyId:int}", policyId.ToString());

  public int PolicyId { get; set; }
  public required string NewStatus { get; set; }
}
