using EAgenda.WebApp.Compartilhado.Infra.Sql;
using EAgenda.WebApp.Modulos.ModuloContato.Dominio;
using EAgenda.WebApp.Modulos.ModuloContato.Infra;
using EAgenda.WebApp.Modulos.ModuloCompromisso.Dominio;
using EAgenda.WebApp.Modulos.ModuloCompromisso.Infra;
using EAgenda.WebApp.Modulos.ModuloCategoria.Dominio;
using EAgenda.WebApp.Modulos.ModuloCategoria.Infra;
using EAgenda.WebApp.Modulos.ModuloDespesa.Dominio;
using EAgenda.WebApp.Modulos.ModuloDespesa.Infra;
using EAgenda.WebApp.Compartilhado.Infra.Arquivos;

namespace EAgenda.WebApp.Compartilhado.Infra;

public static class InjecaoDependencia
{
    public static void AddInfraRepositories(this IServiceCollection services)
    {
        services.AddSingleton(provider =>
        {
            ContextoJson contextoJson = new ContextoJson();

            contextoJson.Carregar();

            return contextoJson;
        });

        services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>();

        services.AddScoped<IRepositorioContato, RepositorioContatoEmSql>();
        services.AddScoped<IRepositorioCompromisso, RepositorioCompromissoEmSql>();
        services.AddScoped<IRepositorioCategoria, RepositorioCategoriaEmArquivo>();
        services.AddScoped<IRepositorioDespesa, RepositorioDespesaEmArquivo>();
    }
}