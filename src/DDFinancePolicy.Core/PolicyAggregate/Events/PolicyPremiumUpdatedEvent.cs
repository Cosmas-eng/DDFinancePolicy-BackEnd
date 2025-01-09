namespace DDFinancePolicy.Core.PolicyAggregate.Events;

/// <summary>
/// Domain event dispatched whenever the policy amount is updated
/// </summary>
/// <param name="policyId">Database policy ID</param>
/// <param name="policyName">Policy name</param>
/// <param name="policyHolderId">Policy holder database Id</param>
/// <param name="newPremium">The new premium amount</param>
/// <param name="oldPremium">Old premium amount</param>
/// <param name="effectiveDate">Date the new premium takes effect</param>
public sealed class PolicyPremiumUpdatedEvent(int policyId, string policyName, int policyHolderId,
  decimal newPremium, decimal oldPremium, DateTime effectiveDate) : DomainEventBase
{ 
  public int PolicyId { get; init; } = policyId;
  public string PolicyName { get; init; } = Guard.Against.NullOrWhiteSpace(policyName, nameof(policyName));
  public int PolicyHolderId { get; init; } = policyHolderId;
  public decimal NewPremium { get; init; } = newPremium;
  public decimal OldPremium { get; init; } = oldPremium;
  public DateTime effectiveDate { get; init; } = effectiveDate;
}
