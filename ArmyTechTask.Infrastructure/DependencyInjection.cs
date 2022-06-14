using ArmyTechTask.Core.Common.Interfaces;
using ArmyTechTask.Infrastructure.Data;
using ArmyTechTask.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ArmyTechTask.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>();

        // services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddTransient<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
