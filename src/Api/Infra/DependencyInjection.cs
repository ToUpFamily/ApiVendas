using ToUpFamily.Api.Contracts;
using ToUpFamily.Api.Infra.Contexts;
using ToUpFamily.Api.Infra.Repositories;

namespace ToUpFamily.Api.Infra.Injections;

public static class InfraInjectionsExtensions
{
  public static IServiceCollection AddInfra(this IServiceCollection services)
  {
    services.AddDbContext<ApplicationContext>();
    services.AddTransient<IUserRepository, UserRepository>();

    return services;
  }
}