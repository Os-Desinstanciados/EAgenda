using EAgenda.WebApp.Compartilhado.Dominio;

namespace EAgenda.WebApp.Modulos.ModuloCompromisso.Dominio;

public class Compromisso : EntidadeBase<Compromisso>
{
    public string Assunto { get; set; }
    public DateTime DataOcorrencia { get; set; }
    public TimeSpan HoraInicio { get; set; }
    public TimeSpan HoraTermino { get; set; }
    public string TipoCompromisso { get; set; }
    public string? Local { get; set; }
    public string? Link { get; set; }
    public Guid? ContatoId { get; set; }


    public Compromisso()
    {
    }
    
    public Compromisso(
        string assunto,
        DateTime dataOcorrencia,
        TimeSpan horaInicio,
        TimeSpan horaTermino,
        string tipoCompromisso,
        string? local,
        string? link,
        Guid? contatoId
    )
    {
        Id = Guid.NewGuid();
        Assunto = assunto;
        DataOcorrencia = dataOcorrencia;
        HoraInicio = horaInicio;
        HoraTermino = horaTermino;
        TipoCompromisso = tipoCompromisso;
        Local = local;
        Link = link;
        ContatoId = contatoId;
    }

    public override List<string> Validar()
    {
        List<string> erros = new();

        if (string.IsNullOrWhiteSpace(Assunto) || Assunto.Length < 2 || Assunto.Length > 100)
            erros.Add("O assunto deve conter entre 2 e 100 caracteres.");

        if (DataOcorrencia == default)
            erros.Add("A data de ocorrência é obrigatória.");

        if (HoraInicio == default)
            erros.Add("A hora de início é obrigatória.");

        if (HoraTermino == default)
            erros.Add("A hora de término é obrigatória.");

        if (HoraTermino <= HoraInicio)
            erros.Add("A hora de término deve ser maior que a hora de início.");

        if (string.IsNullOrWhiteSpace(TipoCompromisso))
            erros.Add("O tipo de compromisso é obrigatório.");

        if (TipoCompromisso == "Presencial" && string.IsNullOrWhiteSpace(Local))
            erros.Add("O local é obrigatório para compromissos presenciais.");

        if (TipoCompromisso == "Remoto" && string.IsNullOrWhiteSpace(Link))
            erros.Add("O link é obrigatório para compromissos remotos.");

        return erros;
    }

    public override void Atualizar(Compromisso compromissoAtualizado)
    {
        Assunto = compromissoAtualizado.Assunto;
        DataOcorrencia = compromissoAtualizado.DataOcorrencia;
        HoraInicio = compromissoAtualizado.HoraInicio;
        HoraTermino = compromissoAtualizado.HoraTermino;
        TipoCompromisso = compromissoAtualizado.TipoCompromisso;
        Local = compromissoAtualizado.Local;
        Link = compromissoAtualizado.Link;
        ContatoId = compromissoAtualizado.ContatoId;
    }
}