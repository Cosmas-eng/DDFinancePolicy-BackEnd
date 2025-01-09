using DDFinancePolicy.Core.PolicyAggregate;

namespace DDFinancePolicy.Web.Policies;

public class UpdatePolicyStatusMapper : Mapper<UpdatePolicyStatusRequest, DefaultPolicyResponse, Policy>
{
  public override Policy UpdateEntity(UpdatePolicyStatusRequest r, Policy e)
  {
    e.UpdatePolicyStatus(PolicyStatus.FromName(r.NewStatus));
    return e;
  }

  public override DefaultPolicyResponse FromEntity(Policy e) => e.MapResponse();
}
