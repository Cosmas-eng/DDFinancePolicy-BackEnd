using FluentValidation;

namespace DDFinancePolicy.Web.Policies;

public class UpdatePremiumValidator : Validator<UpdatePremiumRequest>
{
  public UpdatePremiumValidator()
  {
    RuleFor(p => p.PolicyId)
      .GreaterThan(0).WithMessage("Policy database Id cannot be less than or equal to zero")
      .Must((args, policyId) => args.Id == policyId).WithMessage("Rout and body IDs must match");
    RuleFor(p => p.NewPolicyValue)
      .NotNull().WithMessage("Policy value to update is required")
      .GreaterThan(0).WithMessage("Policy value cannot be less than or equal to zero");
    RuleFor(p => p.EffectiveDate)
      .NotNull().WithMessage("New policy effective date is requied")
      .Must(d => d > DateTime.Now).WithMessage("New policy effective date cannot be in the past");
  }
}
