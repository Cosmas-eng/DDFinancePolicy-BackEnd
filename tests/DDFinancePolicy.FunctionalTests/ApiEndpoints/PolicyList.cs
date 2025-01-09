using DDFinancePolicy.Infrastructure.Data;
using DDFinancePolicy.Web.Policies;

namespace DDFinancePolicy.FunctionalTests.ApiEndpoints;

[Collection("Sequential")]
public class PolicyList(CustomWebApplicationFactory<Program> factory) : IClassFixture<CustomWebApplicationFactory<Program>>
{
  private readonly HttpClient _client = factory.CreateClient();

  [Fact]
  public async Task ReturnsPolicies()
  {
    var result = await _client.GetAndDeserializeAsync<PolicyListResponse>("/Policies");

    Assert.Equal(8, result.Policies.Count);
    Assert.Contains(result.Policies, i => i.name == SeedData.Policy1.PolicyName);
    Assert.Contains(result.Policies, i => i.name == SeedData.Policy2.PolicyName);
    Assert.Contains(result.Policies, i => i.name == SeedData.Policy3.PolicyName);
    Assert.Contains(result.Policies, i => i.name == SeedData.Policy4.PolicyName);
    Assert.Contains(result.Policies, i => i.name == SeedData.Policy5.PolicyName);
    Assert.Contains(result.Policies, i => i.name == SeedData.Policy6.PolicyName);
    Assert.Contains(result.Policies, i => i.name == SeedData.Policy7.PolicyName);
    Assert.Contains(result.Policies, i => i.name == SeedData.Policy8.PolicyName);
  }
}
