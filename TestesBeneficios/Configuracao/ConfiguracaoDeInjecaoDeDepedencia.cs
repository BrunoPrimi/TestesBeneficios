using Microsoft.EntityFrameworkCore;
using TestesBeneficios.Domain.Repositorios.Interfaces;
using TestesBeneficios.Domain.Servicos.Implementacoes;
using TestesBeneficios.Domain.Servicos.Interfaces;
using TestesBeneficios.Infra.Data.Context;
using TestesBeneficios.Infra.Data.Repositorios.Implementacoes;

namespace TestesBeneficios.Configuracao
{
    public static class ConfiguracaoDeInjecaoDeDepedencia
    {
        public static IServiceCollection AdicionarConfiguracaoDeInjecaoDeDepedencia(this IServiceCollection services)
        {
            services.AddScoped<IServicoEmpresa, ServicoEmpresa>();
            services.AddScoped<IRepositorioEmpresa, RepositorioEmpresa>();

            return services;
        }
    }
}
