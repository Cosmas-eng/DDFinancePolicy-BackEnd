using DDFinancePolicy.Core.Interfaces;
using DDFinancePolicy.Core.PolicyAggregate.Events;

namespace DDFinancePolicy.Core.PolicyAggregate.Handlers;
public class PolicyPhoneContactUpdatedHandler(ILogger<PolicyPhoneContactUpdatedHandler> logger, IEmailSender emailSender)
  : INotificationHandler<PolicyPhoneContanctUpdatedEvent>
{
  public async Task Handle(PolicyPhoneContanctUpdatedEvent notification, CancellationToken cancellationToken)
  {
    logger.LogInformation("Handling Policy Phone Contanct updated event for {policyId}", notification.PolicyId);

    await emailSender.SendEmailAsync("to@test.com",
                                     "from@test.com",
                                     "Policy Contact Updated",
                                     $"The Policy with id {notification.PolicyId} named {notification.PolicyName} has had the phone contact updated to {notification.Phone}");
  }
}
