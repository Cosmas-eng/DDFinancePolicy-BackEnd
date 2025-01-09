using DDFinancePolicy.Core.PolicyAggregate;

namespace DDFinancePolicy.IntegrationTests.Data;

public class EfRepositoryAdd : BaseEfRepoTestFixture
{
  [Fact]
  public async Task AddsContributorAndSetsId()
  {
    var testPolicyStatus = PolicyStatus.Active;
    var repository = GetRepository();
    var policy = new Policy("Test Policy", 485, "Test Policy Holder", 1000000, new(2022, 7, 13));
    policy.UpdatePhoneNumber("+000", "000000000", null);

    await repository.AddAsync(policy);

    var newPolicy = (await repository.ListAsync()).FirstOrDefault();

    Assert.Equal("Test Policy", newPolicy?.PolicyName);
    Assert.Equal(testPolicyStatus, newPolicy?.PolicyStatus);
    Assert.True(newPolicy?.Id > 0);
  }
}
