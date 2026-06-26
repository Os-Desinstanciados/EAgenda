namespace EAgenda.WebApp.Modulos.ModuloDespesa.Aplicacao;


public record ListarDespesasDto(
    Guid Id,
    string Descricao,
    DateTime DataOcorrencia,
    decimal Valor,
    string FormaPagamento   
);

public record CadastrarDespesaDto(
    string Descricao,
    DateTime DataOcorrencia,
    decimal Valor,
    string FormaPagamento          
);

public record EditarDespesaDto(
    Guid Id,
    string Descricao,
    DateTime DataOcorrencia,
    decimal Valor,
    string FormaPagamento    
);

public record DetalhesDespesaDto(
    Guid Id,
    string Descricao,
    DateTime DataOcorrencia,
    decimal Valor,
    string FormaPagamento   
);
