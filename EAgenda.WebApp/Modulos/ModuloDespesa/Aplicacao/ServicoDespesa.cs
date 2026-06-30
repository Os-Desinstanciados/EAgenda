using FluentResults;
using EAgenda.WebApp.Modulos.ModuloDespesa.Dominio;
using EAgenda.WebApp.Modulos.ModuloCategoria.Dominio;

namespace EAgenda.WebApp.Modulos.ModuloDespesa.Aplicacao;

public class ServicoDespesa
{
    private readonly IRepositorioDespesa repositorioDespesa;
    private readonly IRepositorioCategoria repositorioCategoria;

    public ServicoDespesa(
        IRepositorioDespesa repositorioDespesa,
        IRepositorioCategoria repositorioCategoria
    )
    {
        this.repositorioDespesa = repositorioDespesa;
        this.repositorioCategoria = repositorioCategoria;
    }

    public Result Cadastrar(CadastrarDespesaDto dto)
    {
        Categoria? categoriaSelecionada = repositorioCategoria.SelecionarPorId(dto.CategoriaId);

        if (categoriaSelecionada == null)
            return Falha(nameof(dto.CategoriaId), "Selecione uma categoria válida");

        Despesa novaDespesa = new Despesa(
            dto.Descricao,
            dto.DataOcorrencia,
            dto.Valor,
            dto.FormaPagamento,
            categoriaSelecionada
        );

        Result resultadoValidacao = ValidarEntidade(novaDespesa);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorioDespesa.Cadastrar(novaDespesa);

        return Result.Ok();
    }

    public Result Editar(EditarDespesaDto dto)
    {
        Despesa? despesa = repositorioDespesa.SelecionarPorId(dto.Id);

        if (despesa == null)
            return Result.Fail("Despesa não encontrada.");

        Categoria? categoriaSelecionada = repositorioCategoria.SelecionarPorId(dto.CategoriaId);

        if (categoriaSelecionada == null)
            return Falha(nameof(dto.CategoriaId), "Selecione uma categoria válida");            

        Despesa despesaAtualizada = new Despesa(
            dto.Descricao,
            dto.DataOcorrencia,
            dto.Valor,
            dto.FormaPagamento,
            categoriaSelecionada                    
        );

        Result resultadoValidacao = ValidarEntidade(despesaAtualizada);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorioDespesa.Editar(dto.Id, despesaAtualizada);

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        Despesa? despesa = repositorioDespesa.SelecionarPorId(id);

        if (despesa == null)
            return Result.Fail("Despesa não encontrada.");

        repositorioDespesa.Excluir(id);

        return Result.Ok();
    }

    public List<ListarDespesasDto> SelecionarTodos()
    {
        return repositorioDespesa
            .SelecionarTodos()
            .Select(d => new ListarDespesasDto(
                d.Id,
                d.Descricao,
                d.DataOcorrencia,
                d.Valor,
                d.FormaPagamento,
                d.Categoria.Id,
                d.Categoria.Titulo                                                     
            ))
            .ToList();
    }

    public Result<DetalhesDespesaDto> SelecionarPorId(Guid id)
    {
        Despesa? despesa = repositorioDespesa.SelecionarPorId(id);

        if (despesa == null)
            return Result.Fail("Despesa não encontrada.");

        return Result.Ok(new DetalhesDespesaDto(
            despesa.Id,
            despesa.Descricao,
            despesa.DataOcorrencia,                       
            despesa.Valor,                       
            despesa.FormaPagamento,
            despesa.Categoria.Id,
            despesa.Categoria.Titulo                       
            )
        );
    }
    
    public List<OpcaoCategoriaDto> SelecionarCategorias()
    {
        return repositorioCategoria
            .SelecionarTodos()
            .Select(c => new OpcaoCategoriaDto(c.Id, c.Titulo))
            .ToList();
    }

    private static Result ValidarEntidade(Despesa despesa)
    {
        List<string> erros = despesa.Validar();

        if (erros.Count == 0)
            return Result.Ok();

        return Result.Fail(new Error(erros.First()).WithMetadata("Campo", string.Empty));
    }

    private static Result Falha(string campo, string mensagem)
    {
        return Result.Fail(new Error(mensagem).WithMetadata("Campo", campo));
    }
}
