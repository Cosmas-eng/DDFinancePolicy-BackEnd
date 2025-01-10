using System.ComponentModel.DataAnnotations;

namespace DDFinancePolicy.Web.Policies;

public class UpdatePremiumRequest
{
  public const string Route = "/Policies/{PolicyId:int}/Premium";
  public static string BuildRoute(int policyId) => Route.Replace("{PolicyId:int}", policyId.ToString());

  public int PolicyId { get; set; }
  /// <summary>
  /// Database Id of the policy to update
  /// </summary>
  [Required]
  public int Id { get; set; }
  /// <summary>
  /// New value of the policy
  /// </summary>
  [Required]
  public decimal NewPolicyValue { get; set; }
  /// <summary>
  /// Effective date of the new policy value
  /// </summary>
  [Required]
  public DateTime EffectiveDate { get; set; }
}
