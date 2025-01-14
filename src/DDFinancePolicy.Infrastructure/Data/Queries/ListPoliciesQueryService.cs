using DDFinancePolicy.Core.Interfaces;
using DDFinancePolicy.Core.PolicyAggregate;
using Microsoft.Data.SqlClient;

namespace DDFinancePolicy.Infrastructure.Data.Queries;
public class ListPoliciesQueryService(AppDbContext _db) : IListPoliciesQueryService
{
  public async Task<IEnumerable<PolicyDto>> ListAsyc(string? holderSearch, int? statusFilter)
  {
    string sql = @"
                SELECT 
                    Id, 
                    PolicyName, 
                    PolicyHolderName AS Holder, 
                    PolicyStatus AS Status
                FROM 
                    Policies
                WHERE 
                    (@searchTerm IS NULL OR PolicyHolderName LIKE '%' + @searchTerm + '%')
                    AND (@filterEnumValue IS NULL OR PolicyStatus = @filterEnumValue)
                ORDER BY
                    PolicyHolderName ASC";

    // Assumes `filterTerm` is directly an integer from the UI matching domain the enum value
    int? filterEnumValue = statusFilter == 0 ? (int?)null : statusFilter; // Example: 0 means no filter applied

    var result = await _db.Database.SqlQueryRaw<PolicyDto>(
        sql,
        new SqlParameter("@searchTerm", holderSearch as object ?? DBNull.Value),
        new SqlParameter("@filterEnumValue", filterEnumValue as object ?? DBNull.Value)
    ).ToListAsync();

    return result;
  }
}
