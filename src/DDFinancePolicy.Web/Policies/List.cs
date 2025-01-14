using DDFinancePolicy.Core.Interfaces;
using DDFinancePolicy.Core.PolicyAggregate;

namespace DDFinancePolicy.Web.Policies;

public class List(IListPoliciesQueryService queryService) : Endpoint<PolicyListRequest, PolicyListResponse>
{
  public override void Configure()
  {
    Get(PolicyListRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.Summary = "Gets a list policies from the database";
      s.Description = "Returns the available list of policies from the databate after the search term and filter in the request are applied" +
      "The filter term is an enum value where Active = 1, Inactive = 2, Pending = 3, and Cancelled = 4";
      s.Responses[200] = "Policies returned successfully";
    });
  }

  public override async Task HandleAsync(PolicyListRequest req, CancellationToken ct)
  {
    var newResult = await queryService.ListAsyc(req.HolderSearchTerm, req.StatusFilter);
    if (newResult == null)
    {
      var resp = new PolicyListResponse();
      await SendAsync(resp, cancellation: ct);
      return;
    }

    var response = new PolicyListResponse()
    {
      Policies = newResult.Select(r => new PolicyRecord(r.Id, r.PolicyName, r.Holder, PolicyStatus.FromValue(r.Status).Name)).ToList()
    };
    await SendAsync(response, cancellation: ct);
  }
}
