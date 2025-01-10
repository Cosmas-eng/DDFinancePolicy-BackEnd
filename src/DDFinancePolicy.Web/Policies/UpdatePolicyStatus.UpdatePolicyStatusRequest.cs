using System.ComponentModel.DataAnnotations;

namespace DDFinancePolicy.Web.Policies;

public class UpdatePolicyStatusRequest
{
  public const string Route = "/Policies/{PolicyId:int}/Status";
  public static string BuildRoute(int policyId) => Route.Replace("{PolicyId:int}", policyId.ToString());

  public int PolicyId { get; set; }
  /// <summary>
  /// Database Id of the policy being updated
  /// </summary>
  [Required]
  public int Id { get; set; }
  /// <summary>
  /// New status to set the policy to
  /// </summary>
  [Required]
  public string? NewStatus { get; set; }
}
