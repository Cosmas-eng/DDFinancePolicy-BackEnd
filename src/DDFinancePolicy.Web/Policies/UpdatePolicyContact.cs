
using Ardalis.SharedKernel;
using DDFinancePolicy.Core.PolicyAggregate;

namespace DDFinancePolicy.Web.Policies;

public class UpdatePolicyContact(IRepository<Policy> repository) : Endpoint<UpdatePolicyContactRequest, DefaultPolicyResponse, UpdatePolicyContactMaper>
{
  public override void Configure()
  {
    Put(UpdatePolicyContactRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.Summary = "Updates a policy holder's contact number";
      s.Description = "Checks if the policy exists then updates its holders phone number if found emmiting a contact updated event";
      s.Responses[200] = "Policy holder's contact number updated successfully";
      s.Responses[404] = "Policy does not exist in the database";
    });
  }

  public override async Task HandleAsync(UpdatePolicyContactRequest req, CancellationToken ct)
  {
    await this.SimpleUpdateAndRespondAsync(req, req.PolicyId, repository, ct);
  }
}
