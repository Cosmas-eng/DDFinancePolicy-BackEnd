namespace DDFinancePolicy.Web.Policies;

public class PolicyListRequest
{
  public const string Route = "/Policies";

  public string? HolderSearchTerm { get; set; }
  public int? StatusFilter { get; set; }
}
