using Ardalis.SharedKernel;
using DDFinancePolicy.Core.PolicyAggregate;

namespace DDFinancePolicy.Web.Policies;

public class UpdatePremium(IRepository<Policy> repository) : Endpoint<UpdatePremiumRequest, DefaultPolicyResponse, UpdatePremiumMapper>
{
  public override void Configure()
  {
    Put(UpdatePremiumRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.Summary = "Update a policy's premium to a new value";
      s.Description = "Checks if the policy exists then updates it if found emmiting a premium updated event";
      s.Responses[200] = "Policy premium updated successfully";
      s.Responses[404] = "Policy does not exist in the database";
    });
  }

  public override async Task HandleAsync(UpdatePremiumRequest req, CancellationToken ct)
  {
    await this.SimpleUpdateAndRespondAsync(req, req.PolicyId, repository, ct);
  }
}
