﻿using FluentValidation;

namespace DDFinancePolicy.Web.CustomValidators;

public static class MyCustomValidators
{
  public static IRuleBuilderOptions<T, TElement> PolicyStatus<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder) =>
            ruleBuilder.SetValidator(new PolicyStatusValidator<T, TElement>());
}