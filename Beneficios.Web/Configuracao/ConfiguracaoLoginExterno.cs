using Microsoft.AspNetCore.Identity;
using TestesBeneficios.Domain.Entidades;
using TestesBeneficios.Infra.Data.Context;

namespace Beneficios.Web.Configuracao
{
    public static class ConfiguracaoLoginExterno
    {
        public static IServiceCollection AdicionarConfiguracaoLoginExterno(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.ClientId = configuration["Authentication:Google:ClientId"];
                    options.ClientSecret = configuration["Authentication:Google:ClientSecret"];
                })
                .AddFacebook(options =>
                {
                    options.AppId = configuration["Authentication:Facebook:AppId"];
                    options.AppSecret = configuration["Authentication:Facebook:AppSecret"];
                });

            return services;
        }
    }
}
