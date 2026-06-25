namespace EAgenda.WebApp.Modulos.ModuloCompromisso.Aplicacao;

public record ListarCompromissosDto(
    Guid Id,
    string Assunto,
    DateTime DataOcorrencia,
    TimeSpan HoraInicio,
    TimeSpan HoraTermino,
    string TipoCompromisso,
    string? Local,
    string? Link,
    Guid? ContatoId
);

public record CadastrarCompromissoDto(
    string Assunto,
    DateTime DataOcorrencia,
    TimeSpan HoraInicio,
    TimeSpan HoraTermino,
    string TipoCompromisso,
    string? Local,
    string? Link,
    Guid? ContatoId
);

public record EditarCompromissoDto(
    Guid Id,
    string Assunto,
    DateTime DataOcorrencia,
    TimeSpan HoraInicio,
    TimeSpan HoraTermino,
    string TipoCompromisso,
    string? Local,
    string? Link,
    Guid? ContatoId
);

public record DetalhesCompromissoDto(
    Guid Id,
    string Assunto,
    DateTime DataOcorrencia,
    TimeSpan HoraInicio,
    TimeSpan HoraTermino,
    string TipoCompromisso,
    string? Local,
    string? Link,
    Guid? ContatoId
);