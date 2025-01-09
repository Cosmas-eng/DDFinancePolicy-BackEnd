﻿using DDFinancePolicy.Web.CustomValidators;
using FluentValidation;

namespace DDFinancePolicy.Web.Policies;

public class PolicyListValidator : Validator<PolicyListRequest>
{
  public PolicyListValidator()
  {
    RuleFor(p => p.StatusFilter)
      .PolicyStatus().WithMessage("The filter term is not valid");
  }
}
