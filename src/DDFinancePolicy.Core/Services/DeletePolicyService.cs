using DDFinancePolicy.Core.Interfaces;
using DDFinancePolicy.Core.PolicyAggregate;
using DDFinancePolicy.Core.PolicyAggregate.Events;

namespace DDFinancePolicy.Core.Services;
public class DeletePolicyService(IRepository<Policy> repository, IMediator mediator, ILogger<DeletePolicyService> logger)
  : IDeletePolicyService
{
  public async Task<Result> DeletePolicyAsync(int policyId)
  {
    logger.LogInformation("Deleting policy with Id {policyId}", policyId);
    Policy? policy = await repository.GetByIdAsync(policyId);
    if (policy == null) return Result.NotFound();

    var domainEvent = new PolicyDeletedEvent(policyId, policy.PolicyName, policy.PolicyHolderId);
    await repository.DeleteAsync(policy);
    await mediator.Publish(domainEvent);

    return Result.Success();
  }
}
