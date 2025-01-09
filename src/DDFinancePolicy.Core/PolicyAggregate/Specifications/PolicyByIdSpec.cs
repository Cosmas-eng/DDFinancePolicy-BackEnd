namespace DDFinancePolicy.Core.PolicyAggregate.Specifications;
public class PolicyByIdSpec : SingleResultSpecification<Policy>
{
  public PolicyByIdSpec(int policyId)
  {
    Query.Where(policy => policy.Id == policyId);
  }
}
