using DDFinancePolicy.Core.PolicyAggregate;

namespace DDFinancePolicy.Web.Policies;

public static class MapperExtention
{
  /// <summary>
  /// Maps <see cref="Policy"/> into <see cref="DefaultPolicyResponse"/>
  /// </summary>
  /// <param name="e">Policy instance being extended</param>
  /// <returns>Retuens the mapped <see cref="DefaultPolicyResponse"/></returns>
  public static DefaultPolicyResponse MapResponse(this Policy e) =>
    new()
    {
      PolicyId = e.Id,
      PolicyName = e.PolicyName,
      PolicyHolderId = e.PolicyHolderId,
      PolicyHolder = e.PolicyHolderName,
      PhoneNumer = e.PhoneNumber!.ToString(),
      PolicyAmount = $"Ksh.{e.Premuim}",
      PolicyStatus = e.PolicyStatus.ToString(),
    };
}
