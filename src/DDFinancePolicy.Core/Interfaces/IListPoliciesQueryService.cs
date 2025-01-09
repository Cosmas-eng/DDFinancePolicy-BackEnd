using DDFinancePolicy.Core.PolicyAggregate;

namespace DDFinancePolicy.Core.Interfaces;
public interface IListPoliciesQueryService
{
  Task<IEnumerable<PolicyDto>> ListAsyc(string? holderSearch, int? statusFilter);
}
