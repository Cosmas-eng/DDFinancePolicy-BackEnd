using DDFinancePolicy.Core.PolicyAggregate;

namespace DDFinancePolicy.Infrastructure.Data;

public static class SeedData
{
  public static readonly Policy Policy1 = new("Whole Life Insurance", 48, "Nelson Oduor Omondi", 8000, new(2025, 2, 1));
  public static readonly Policy Policy2 = new("Universal Life Insurance", 504, "Bryan Makini", 12000, new(2025, 1, 12));
  public static readonly Policy Policy3 = new("Variable Life Insurance", 81, "Chantol Eve", 5500, new(2025, 3, 12));
  public static readonly Policy Policy4 = new("Final Expense Insurance", 222, "Stephen Omollo", 2000, new(2024, 5, 17));
  public static readonly Policy Policy5 = new("Retirement Plans", 8, "Jane Abat", 3500, new(2024, 1, 28));
  public static readonly Policy Policy6 = new("Child Insurance Plan", 317, "Lidya Akiny", 7500, new(2025, 1, 18));
  public static readonly Policy Policy7 = new("Savings & Investment Plans", 21, "Evance Mukoba", 15000, new(2025, 1, 18));
  public static readonly Policy Policy8 = new("Money Back Plan", 21, "Elisha Okelo", 35000, new(2025, 1, 18));

  public static async Task InitializeAsync(AppDbContext dbContext)
  {
    if (await dbContext.Policies.AnyAsync()) return; // DB has been seeded

    await PopulateTestDataAsync(dbContext);
  }

  public static async Task PopulateTestDataAsync(AppDbContext dbContext)
  {
    IncludeContacts();
    dbContext.Policies.AddRange([Policy1, Policy2, Policy3, Policy4, Policy5, Policy6, Policy7, Policy8]);
    await dbContext.SaveChangesAsync();
  }

  private static void IncludeContacts()
  {
    Policy1.UpdatePhoneNumber("+254", "704464716", null);
    Policy2.UpdatePhoneNumber("+254", "718890334", null);
    Policy3.UpdatePhoneNumber("+254", "751995034", null);
    Policy4.UpdatePhoneNumber("+254", "789476290", null);
    Policy5.UpdatePhoneNumber("+254", "754628777", null);
    Policy6.UpdatePhoneNumber("+254", "727364389", null);
    Policy7.UpdatePhoneNumber("+254", "747829156", null);
    Policy8.UpdatePhoneNumber("+254", "723961674", null);
  }
}
