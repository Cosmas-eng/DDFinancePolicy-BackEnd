using Ardalis.SharedKernel;
using DDFinancePolicy.Core.PolicyAggregate;

namespace DDFinancePolicy.Web.Policies;

public class UpdatePolicyStatus(IRepository<Policy> repository) : Endpoint<UpdatePolicyStatusRequest, DefaultPolicyResponse, UpdatePolicyStatusMapper>
{
  public override void Configure()
  {
    Put(UpdatePolicyStatusRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.Summary = "Updates a policy to a new status";
      s.Description = "Checks if the policy exists then updates its status if found emmiting a status updated event" +
      "The option status are Active, Inactive, Pending, and Canceled";
      s.Responses[200] = "Policy status updated successfully";
      s.Responses[404] = "Policy does not exist in the database";
    });
  }

  public override async Task HandleAsync(UpdatePolicyStatusRequest req, CancellationToken ct)
  {
    await this.SimpleUpdateAndRespondAsync(req, req.PolicyId, repository, ct);
  }
}
