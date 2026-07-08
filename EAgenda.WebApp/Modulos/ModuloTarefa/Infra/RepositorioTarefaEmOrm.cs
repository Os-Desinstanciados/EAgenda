using EAgenda.WebApp.Compartilhado.Infra.Orm;
using EAgenda.WebApp.Modulos.ModuloTarefa.Dominio;
using Microsoft.EntityFrameworkCore;

namespace EAgenda.WebApp.Modulos.ModuloTarefa.Infra;

public sealed class RepositorioTarefaEmOrm(EAgendaDbContext dbContext) :
    RepositorioBaseEmOrm<Tarefa>(dbContext), IRepositorioTarefa
{
    public override Tarefa? SelecionarPorId(Guid idSelecionado)
    {
        Tarefa? tarefa = registros
            .Include(t => t.Itens)
            .SingleOrDefault(t => t.Id == idSelecionado);

        OrdenarItens(tarefa);

        return tarefa;
    }

    public override List<Tarefa> SelecionarTodos()
    {
        List<Tarefa> tarefas = registros
            .Include(t => t.Itens)
            .OrderByDescending(t => t.Prioridade)
            .ThenByDescending(t => t.DataCriacao)
            .ThenBy(t => t.Titulo)
            .ToList();

        foreach (Tarefa tarefa in tarefas)
            OrdenarItens(tarefa);

        return tarefas;
    }

    private static void OrdenarItens(Tarefa? tarefa)
    {
        if (tarefa == null)
            return;

        tarefa.Itens = tarefa.Itens
            .OrderBy(i => i.Titulo)
            .ToList();
    }
}