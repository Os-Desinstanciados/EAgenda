using System.ComponentModel;

namespace EAgenda.WebApp.Modulos.ModuloDespesa.Dominio;

public enum FormaPagamento
{
    [Description("Pix")]
    Pix,

    [Description("Cartão de Crédito")]
    CartaoCredito,

    [Description("Cartão de Débito")]
    CartaoDebito,

    [Description("Dinheiro")]
    Dinheiro
}