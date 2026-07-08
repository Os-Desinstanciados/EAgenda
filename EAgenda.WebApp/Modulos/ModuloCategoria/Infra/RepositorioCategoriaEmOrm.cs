using EAgenda.WebApp.Compartilhado.Infra.Orm;
using EAgenda.WebApp.Modulos.ModuloCategoria.Dominio;

namespace EAgenda.WebApp.Modulos.ModuloCategoria.Infra;

public sealed class RepositorioCategoriaEmOrm(EAgendaDbContext dbContext) :
    RepositorioBaseEmOrm<Categoria>(dbContext), IRepositorioCategoria
{
}