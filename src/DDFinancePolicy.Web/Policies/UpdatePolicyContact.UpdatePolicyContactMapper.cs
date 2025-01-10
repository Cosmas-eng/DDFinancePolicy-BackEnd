using DDFinancePolicy.Core.PolicyAggregate;

namespace DDFinancePolicy.Web.Policies;

public class UpdatePolicyContactMaper : Mapper<UpdatePolicyContactRequest, DefaultPolicyResponse, Policy>
{
  public override Policy UpdateEntity(UpdatePolicyContactRequest r, Policy e)
  {
    e.UpdatePhoneNumber(r.CoutryCode!, r.Phone!, r.PhoneExtention);
    return e;
  }

  public override DefaultPolicyResponse FromEntity(Policy e) => e.MapResponse();
}
