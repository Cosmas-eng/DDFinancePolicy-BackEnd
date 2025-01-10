using System.ComponentModel.DataAnnotations;

namespace DDFinancePolicy.Web.Policies;

public class CreatePolicyRequest
{
  public const string Route = "/Policies";

  /// <summary>
  /// Policy name
  /// </summary>
  [Required]
  public string? PolicyName { get; set; }
  /// <summary>
  /// Policy Holder Database ID
  /// </summary>
  public int HolderId { get; set; }
  /// <summary>
  /// Policy Holder's First Name
  /// </summary>
  [Required]
  public string? FirstName { get; set; }
  /// <summary>
  /// Policy Holder's Last Name
  /// </summary>
  [Required]
  public string? LastName { get; set; }
  /// <summary>
  /// Policy Holder's Other Names
  /// </summary>
  public string? OtherNames { get; set; }
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
  /// <summary>
  /// The Policy premium
  /// </summary>
  public decimal Premium { get; set; }
  /// <summary>
  /// Policy Start Date
  /// </summary>
  public DateTime StartDate { get; set; }
}
