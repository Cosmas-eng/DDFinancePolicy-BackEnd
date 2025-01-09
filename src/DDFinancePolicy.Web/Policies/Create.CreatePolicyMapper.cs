using DDFinancePolicy.Core.PolicyAggregate;

namespace DDFinancePolicy.Web.Policies;

public class CreatePolicyMapper : Mapper<CreatePolicyRequest, DefaultPolicyResponse, Policy>
{
  public override Policy ToEntity(CreatePolicyRequest r)
  {
    var holderName = $"{r.FirstName}" + (String.IsNullOrWhiteSpace(r.OtherNames) ? null : $" {r.OtherNames}") + $" {r.LastName}";
    var newPolicy = new Policy(r.PolicyName, r.HolderId, holderName, r.Premium, r.StartDate);
    newPolicy.UpdatePhoneNumber(r.CoutryCode, r.Phone, r.PhoneExtention);
    return newPolicy;
  }

  public override DefaultPolicyResponse FromEntity(Policy e) => e.MapResponse();
}
