using EAgenda.WebApp.Modulos.ModuloCategoria.Dominio;
using EAgenda.WebApp.Modulos.ModuloCompromisso.Dominio;
using EAgenda.WebApp.Modulos.ModuloContato.Dominio;
using EAgenda.WebApp.Modulos.ModuloDespesa.Dominio;
using EAgenda.WebApp.Modulos.ModuloTarefa.Dominio;
using Microsoft.EntityFrameworkCore;

namespace EAgenda.WebApp.Compartilhado.Infra.Orm;

public sealed class EAgendaDbContext(DbContextOptions<EAgendaDbContext> options) : DbContext(options)
{
    public DbSet<Contato> Contatos => Set<Contato>();
    public DbSet<Compromisso> Compromissos => Set<Compromisso>();
    public DbSet<Categoria> Categorias => Set<Categoria>();
    public DbSet<Despesa> Despesas => Set<Despesa>();
    public DbSet<ItemTarefa> ItensTarefa => Set<ItemTarefa>();
    public DbSet<Tarefa> Tarefas => Set<Tarefa>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {            
        modelBuilder.Ignore<Categoria>();
        modelBuilder.Ignore<Despesa>();
        modelBuilder.Ignore<ItemTarefa>();
        modelBuilder.Ignore<Tarefa>();        

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EAgendaDbContext).Assembly);
        
    }
}