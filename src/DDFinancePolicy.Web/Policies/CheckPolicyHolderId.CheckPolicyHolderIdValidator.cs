using FluentValidation;

namespace DDFinancePolicy.Web.Policies;

public class CheckPolicyHolderIdValidator : Validator<CheckPolicyHolderIdRequest>
{
  public CheckPolicyHolderIdValidator()
  {
    RuleFor(x => x.PolicyHolderId)
      .GreaterThan(0);
  }
}
