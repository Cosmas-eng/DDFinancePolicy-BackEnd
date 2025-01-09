namespace DDFinancePolicy.Web.Policies;

public class UpdatePolicyContactRequest
{
  public const string Route = "/Policies/{PolicyId:int}/Contact";
  public static string BuildRoute(int policyId) => Route.Replace("{PolicyId:int}", policyId.ToString());

  public int PolicyId { get; set; }
  /// <summary>
  /// Policy Holder's Country Code
  /// </summary>
  public required string CoutryCode { get; set; }
  /// <summary>
  /// Policy Holder's Phone number
  /// </summary>
  public required string Phone { get; set; }
  /// <summary>
  /// Policy Holder's Phone Extention
  /// </summary>
  public string? PhoneExtention { get; set; }
}
