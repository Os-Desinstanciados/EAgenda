using EAgenda.WebApp.Compartilhado.Infra.Orm;
using EAgenda.WebApp.Modulos.ModuloContato.Dominio;
using Microsoft.EntityFrameworkCore;

namespace EAgenda.WebApp.Modulos.ModuloContato.Infra;

public sealed class RepositorioContatoEmOrm(EAgendaDbContext dbContext) :
    RepositorioBaseEmOrm<Contato>(dbContext), IRepositorioContato
{
    public override List<Contato> SelecionarTodos()
    {
        return registros.OrderBy(c => c.Nome).ToList();
    }

    public override List<Contato> Filtrar(Func<Contato, bool> filtro)
    {
        return registros.Where(filtro).OrderBy(c => c.Nome).ToList();
    }
}