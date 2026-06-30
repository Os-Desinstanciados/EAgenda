using System.ComponentModel.DataAnnotations;
using EAgenda.WebApp.Modulos.ModuloDespesa.Dominio;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace EAgenda.WebApp.Modulos.ModuloDespesa.Apresentacao;

public record OpcaoCategoriaViewModel(
    Guid Id,
    string Titulo
);

public record ListarDespesasViewModel(
    Guid Id,
    string Descricao,
    DateTime DataOcorrencia,
    decimal Valor,
    FormaPagamentoEnum FormaPagamento,
    Guid CategoriaId,
    string CategoriaTitulo    
);

public record CadastrarDespesaViewModel(
    [Required(ErrorMessage = "O campo \"Descrição\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo \"Descrição\" deve conter entre 2 e 100 caracteres.")]
    string Descricao,

    DateTime? DataOcorrencia,

    [Required(ErrorMessage = "O campo \"Valor\" deve ser preenchido.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O campo \"Valor\" deve ser maior que zero.")]
    [DataType(DataType.Currency)]
    decimal Valor,

    [Required(ErrorMessage = "O campo \"Forma de Pagamento\" deve ser preenchido.")]
    FormaPagamentoEnum FormaPagamento,

    [Required(ErrorMessage = "O campo \"Categoria\" deve ser preenchido.")]
    Guid CategoriaId,

    [ValidateNever]
    List<OpcaoCategoriaViewModel> Categorias
);

public record EditarDespesaViewModel(
    Guid Id,

    [Required(ErrorMessage = "O campo \"Descrição\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo \"Descrição\" deve conter entre 2 e 100 caracteres.")]
    string Descricao,

    DateTime? DataOcorrencia,

    [Required(ErrorMessage = "O campo \"Valor\" deve ser preenchido.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O campo \"Valor\" deve ser maior que zero.")]
    [DataType(DataType.Currency)]
    decimal Valor,

    [Required(ErrorMessage = "O campo \"Forma de Pagamento\" deve ser preenchido.")]
    FormaPagamentoEnum FormaPagamento,

    [Required(ErrorMessage = "O campo \"Categoria\" deve ser preenchido.")]
    Guid CategoriaId,

    [ValidateNever]
    List<OpcaoCategoriaViewModel> Categorias
);

public record ExcluirDespesaViewModel(
    Guid Id,
    string Descricao,
    DateTime DataOcorrencia,
    decimal Valor,
    FormaPagamentoEnum FormaPagamento,
    Guid CategoriaId,
    string CategoriaTitulo    
);
