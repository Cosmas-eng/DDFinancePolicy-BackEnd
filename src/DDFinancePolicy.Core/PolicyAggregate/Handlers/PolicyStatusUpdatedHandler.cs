using DDFinancePolicy.Core.Interfaces;
using DDFinancePolicy.Core.PolicyAggregate.Events;

namespace DDFinancePolicy.Core.PolicyAggregate.Handlers;
internal class PolicyStatusUpdatedHandler(ILogger<PolicyStatusUpdatedHandler> logger, IEmailSender emailSender)
  : INotificationHandler<PolicyStatusUpdatedEvent>
{
  public async Task Handle(PolicyStatusUpdatedEvent notification, CancellationToken cancellationToken)
  {
    logger.LogInformation("Handling Policy status updated event for {policyId}", notification.PolicyId);

    await emailSender.SendEmailAsync("to@test.com",
                                     "from@test.com",
                                     "Policy Status Updated",
                                     $"The Policy with id {notification.PolicyId} named {notification.PolicyName} was updated as {notification.PolicyStatus}");
  }
}
