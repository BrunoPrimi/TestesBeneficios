namespace TestesBeneficios.Configuracao
{
    public static class ConfiguracaoDoCookie
    {
        public static IServiceCollection AdicionarConfiguracaoDoCookie(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Login";
                options.AccessDeniedPath = "/Login/AcessoNegado";
            });

            return services;
        }
    }
}