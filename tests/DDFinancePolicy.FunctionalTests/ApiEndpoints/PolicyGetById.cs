using DDFinancePolicy.Infrastructure.Data;
using DDFinancePolicy.Web.Policies;

namespace DDFinancePolicy.FunctionalTests.ApiEndpoints;

[Collection("Sequential")]
public class PolicyGetById(CustomWebApplicationFactory<Program> factory) : IClassFixture<CustomWebApplicationFactory<Program>>
{
  private readonly HttpClient _client = factory.CreateClient();

  [Fact]
  public async Task ReturnsSeedContributorGivenId1()
  {
    var result = await _client.GetAndDeserializeAsync<DefaultPolicyResponse>(GetPolicyByIdRequest.BuildRoute(1));

    Assert.Equal(1, result.PolicyId);
    Assert.Equal(SeedData.Policy1.PolicyName, result.PolicyName);
  }

  [Fact]
  public async Task ReturnsNotFoundGivenId1000()
  {
    string route = GetPolicyByIdRequest.BuildRoute(1000);
    _ = await _client.GetAndEnsureNotFoundAsync(route);
  }
}
