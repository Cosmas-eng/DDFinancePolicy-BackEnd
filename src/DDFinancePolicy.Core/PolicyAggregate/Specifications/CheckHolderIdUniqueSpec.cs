namespace DDFinancePolicy.Core.PolicyAggregate.Specifications;
public class CheckHolderIdUniqueSpec : Specification<Policy, int?>
{
  public CheckHolderIdUniqueSpec(int holderId)
  {
    Query.Select(p => p.PolicyHolderId).Where(p => p.PolicyHolderId == holderId).AsTracking();
  }
}
