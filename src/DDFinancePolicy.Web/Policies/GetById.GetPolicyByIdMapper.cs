using DDFinancePolicy.Core.PolicyAggregate;

namespace DDFinancePolicy.Web.Policies;

public class GetPolicyByIdMapper : Mapper<GetPolicyByIdRequest, DefaultPolicyResponse, Policy>
{
  public override DefaultPolicyResponse FromEntity(Policy e) => e.MapResponse();
}
