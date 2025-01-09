namespace DDFinancePolicy.Web.Policies;

public class CreatePolicyRequest
{
  public const string Route = "/Policies";

  /// <summary>
  /// Policy name
  /// </summary>
  public required string PolicyName { get; set; }
  /// <summary>
  /// Policy Holder Database ID
  /// </summary>
  public int HolderId { get; set; }
  /// <summary>
  /// Policy Holder's First Name
  /// </summary>
  public required string FirstName { get; set; }
  /// <summary>
  /// Policy Holder's Last Name
  /// </summary>
  public required string LastName { get; set; }
  /// <summary>
  /// Policy Holder's Other Names
  /// </summary>
  public string? OtherNames { get; set; }
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
  /// <summary>
  /// The Policy premium
  /// </summary>
  public decimal Premium { get; set; }
  /// <summary>
  /// Policy Start Date
  /// </summary>
  public DateTime StartDate { get; set; }
}
