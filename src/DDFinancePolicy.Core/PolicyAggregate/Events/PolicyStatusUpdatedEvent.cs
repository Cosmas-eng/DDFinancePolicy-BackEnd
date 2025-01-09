namespace DDFinancePolicy.Core.PolicyAggregate.Events;

/// <summary>
/// Domain event dispatched whenever the policy status is updated
/// </summary>
/// <param name="policyId">Policy database Id</param>
/// <param name="policyName">Policy name</param>
/// <param name="policyHolderId">Policy holder database Id</param>
/// <param name="policyStatus">New policy status</param>
public class PolicyStatusUpdatedEvent(int policyId, string policyName, int policyHolderId, PolicyStatus policyStatus) : DomainEventBase
{
  public int PolicyId { get; init; } = policyId;
  public string PolicyName { get; init; } = Guard.Against.NullOrWhiteSpace(policyName, nameof(policyName));
  public int PolicyHolderId { get; init; } = policyHolderId;
  public PolicyStatus PolicyStatus { get; init; } = Guard.Against.Null(policyStatus, nameof(policyStatus));
}
