﻿using DDFinancePolicy.Infrastructure.Data.Config;
using FluentValidation;

namespace DDFinancePolicy.Web.Policies;

public class UpdatePolicyContactValidator : Validator<UpdatePolicyContactRequest>
{
  public UpdatePolicyContactValidator()
  {
    RuleFor(p => p.PolicyId)
     .GreaterThan(0).WithMessage("Policy database Id cannot be less than or equal to zero")
     .Must((args, policyId) => args.Id == policyId).WithMessage("Route and body IDs must match");
    RuleFor(p => p.CountryCode)
      .NotEmpty().WithMessage("Policy holder country is required")
      .Length(2, DataSchemaConstants.DEFAULT_COUNTRY_CODE_LENGTH);
    RuleFor(p => p.Phone)
      .NotEmpty().WithMessage("Policy holder's phone contact is required")
      .Length(6, DataSchemaConstants.DEFAULT_PHONE_LENGTH);
    RuleFor(p => p.PhoneExtention)
      .Length(0, DataSchemaConstants.DEFAULT_PHONE_EXT_LENGTH);
  }
}
