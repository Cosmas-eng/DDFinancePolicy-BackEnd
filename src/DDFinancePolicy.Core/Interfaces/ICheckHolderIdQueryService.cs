namespace DDFinancePolicy.Core.Interfaces;
public interface ICheckHolderIdQueryService
{
  Task<bool> CheckHolderId(int policyHolderId);
}
