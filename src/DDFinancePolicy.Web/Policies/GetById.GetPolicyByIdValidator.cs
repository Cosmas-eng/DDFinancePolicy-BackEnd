using FluentValidation;

namespace DDFinancePolicy.Web.Policies;

public class GetPolicyByIdValidator : Validator<GetPolicyByIdRequest>
{
  public GetPolicyByIdValidator()
  {
    RuleFor(p => p.PolicyId)
      .GreaterThan(0).WithMessage("Policy database ID cannot be less than or equal to zero");
  }
}
