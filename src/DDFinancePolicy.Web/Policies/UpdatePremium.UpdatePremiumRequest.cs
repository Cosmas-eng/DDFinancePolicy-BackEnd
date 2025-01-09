namespace DDFinancePolicy.Web.Policies;

public class UpdatePremiumRequest
{
  public const string Route = "/Policies/{PolicyId:int}/Premium";
  public static string BuildRoute(int policyId) => Route.Replace("{PolicyId:int}", policyId.ToString());

  public int PolicyId { get; set; }
  public decimal NewPolicyValue { get; set; }
  public DateTime EffectiveDate { get; set; }
}
