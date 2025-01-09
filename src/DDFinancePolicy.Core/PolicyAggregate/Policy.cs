using DDFinancePolicy.Core.PolicyAggregate.Events;

namespace DDFinancePolicy.Core.PolicyAggregate;
public class Policy(string policyName, int policyHolderId, string policyHolderName, decimal premuim, DateTime startDate)
  : EntityBase, IAggregateRoot
{
  public string PolicyName { get; private set; } = Guard.Against.NullOrWhiteSpace(policyName, nameof(policyName));
  public int PolicyHolderId { get; private set; } = Guard.Against.Negative(policyHolderId, nameof(policyHolderId));
  public string PolicyHolderName { get; private set; } = Guard.Against.NullOrWhiteSpace(policyHolderName, nameof(policyHolderName));
  public PhoneNumber? PhoneNumber { get; private set; }
  public decimal Premuim { get; private set; } = Guard.Against.NegativeOrZero(premuim, nameof(premuim));
  public DateTime StartDate { get; private set; } = startDate;
  public PolicyStatus PolicyStatus { get; private set; } = startDate <= DateTime.Now ? PolicyStatus.Active : PolicyStatus.Pending;

  public void UpdatePremium(decimal newPremium, DateTime effectiveDate)
  {
    var temp = Premuim;
    Premuim = Guard.Against.NegativeOrZero(newPremium, nameof(newPremium));
    var domainEvent = new PolicyPremiumUpdatedEvent(Id, PolicyName, PolicyHolderId, newPremium, temp, effectiveDate);
    RegisterDomainEvent(domainEvent);
  }

  public void UpdatePolicyStatus(PolicyStatus policyStatus)
  {
    PolicyStatus = Guard.Against.Null(policyStatus, nameof(policyStatus));
    var domainEvent = new PolicyStatusUpdatedEvent(Id, PolicyName, PolicyHolderId, policyStatus);
    RegisterDomainEvent(domainEvent);
  }

  public void UpdatePhoneNumber(string countryCode, string phoneNumber, string? phoneExt)
  {
    PhoneNumber = Guard.Against.Null(new PhoneNumber(countryCode, phoneNumber, phoneExt));
    var domainEvent = new PolicyPhoneContanctUpdatedEvent(Id, PolicyName, PolicyHolderId, PhoneNumber);
    RegisterDomainEvent(domainEvent);
  }
}


public class PhoneNumber(string countryCode, string number, string? extension) : ValueObject
{
  public string CountryCode { get; private set; } = Guard.Against.NullOrWhiteSpace(countryCode, nameof(countryCode));
  public string Number { get; private set; } = Guard.Against.NullOrWhiteSpace(number, nameof(number));
  public string? Extension { get; private set; } = extension;

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return CountryCode;
    yield return Number;
    yield return Extension ?? String.Empty;
  }

  public override string ToString()
  {
    return CountryCode + Number + (String.IsNullOrWhiteSpace(Extension) ? null : $"({Extension})");
  }
}
