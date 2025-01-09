namespace DDFinancePolicy.Core.PolicyAggregate.Events;

/// <summary>
/// A domain event that is dispatched whenever a policy is deleted.
/// </summary>
/// <param name="policyId">The policy database Id</param>
/// <param name="policyName">Policy Name</param>
/// <param name="policyHolderId"> Policy holder Id</param>
internal class PolicyDeletedEvent(int policyId, string policyName, int policyHolderId) : DomainEventBase
{
  public int PolicyId { get; init; } = policyId;
  public string PolicyName { get; init; } = Guard.Against.NullOrWhiteSpace(policyName, nameof(policyName));
  public int PolicyHolderId { get; init; } = policyHolderId;
}
