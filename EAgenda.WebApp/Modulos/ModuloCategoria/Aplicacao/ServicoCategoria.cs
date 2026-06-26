using FluentResults;
using EAgenda.WebApp.Modulos.ModuloDespesa.Dominio;
using EAgenda.WebApp.Modulos.ModuloCategoria.Dominio;

namespace EAgenda.WebApp.Modulos.ModuloCategoria.Aplicacao;

public class ServicoCategoria
{
    private readonly IRepositorioCategoria repositorioCategoria;
    private readonly IRepositorioDespesa repositorioDespesa;

    public ServicoCategoria(
        IRepositorioCategoria repositorioCategoria,
        IRepositorioDespesa repositorioDespesa
    )
    {
        this.repositorioCategoria = repositorioCategoria;
        this.repositorioDespesa = repositorioDespesa;
    }

    public Result Cadastrar(CadastrarCategoriaDto dto)
    {      
        if (ExisteCategoriaComTitulo(dto.Titulo))
            return Falha(nameof(dto.Titulo), "Já existe uma categoria com este título.");

        Categoria novaCategoria = new Categoria(
            dto.Titulo
        );

        Result resultadoValidacao = ValidarEntidade(novaCategoria);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorioCategoria.Cadastrar(novaCategoria);

        return Result.Ok();
    }

    public Result Editar(EditarCategoriaDto dto)
    {        
        if (ExisteCategoriaComTitulo(dto.Titulo))
            return Falha(nameof(dto.Titulo), "Já existe uma categoria com este título.");

        Categoria categoriaAtualizada = new Categoria(
            dto.Titulo                     
        );

        Result resultadoValidacao = ValidarEntidade(categoriaAtualizada);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorioCategoria.Editar(dto.Id, categoriaAtualizada);

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        Categoria? categoria = repositorioCategoria.SelecionarPorId(id);

        if (categoria == null)
            return Result.Fail("Categoria não encontrada.");

        repositorioCategoria.Excluir(id);

        return Result.Ok();
    }

    public List<ListarCategoriasDto> SelecionarTodos()
    {
        return repositorioCategoria
            .SelecionarTodos()
            .Select(c => new ListarCategoriasDto(
                c.Id,
                c.Titulo                                                     
            ))
            .ToList();
    }

    public Result<DetalhesCategoriaDto> SelecionarPorId(Guid id)
    {
        Categoria? categoria = repositorioCategoria.SelecionarPorId(id);

        if (categoria == null)
            return Result.Fail("Categoria não encontrada.");

        return Result.Ok(new DetalhesCategoriaDto(
            categoria.Id,
            categoria.Titulo                       
        ));    }

    

    private bool ExisteCategoriaComTitulo(string titulo, Guid? idIgnorado = null)
    {
        return repositorioCategoria
            .SelecionarTodos()
            .Any(c =>
                c.Id != idIgnorado &&
                string.Equals(c.Titulo, titulo, StringComparison.OrdinalIgnoreCase)
            );
    }

    private static Result ValidarEntidade(Categoria categoria)
    {
        List<string> erros = categoria.Validar();

        if (erros.Count == 0)
            return Result.Ok();

        return Result.Fail(new Error(erros.First()).WithMetadata("Campo", string.Empty));
    }

    private static Result Falha(string campo, string mensagem)
    {
        return Result.Fail(new Error(mensagem).WithMetadata("Campo", campo));
    }
}
