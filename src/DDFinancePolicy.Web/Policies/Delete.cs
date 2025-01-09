using DDFinancePolicy.Core.Interfaces;

namespace DDFinancePolicy.Web.Policies;

public class Delete(IDeletePolicyService policyService) : Endpoint<DeletePolicyRequest>
{
  public override void Configure()
  {
    Delete(DeletePolicyRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.Summary = "Deletes a Policy from the database";
      s.Description = "Checks if the policy exists and then deletes i from the database emmiting a policy deleted event";
      s.Responses[204] = "Policy delete successfully";
      s.Responses[404] = "Policy with the id provided does not exist in the database";
    });
  }

  public override async Task HandleAsync(DeletePolicyRequest req, CancellationToken ct)
  {
    var result = await policyService.DeletePolicyAsync(req.PolicyId);
    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    await SendNoContentAsync(ct);
  }
}
