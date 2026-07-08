using EAgenda.WebApp.Compartilhado.Infra.Orm;
using EAgenda.WebApp.Modulos.ModuloDespesa.Dominio;
using Microsoft.EntityFrameworkCore;

namespace EAgenda.WebApp.Modulos.ModuloDespesa.Infra;

public sealed class RepositorioDespesaEmOrm(EAgendaDbContext dbContext) :
    RepositorioBaseEmOrm<Despesa>(dbContext), IRepositorioDespesa
{
    public override Despesa? SelecionarPorId(Guid idSelecionado)
    {
        Despesa? despesa = registros
            .Include(d => d.Categorias)
            .ThenInclude(c => c.Despesas)
            .SingleOrDefault(d => d.Id == idSelecionado);

        OrdenarCategorias(despesa);

        return despesa;
    }

    public override List<Despesa> SelecionarTodos()
    {
        List<Despesa> despesas = registros
            .Include(d => d.Categorias)
            .ThenInclude(c => c.Despesas)
            .OrderByDescending(d => d.DataOcorrencia)
            .ThenBy(d => d.Descricao)
            .ToList();

        foreach (Despesa despesa in despesas)
            OrdenarCategorias(despesa);

        return despesas;
    }

    public override List<Despesa> Filtrar(Func<Despesa, bool> filtro)
    {
        List<Despesa> despesas = registros
            .Include(d => d.Categorias)
            .ThenInclude(c => c.Despesas)
            .OrderByDescending(d => d.DataOcorrencia)
            .ThenBy(d => d.Descricao)
            .Where(filtro)
            .ToList();

        foreach (Despesa despesa in despesas)
            OrdenarCategorias(despesa);

        return despesas;
    }

    private static void OrdenarCategorias(Despesa? despesa)
    {
        if (despesa == null)
            return;

        despesa.Categorias = despesa.Categorias
            .OrderBy(c => c.Titulo)
            .ToList();
    }
}