using FluentResults;
using EAgenda.WebApp.Modulos.ModuloCompromisso.Dominio;

namespace EAgenda.WebApp.Modulos.ModuloCompromisso.Aplicacao;

public class ServicoCompromisso
{
    private readonly IRepositorioCompromisso repositorioCompromisso;

    public ServicoCompromisso(IRepositorioCompromisso repositorioCompromisso)
    {
        this.repositorioCompromisso = repositorioCompromisso;
    }

    public Result Cadastrar(CadastrarCompromissoDto dto)
    {
        Compromisso novoCompromisso = new(
            dto.Assunto,
            dto.DataOcorrencia,
            dto.HoraInicio,
            dto.HoraTermino,
            dto.TipoCompromisso,
            dto.Local,
            dto.Link,
            dto.ContatoId
        );

        Result resultadoValidacao = ValidarEntidade(novoCompromisso);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorioCompromisso.Cadastrar(novoCompromisso);

        return Result.Ok();
    }

    public Result Editar(EditarCompromissoDto dto)
    {
        Compromisso compromissoAtualizado = new(
            dto.Assunto,
            dto.DataOcorrencia,
            dto.HoraInicio,
            dto.HoraTermino,
            dto.TipoCompromisso,
            dto.Local,
            dto.Link,
            dto.ContatoId
        );

        Result resultadoValidacao = ValidarEntidade(compromissoAtualizado);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        bool conseguiuEditar = repositorioCompromisso.Editar(dto.Id, compromissoAtualizado);

        if (!conseguiuEditar)
            return Result.Fail("Compromisso nao encontrado.");

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        Compromisso? compromisso = repositorioCompromisso.SelecionarPorId(id);

        if (compromisso == null)
            return Result.Fail("Compromisso nao encontrado.");

        repositorioCompromisso.Excluir(id);

        return Result.Ok();
    }

    public List<ListarCompromissosDto> SelecionarTodos()
    {
        return repositorioCompromisso
            .SelecionarTodos()
            .Select(c => new ListarCompromissosDto(
                c.Id,
                c.Assunto,
                c.DataOcorrencia,
                c.HoraInicio,
                c.HoraTermino,
                c.TipoCompromisso,
                c.Local,
                c.Link,
                c.ContatoId
            ))
            .ToList();
    }

    public Result<DetalhesCompromissoDto> SelecionarPorId(Guid id)
    {
        Compromisso? compromisso = repositorioCompromisso.SelecionarPorId(id);

        if (compromisso == null)
            return Result.Fail("Compromisso nao encontrado.");

        return Result.Ok(new DetalhesCompromissoDto(
            compromisso.Id,
            compromisso.Assunto,
            compromisso.DataOcorrencia,
            compromisso.HoraInicio,
            compromisso.HoraTermino,
            compromisso.TipoCompromisso,
            compromisso.Local,
            compromisso.Link,
            compromisso.ContatoId
        ));
    }

    private static Result ValidarEntidade(Compromisso compromisso)
    {
        List<string> erros = compromisso.Validar();

        if (erros.Count == 0)
            return Result.Ok();

        return Result.Fail(new Error(erros.First()).WithMetadata("Campo", string.Empty));
    }
}