using DDFinancePolicy.Infrastructure.Data.Config;
using FluentValidation;

namespace DDFinancePolicy.Web.Policies;

public class CreatePolicyValidator : Validator<CreatePolicyRequest>
{
  public CreatePolicyValidator()
  {
    RuleFor(p => p.PolicyName)
      .NotEmpty().WithMessage("Policy name is required")
      .Length(4, DataSchemaConstants.DEFAULT_NAME_LENGTH);
    RuleFor(p => p.HolderId)
      .NotNull().WithMessage("Policy holder database ID is required")
      .GreaterThan(0).WithMessage("Holder database ID cannot be less than or equal to 0");
    RuleFor(p => p.FirstName)
      .NotEmpty().WithMessage("Policy holder's first name is required")
      .Length(2, 44);
    RuleFor(p => p.LastName)
      .NotEmpty().WithMessage("Policy holder's last name is required")
      .Length(2, 44);
    RuleFor(p => p.OtherNames)
      .Length(0, 40);
    RuleFor(p => p.CountryCode)
      .NotEmpty().WithMessage("Policy holder country is required")
      .Length(2, DataSchemaConstants.DEFAULT_COUNTRY_CODE_LENGTH);
    RuleFor(p => p.Phone)
      .NotEmpty().WithMessage("Policy holder's phone contact is required")
      .Length(6, DataSchemaConstants.DEFAULT_PHONE_LENGTH);
    RuleFor(p => p.PhoneExtention)
      .Length(0, DataSchemaConstants.DEFAULT_PHONE_EXT_LENGTH);
    RuleFor(p => p.Premium)
      .NotNull().WithMessage("Premium amount is required")
      .GreaterThan(0).WithMessage("Premium amount cannot less than or equal to 0");
    RuleFor(p => p.StartDate)
      .NotNull().WithMessage("Policy start date is requies");
  }
}
