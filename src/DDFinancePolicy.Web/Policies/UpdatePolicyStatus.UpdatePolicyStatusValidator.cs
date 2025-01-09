using DDFinancePolicy.Web.CustomValidators;
using FluentValidation;

namespace DDFinancePolicy.Web.Policies;

public class UpdatePolicyStatusValidator : Validator<UpdatePolicyStatusRequest>
{
  public UpdatePolicyStatusValidator()
  {
    RuleFor(p => p.PolicyId)
     .NotNull().WithMessage("Policy database id is required")
     .GreaterThan(0).WithMessage("Policy database Id cannot be less than or equal to zero")
     .Must((args, policyId) => args.PolicyId == policyId).WithMessage("Rout and body IDs must match");
    RuleFor(p => p.NewStatus)
      .NotEmpty().WithMessage("New policy status to update is required")
      .PolicyStatus();
  }
}
