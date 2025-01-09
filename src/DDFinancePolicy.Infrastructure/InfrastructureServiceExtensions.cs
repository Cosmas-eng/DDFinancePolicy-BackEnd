using DDFinancePolicy.Core.Interfaces;
using DDFinancePolicy.Core.Services;
using DDFinancePolicy.Infrastructure.Data;
using DDFinancePolicy.Infrastructure.Data.Queries;


namespace DDFinancePolicy.Infrastructure;
public static class InfrastructureServiceExtensions
{
  public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, ConfigurationManager config, ILogger logger)
  {
    string? connectionString = config.GetConnectionString("DefaultConnection");
    Guard.Against.Null(connectionString);
    services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

    services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>))
           .AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>))
           .AddScoped<IDeletePolicyService, DeletePolicyService>()
           .AddScoped<IListPoliciesQueryService, ListPoliciesQueryService>();


    logger.LogInformation("{Project} services registered", "Infrastructure");

    return services;
  }
}
