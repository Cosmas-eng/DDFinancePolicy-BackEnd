namespace DDFinancePolicy.Core.Interfaces;
public interface IDeletePolicyService
{
  public Task<Result> DeletePolicyAsync(int policyId);
}
