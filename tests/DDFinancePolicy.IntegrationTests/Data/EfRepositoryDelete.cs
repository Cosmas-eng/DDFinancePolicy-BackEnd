using DDFinancePolicy.Core.PolicyAggregate;

namespace DDFinancePolicy.IntegrationTests.Data;

public class EfRepositoryDelete : BaseEfRepoTestFixture
{
  [Fact]
  public async Task DeletesItemAfterAddingIt()
  {
    // add a Contributor
    var repository = GetRepository();
    var initialName = Guid.NewGuid().ToString();
    var policy = new Policy(initialName, 485, "Test Policy Holder Two", 100000, new(2023, 5, 39));
    policy.UpdatePhoneNumber("+111", "222222222", null);
    await repository.AddAsync(policy);

    // delete the item
    await repository.DeleteAsync(policy);

    // verify it's no longer there
    Assert.DoesNotContain(await repository.ListAsync(), Policy => Policy.PolicyName == initialName);
  }
}
