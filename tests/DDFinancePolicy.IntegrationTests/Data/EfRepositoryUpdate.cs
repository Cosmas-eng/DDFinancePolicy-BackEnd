using DDFinancePolicy.Core.PolicyAggregate;


namespace DDFinancePolicy.IntegrationTests.Data;

public class EfRepositoryUpdate : BaseEfRepoTestFixture
{
  [Fact]
  public async Task UpdatesItemAfterAddingIt()
  {
    // add a Contributor
    var repository = GetRepository();
    var initialName = Guid.NewGuid().ToString();
    var policy = new Policy(initialName, 485, "Test Policy Holder Two", 100000, new(2023, 5, 39));
    policy.UpdatePhoneNumber("+111", "222222222", null);
    await repository.AddAsync(policy);

    // detach the item so we get a different instance
    _dbContext.Entry(policy).State = EntityState.Detached;

    // fetch the item and update its title
    var newPolicy = (await repository.ListAsync()).FirstOrDefault(Policy => Policy.PolicyName == initialName);
    if (newPolicy == null)
    {
      Assert.NotNull(newPolicy);
      return;
    }

    Assert.NotSame(policy, newPolicy);
    decimal newPremium = 10000;
    newPolicy.UpdatePremium(newPremium, DateTime.Now);

    // Update the item
    await repository.UpdateAsync(newPolicy);

    // Fetch the updated item
    var updatedItem = (await repository.ListAsync()).FirstOrDefault(Policy => Policy.PolicyName == initialName);

    Assert.NotNull(updatedItem);
    Assert.NotEqual(policy.Premuim, updatedItem?.Premuim);
    Assert.Equal(policy.PolicyStatus, updatedItem?.PolicyStatus);
    Assert.Equal(newPolicy.Id, updatedItem?.Id);
  }
}
