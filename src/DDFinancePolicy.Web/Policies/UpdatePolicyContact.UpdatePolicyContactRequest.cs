using System.ComponentModel.DataAnnotations;

namespace DDFinancePolicy.Web.Policies;

public class UpdatePolicyContactRequest
{
  public const string Route = "/Policies/{PolicyId:int}/Contact";
  public static string BuildRoute(int policyId) => Route.Replace("{PolicyId:int}", policyId.ToString());

  /// <summary>
  /// Policy Id from the route
  /// </summary>
  public int PolicyId { get; set; }
  /// <summary>
  /// Database Id of the policy getting updated
  /// </summary>
  [Required]
  public int Id { get; set; }
  /// <summary>
  /// Policy Holder's Country Code
  /// </summary>
  [Required]
  public string? CoutryCode { get; set; }
  /// <summary>
  /// Policy Holder's Phone number
  /// </summary>
  [Required]
  public string? Phone { get; set; }
  /// <summary>
  /// Policy Holder's Phone Extention
  /// </summary>
  public string? PhoneExtention { get; set; }
}
