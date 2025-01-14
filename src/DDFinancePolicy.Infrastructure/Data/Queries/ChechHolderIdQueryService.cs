using DDFinancePolicy.Core.Interfaces;
using Microsoft.Data.SqlClient;

namespace DDFinancePolicy.Infrastructure.Data.Queries;
public class ChechHolderIdQueryService(AppDbContext db) : ICheckHolderIdQueryService
{
    private readonly AppDbContext _db = db;

  public async Task<bool> CheckHolderId(int policyHolderId)
  {
    var sql = @"
            SELECT 
                CASE WHEN EXISTS (
                    SELECT 1 
                    FROM Policies 
                    WHERE PolicyHolderId = @PolicyHolderId
                ) THEN 1 ELSE 0 END;
            ";

    var policyHolderExists = await Task.FromResult( _db.Database.SqlQueryRaw<int>(
        sql,
        new SqlParameter("@PolicyHolderId", policyHolderId)
    ).AsEnumerable().FirstOrDefault());

    return policyHolderExists == 0;
  }
}
