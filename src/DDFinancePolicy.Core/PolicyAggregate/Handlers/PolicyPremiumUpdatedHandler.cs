using DDFinancePolicy.Core.Interfaces;
using DDFinancePolicy.Core.PolicyAggregate.Events;

namespace DDFinancePolicy.Core.PolicyAggregate.Handlers;
internal class PolicyPremiumUpdatedHandler(ILogger<PolicyPremiumUpdatedHandler> logger, IEmailSender emailSender)
  : INotificationHandler<PolicyPremiumUpdatedEvent>
{
  public async Task Handle(PolicyPremiumUpdatedEvent notification, CancellationToken cancellationToken)
  {

    logger.LogInformation("Handling Policy Premium updated event for {policyId}", notification.PolicyId);

    await emailSender.SendEmailAsync("to@test.com",
                                     "from@test.com",
                                     "Policy Amount Updated",
                                     $"The Policy with id {notification.PolicyId} named {notification.PolicyName} was updated from Ksh. {notification.OldPremium} to Ksh. {notification.NewPremium}");
  }
}
