using FluentValidation;

namespace DDFinancePolicy.Web.Policies;

public class DeletePolicyValidator : Validator<DeletePolicyRequest>
{
  public DeletePolicyValidator()
  {
    RuleFor(p => p.PolicyId)
      .GreaterThan(0).WithMessage("Policy database ID cannot be less than or equal to zero");
  }
}
