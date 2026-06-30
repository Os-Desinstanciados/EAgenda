using EAgenda.WebApp.Compartilhado.Dominio;

using EAgenda.WebApp.Modulos.ModuloDespesa.Dominio;


namespace EAgenda.WebApp.Modulos.ModuloCategoria.Dominio;

public class Categoria : EntidadeBase<Categoria>
{
    public string Titulo { get; set; } = string.Empty;    
    public Despesa Despesa { get; set; } = null!;    

    public Categoria()
    {
    }

    public Categoria(string titulo) : this()
    {
        Titulo = titulo;       
    }
    

    public override List<string> Validar()
    {
        List<string> erros = [];

        if (string.IsNullOrWhiteSpace(Titulo) || Titulo.Length < 2 || Titulo.Length > 100)
            erros.Add("O campo \"Titulo\" deve conter entre 2 e 100 caracteres.");
                
        return erros;
    }

    public override void Atualizar(Categoria entidadeAtualizada)
    {
        Titulo = entidadeAtualizada.Titulo;       
        Despesa = entidadeAtualizada.Despesa;
    }
}
