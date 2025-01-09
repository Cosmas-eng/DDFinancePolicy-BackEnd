using DDFinancePolicy.Core.PolicyAggregate;
using DDFinancePolicy.Core.Services;

namespace DDFinancePolicy.UnitTests.Core.Services;
public class DeletePolicyService_DeletePolicy
{
  private readonly IRepository<Policy> _repository = Substitute.For<IRepository<Policy>>();
  private readonly IMediator _mediator = Substitute.For<IMediator>();
  private readonly ILogger<DeletePolicyService> _logger = Substitute.For<ILogger<DeletePolicyService>>();

  private readonly DeletePolicyService _service;

  public DeletePolicyService_DeletePolicy()
  {
    _service = new DeletePolicyService(_repository, _mediator, _logger);
  }

  [Fact]
  public async Task ReturnsNotFoundGivenCantFindContributor()
  {
    var result = await _service.DeletePolicyAsync(0);

    Assert.Equal(Ardalis.Result.ResultStatus.NotFound, result.Status);
  }
}
