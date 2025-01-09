using DDFinancePolicy.Core.Interfaces;
using DDFinancePolicy.Core.PolicyAggregate.Events;

namespace DDFinancePolicy.Core.PolicyAggregate.Handlers;
internal class PolicyDeletedHandler(ILogger<PolicyDeletedHandler> logger, IEmailSender emailSender) : INotificationHandler<PolicyDeletedEvent>
{
  public async Task Handle(PolicyDeletedEvent notification, CancellationToken cancellationToken)
  {
    logger.LogInformation("Handling Policy status updated event for {policyId}", notification.PolicyId);

    await emailSender.SendEmailAsync("to@test.com",
                                     "from@test.com",
                                     "Policy Status Updated",
                                     $"The Policy with id {notification.PolicyId} was deleted");
  }
}
