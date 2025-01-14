using DDFinancePolicy.Core.Interfaces;

namespace DDFinancePolicy.Web.Policies;

public class CheckPolicyHolderId(ICheckHolderIdQueryService service) : Endpoint<CheckPolicyHolderIdRequest, bool>
{
  public override void Configure()
  {
    Get(CheckPolicyHolderIdRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.Summary = "Checks policy holder Id";
      s.Description = "Returns true if the Policy Holder Id exist otherwise false";
    });
  }

  public override async Task HandleAsync(CheckPolicyHolderIdRequest req, CancellationToken ct)
  {
    var result = await service.CheckHolderId(req.PolicyHolderId);
    await SendAsync(result, cancellation: ct);
  }
}
