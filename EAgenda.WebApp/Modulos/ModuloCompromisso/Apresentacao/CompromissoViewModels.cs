using System.ComponentModel.DataAnnotations;

namespace EAgenda.WebApp.Modulos.ModuloCompromisso.Apresentacao;

public record ListarCompromissosViewModel(
    Guid Id,
    string Assunto,
    DateTime DataOcorrencia,
    TimeSpan HoraInicio,
    TimeSpan HoraTermino,
    string TipoCompromisso,
    string? Local,
    string? Link
);

public record CadastrarCompromissoViewModel(

    [Required(ErrorMessage = "O campo \"Assunto\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo \"Assunto\" deve conter entre 2 e 100 caracteres.")]
    string Assunto,

    [Required(ErrorMessage = "A data é obrigatória.")]
    DateTime DataOcorrencia,

    [Required(ErrorMessage = "A hora inicial é obrigatória.")]
    TimeSpan HoraInicio,

    [Required(ErrorMessage = "A hora final é obrigatória.")]
    TimeSpan HoraTermino,

    [Required(ErrorMessage = "Selecione o tipo do compromisso.")]
    string TipoCompromisso,

    string? Local,

    string? Link,

    Guid? ContatoId
);

public record EditarCompromissoViewModel(

    Guid Id,

    [Required(ErrorMessage = "O campo \"Assunto\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo \"Assunto\" deve conter entre 2 e 100 caracteres.")]
    string Assunto,

    [Required]
    DateTime DataOcorrencia,

    [Required]
    TimeSpan HoraInicio,

    [Required]
    TimeSpan HoraTermino,

    [Required]
    string TipoCompromisso,

    string? Local,

    string? Link,

    Guid? ContatoId
);

public record ExcluirCompromissoViewModel(
    Guid Id,
    string Assunto,
    DateTime DataOcorrencia,
    TimeSpan HoraInicio,
    TimeSpan HoraTermino
);