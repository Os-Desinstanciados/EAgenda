using System.ComponentModel.DataAnnotations;

namespace EAgenda.WebApp.Modulos.ModuloDespesa.Apresentacao;

public record ListarDespesasViewModel(
    Guid Id,
    string Descricao,
    DateTime DataOcorrencia,
    decimal Valor,
    string FormaPagamento    
);

public record CadastrarDespesaViewModel(
    [Required(ErrorMessage = "O campo \"Descrição\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo \"Descrição\" deve conter entre 2 e 100 caracteres.")]
    string Descricao
);

public record EditarDespesaViewModel(
    Guid Id,

    [Required(ErrorMessage = "O campo \"Descrição\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo \"Descrição\" deve conter entre 2 e 100 caracteres.")]
    string Descricao    
);

public record ExcluirDespesaViewModel(
    Guid Id,
    string Descricao,
    DateTime DataOcorrencia,
    decimal Valor,
    string FormaPagamento    
);
