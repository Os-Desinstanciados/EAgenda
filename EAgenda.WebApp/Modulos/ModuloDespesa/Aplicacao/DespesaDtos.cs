using EAgenda.WebApp.Modulos.ModuloCategoria.Dominio;
using EAgenda.WebApp.Modulos.ModuloDespesa.Dominio;

namespace EAgenda.WebApp.Modulos.ModuloDespesa.Aplicacao;


public record OpcaoCategoriaDto(
    Guid Id,
    string Titulo
);

public record ListarDespesasDto(
    Guid Id,
    string Descricao,
    DateTime DataOcorrencia,
    decimal Valor,
    FormaPagamentoEnum FormaPagamento,
    Guid CategoriaId,
    string CategoriaTitulo   
);

public record CadastrarDespesaDto(
    string Descricao,
    DateTime DataOcorrencia,
    decimal Valor,
    FormaPagamentoEnum FormaPagamento,
    Guid CategoriaId              
);

public record EditarDespesaDto(
    Guid Id,
    string Descricao,
    DateTime DataOcorrencia,
    decimal Valor,
    FormaPagamentoEnum FormaPagamento,
    Guid CategoriaId        
);

public record DetalhesDespesaDto(
    Guid Id,
    string Descricao,
    DateTime DataOcorrencia,
    decimal Valor,
    FormaPagamentoEnum FormaPagamento,
    Guid CategoriaId,
    string CategoriaTitulo   
);
