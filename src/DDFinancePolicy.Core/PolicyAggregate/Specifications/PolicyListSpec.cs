namespace DDFinancePolicy.Core.PolicyAggregate.Specifications;
public class PolicyListSpec : Specification<Policy, PolicyDto>
{
  public PolicyListSpec(string? holderSearchName, int? statusFilter)
  {
    Query.Select(p => new() { Id = p.Id, PolicyName = p.PolicyName, Holder = p.PolicyHolderName, Status = p.PolicyStatus.Value });
    if (statusFilter != null && statusFilter != 0)
    {
      var status = PolicyStatus.FromValue((int)statusFilter);
      Query.Where(p => p.PolicyStatus == status);
    }
    if (!String.IsNullOrWhiteSpace(holderSearchName))
      Query.Search(p => p.PolicyHolderName, holderSearchName);
    Query.OrderBy(p => p.PolicyHolderName);
  }
}
