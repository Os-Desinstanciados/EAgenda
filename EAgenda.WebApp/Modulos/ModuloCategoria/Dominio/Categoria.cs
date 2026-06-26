using EAgenda.WebApp.Compartilhado.Dominio;

// using EAgenda.WebApp.ModuloDespesa.Dominio;


namespace EAgenda.WebApp.Modulos.ModuloCategoria.Dominio;

public class Categoria : EntidadeBase<Categoria>
{
    public string Titulo { get; set; } = string.Empty;    
    // public Despesa Despesa { get; set; } = null!;    

    public Categoria()
    {
    }

    public Categoria(string titulo/*, Despesa despesa*/) : this()
    {
        Titulo = titulo;        
        // Despesa = despesa;
    }
    

    public override List<string> Validar()
    {
        List<string> erros = [];

        if (string.IsNullOrWhiteSpace(Titulo) || Titulo.Length < 2 || Titulo.Length > 100)
            erros.Add("O campo \"Titulo\" deve conter entre 2 e 100 caracteres.");
        
        // if (Despesa == null)
        //     erros.Add("O campo \"Despesa\" deve ser preenchido.");

        return erros;
    }

    public override void Atualizar(Categoria entidadeAtualizada)
    {
        Titulo = entidadeAtualizada.Titulo;       
        // Despesa = entidadeAtualizada.Despesa;
    }
}
