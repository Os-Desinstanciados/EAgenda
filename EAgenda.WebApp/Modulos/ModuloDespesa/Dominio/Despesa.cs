using EAgenda.WebApp.Compartilhado.Dominio;
using EAgenda.WebApp.Modulos.ModuloCategoria.Dominio;

namespace EAgenda.WebApp.Modulos.ModuloDespesa.Dominio;

public class Despesa : EntidadeBase<Despesa>
{
    public string Descricao { get; set; } = string.Empty;
    public DateTime DataOcorrencia { get; set; } = DateTime.Now;
    public decimal Valor { get; set; } = 0;
    public string FormaPagamento { get; set; } = string.Empty;
    public Categoria Categoria { get; set; } = null!;

    public Despesa()
    {
    }

    public Despesa(
        string descricao,
        DateTime dataOcorrencia,
        decimal valor,
        string formaPagamento,
        Categoria categoria
    ) : this()
    {
        Descricao = descricao;
        DataOcorrencia = dataOcorrencia;
        Valor = valor;
        FormaPagamento = formaPagamento;
        Categoria = categoria;
    }    

    public override List<string> Validar()
    {
        List<string> erros = [];

        if (string.IsNullOrWhiteSpace(Descricao) || Descricao.Length < 2 || Descricao.Length > 100)
            erros.Add("O campo \"Descrição\" deve conter entre 2 e 100 caracteres.");

        if (Valor < 0)
            erros.Add("O campo \"Valor\" deve conter um valor maior que 0.");

        if (string.IsNullOrWhiteSpace(FormaPagamento))
            erros.Add("O campo \"Forma de Pagamento\" deve ser preenchido.");

        if (Categoria == null)
            erros.Add("O campo \"Categoria\" deve ser preenchido.");

        return erros;
    }

    public override void Atualizar(Despesa entidadeAtualizada)
    {
        Descricao = entidadeAtualizada.Descricao;
        DataOcorrencia = entidadeAtualizada.DataOcorrencia;
        Valor = entidadeAtualizada.Valor;
        FormaPagamento = entidadeAtualizada.FormaPagamento;
        Categoria = entidadeAtualizada.Categoria;
    }
}
