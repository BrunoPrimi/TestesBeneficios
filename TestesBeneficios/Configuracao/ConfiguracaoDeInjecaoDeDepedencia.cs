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
            services.AddScoped<IServicoProduto, ServicoProduto>();
            services.AddScoped<IRepositorioProduto, RepositorioProduto>();
            services.AddScoped<IServicoProdutoAbrangencia, ServicoProdutoAbrangencia>();
            services.AddScoped<IRepositorioProdutoAbrangencia, RepositorioProdutoAbrangencia>();
            services.AddScoped<IServicoProdutoFaixaEtaria, ServicoProdutoFaixaEtaria>();
            services.AddScoped<IRepositorioProdutoFaixaEtaria, RepositorioProdutoFaixaEtaria>();
            services.AddScoped<IServicoProfissao,ServicoProfisssao>();
            services.AddScoped<IRepositorioProfissao, RepositorioProfissao>();
            services.AddScoped<IServicoEntidadeDeClasse, ServicoEntidadeDeClasse>();
            services.AddScoped<IRepositorioEntidadeDeClasse, RepositorioEntidadeDeClasse>();
            services.AddScoped<IServicoSimulacao, ServicoSimulcao>();
            services.AddScoped<IRepositorioSimulacao, RepositorioSimulacao>();
            services.AddScoped<IServicoSimulacaoDistribuicaoVida, ServicoSimulacaoDistribuicaoVida>();
            services.AddScoped<IRepositorioSimulacaoDistribuicaoVida, RepositorioSimulacaoDistribuicaoVida>();
            services.AddScoped<IServicoSimulacaoAbrangencia, ServicoSimulacaoAbrangencia>();
            services.AddScoped<IRepositorioSimulacaoAbrangencia, RepositorioSimulacaoAbrangencia>();
            services.AddScoped<IServicoContratacao, ServicoContratacao>();
            services.AddScoped<IRepositorioContratacao, RepositorioContratacao>();
            return services;
        }
    }
}
