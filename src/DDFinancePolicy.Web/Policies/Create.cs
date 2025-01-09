using Ardalis.SharedKernel;
using DDFinancePolicy.Core.PolicyAggregate;

namespace DDFinancePolicy.Web.Policies;

public class Create(IRepository<Policy> repository) : Endpoint<CreatePolicyRequest, DefaultPolicyResponse, CreatePolicyMapper>
{
  public override void Configure()
  {
    Post(CreatePolicyRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.Summary = "Creates a new Policy";
      s.Description = "Creates a new Policy in the database assigning it a unique identification";
      s.Responses[200] = "Policy created successfully";
    });
  }

  public override async Task HandleAsync(CreatePolicyRequest req, CancellationToken ct)
  {
    var entity = Map.ToEntity(req);
    var createdPolicy = await repository.AddAsync(entity, ct);
    await SendMapped(createdPolicy, ct: ct);
  }
}
