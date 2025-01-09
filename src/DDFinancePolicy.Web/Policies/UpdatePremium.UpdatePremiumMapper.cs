using DDFinancePolicy.Core.PolicyAggregate;

namespace DDFinancePolicy.Web.Policies;

public class UpdatePremiumMapper : Mapper<UpdatePremiumRequest, DefaultPolicyResponse, Policy>
{
  public override Policy UpdateEntity(UpdatePremiumRequest r, Policy e)
  {
    e.UpdatePremium(r.NewPolicyValue, r.EffectiveDate);
    return e;
  }

  public override DefaultPolicyResponse FromEntity(Policy e) => e.MapResponse();
}
