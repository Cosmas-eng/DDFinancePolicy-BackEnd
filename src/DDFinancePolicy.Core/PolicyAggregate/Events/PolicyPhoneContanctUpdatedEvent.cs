namespace DDFinancePolicy.Core.PolicyAggregate.Events;
/// <summary>
/// Domain event dispatched whenever the policy owners pnone contact is updated
/// </summary>
/// <param name="policyId">Policy Databate ID</param>
/// <param name="policyName">Policy Name</param>
/// <param name="policyHolderId">Policy holder database Id</param>
/// <param name="phone">Policy holder's new phone contact</param>
public class PolicyPhoneContanctUpdatedEvent(int policyId, string policyName, int policyHolderId, PhoneNumber phone) : DomainEventBase
{
  public int PolicyId { get; init; } = policyId;
  public string PolicyName { get; init; } = Guard.Against.NullOrWhiteSpace(policyName, nameof(policyName));
  public int PolicyHolderId { get; init; } = policyHolderId;
  public PhoneNumber Phone { get; init; } = Guard.Against.Null(phone, nameof(phone));
}
