using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TestesBeneficios.Domain.Entidades;
using TestesBeneficios.Infra.Data.Context;

namespace TestesBeneficios.Configuracao
{
    public static class ConfiguracaoDoIdentity
    {
        public static IServiceCollection AdicionarConfiguracaoDoIdentity(this IServiceCollection services)
        {
            services.AddIdentity<Usuario, IdentityRole>()
                    .AddEntityFrameworkStores<TesteContext>()
                    .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
            });

            return services;
        }
    }
}
