using Microsoft.EntityFrameworkCore;
using TestesBeneficios.Infra.Data.Context;

namespace TestesBeneficios.Configuracao
{
    public static class DbContextConfiguration
    {
        public static IServiceCollection AddDbContextConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TesteContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionStrings:SQLServerConnectionString"]);
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            return services;
        }
    }
}
