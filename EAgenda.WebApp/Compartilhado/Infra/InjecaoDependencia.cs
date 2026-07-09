using EAgenda.WebApp.Compartilhado.Infra.Orm;
using EAgenda.WebApp.Compartilhado.Infra.Sql;
using EAgenda.WebApp.Modulos.ModuloCategoria.Dominio;
using EAgenda.WebApp.Modulos.ModuloCategoria.Infra;
using EAgenda.WebApp.Modulos.ModuloCompromisso.Dominio;
using EAgenda.WebApp.Modulos.ModuloCompromisso.Infra;
using EAgenda.WebApp.Modulos.ModuloContato.Dominio;
using EAgenda.WebApp.Modulos.ModuloContato.Infra;
using EAgenda.WebApp.Modulos.ModuloDespesa.Dominio;
using EAgenda.WebApp.Modulos.ModuloDespesa.Infra;
using EAgenda.WebApp.Modulos.ModuloTarefa.Dominio;
using EAgenda.WebApp.Modulos.ModuloTarefa.Infra;
using Microsoft.EntityFrameworkCore;

namespace EAgenda.WebApp.Compartilhado.Infra;

public static class InjecaoDependencia
{
    public static void AddInfraRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        string? valor = configuration["Infra:TipoPersistencia"];

        if (!Enum.TryParse(valor, ignoreCase: true, out TipoPersistencia tipoPersistencia))
        {
            throw new InvalidOperationException(
                $"O valor '{valor}' não é um tipo de persistência válido ou não foi encontrado no arquivo de configuração. " +
                $"Valores aceitos: {string.Join(", ", Enum.GetNames<TipoPersistencia>())}."
            );
        }

        switch (tipoPersistencia)
        {
            case TipoPersistencia.Orm:
                AddOrmRepositories(services, configuration);
                break;

            case TipoPersistencia.Dapper:
                AddDapperRepositories(services);
                break;

            default:
                throw new InvalidOperationException(
                    $"Valor inválido para Infra:TipoPersistencia: '{tipoPersistencia}'. " +
                    $"Valores aceitos: {string.Join(", ", Enum.GetNames<TipoPersistencia>())}."
                );
        }
    }

    private static void AddOrmRepositories(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<EAgendaDbContext>(options =>
        {
            string? connectionString = configuration.GetConnectionString("SqlServerEF");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException(
                    $"A connection string \"SqlServerEF\" não foi encontrada."
                );
            }

            options.UseSqlServer(connectionString, opt => 
            {
                opt.EnableRetryOnFailure(3);
            });
        });

        services.AddScoped<IRepositorioContato, RepositorioContatoEmOrm>();
        services.AddScoped<IRepositorioCompromisso, RepositorioCompromissoEmOrm>();
        services.AddScoped<IRepositorioCategoria, RepositorioCategoriaEmOrm>();
        services.AddScoped<IRepositorioDespesa, RepositorioDespesaEmOrm>();
        services.AddScoped<IRepositorioTarefa, RepositorioTarefaEmOrm>();
    }

    private static void AddDapperRepositories(IServiceCollection services)
    {
        services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>();

        services.AddScoped<IRepositorioContato, RepositorioContatoEmSql>();
        services.AddScoped<IRepositorioCompromisso, RepositorioCompromissoEmSql>();
        services.AddScoped<IRepositorioCategoria, RepositorioCategoriaEmSql>();
        services.AddScoped<IRepositorioDespesa, RepositorioDespesaEmSql>();
        services.AddScoped<IRepositorioTarefa, RepositorioTarefaEmSql>();
    }
}