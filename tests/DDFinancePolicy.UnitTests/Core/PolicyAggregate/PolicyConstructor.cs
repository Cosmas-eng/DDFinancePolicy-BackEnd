using DDFinancePolicy.Core.PolicyAggregate;

namespace DDFinancePolicy.UnitTests.Core.PolicyAggregate;
public class PolicyConstructor
{
  private readonly string _testName = Guid.NewGuid().ToString();
  private Policy? _testPolicy;

  private Policy CreatePolicy()
  {
    var policy = new Policy(_testName, 485, "Test Policy Holder Three", 1000, new(2026, 7, 13));
    policy.UpdatePhoneNumber("+333", "555555555", null);
    return policy;
  }

  [Fact]
  public void InitializesName()
  {
    _testPolicy = CreatePolicy();

    Assert.Equal(_testName, _testPolicy.PolicyName);
  }
}
