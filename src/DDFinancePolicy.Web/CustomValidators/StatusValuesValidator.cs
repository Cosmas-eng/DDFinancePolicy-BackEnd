using FluentValidation.Validators;

namespace DDFinancePolicy.Web.CustomValidators;

public class StatusValuesValidator<T, TElement> : PropertyValidator<T, TElement>
{
  private static readonly string[] _statusTypes = ["1", "2", "3", "4"];
  public override string Name => "StatusValuesValidator";

  public override bool IsValid(FluentValidation.ValidationContext<T> context, TElement value)
  {
    if (value != null && !_statusTypes.Contains(value.ToString()))
    {
      context.MessageFormatter.AppendArgument("StatusType", value.ToString());
      return false;
    }
    return true;
  }

  protected override string GetDefaultMessageTemplate(string errorCode) => "{StatusType} is not a supported {PropertyName}";
}
