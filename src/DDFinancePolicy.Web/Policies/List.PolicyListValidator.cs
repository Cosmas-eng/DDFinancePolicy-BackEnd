using DDFinancePolicy.Web.CustomValidators;

namespace DDFinancePolicy.Web.Policies;

public class PolicyListValidator : Validator<PolicyListRequest>
{
  public PolicyListValidator()
  {
    RuleFor(p => p.StatusFilter).StatusValues();
  }
}
