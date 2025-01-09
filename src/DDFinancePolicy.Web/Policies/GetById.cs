using Ardalis.SharedKernel;
using DDFinancePolicy.Core.PolicyAggregate;
using DDFinancePolicy.Core.PolicyAggregate.Specifications;

namespace DDFinancePolicy.Web.Policies;

public class GetById(IReadRepository<Policy> repository) : Endpoint<GetPolicyByIdRequest, DefaultPolicyResponse, GetPolicyByIdMapper>
{
  public override void Configure()
  {
    Get(GetPolicyByIdRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.Summary = "Get a policy by Id";
      s.Description = "Checks if the policy exists then returns it if found otherwise responds with NotFound";
      s.Responses[200] = "Policy returned successfully";
      s.Responses[404] = "Policy does not exist in the database";
    });
  }

  public override async Task HandleAsync(GetPolicyByIdRequest req, CancellationToken ct)
  {
    var spec = new PolicyByIdSpec(req.PolicyId);
    var policy = await repository.FirstOrDefaultAsync(spec, ct);
    if (policy == null)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    await SendMapped(policy, ct: ct);
  }
}
