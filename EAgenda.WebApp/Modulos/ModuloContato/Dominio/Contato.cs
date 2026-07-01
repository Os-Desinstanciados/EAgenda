using EAgenda.WebApp.Compartilhado.Dominio;

namespace EAgenda.WebApp.Modulos.ModuloContato.Dominio;

public class Contato : EntidadeBase<Contato>
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Cargo { get; set; }
    public string Empresa { get; set; }

    public Contato()
    {
    }
    
    public Contato(
        string nome,
        string email,
        string telefone,
        string cargo,
        string empresa
    ) : this()
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Cargo = cargo;
        Empresa = empresa;
    }

    public override List<string> Validar()
    {
        List<string> erros = [];

        if (string.IsNullOrWhiteSpace(Nome))
            erros.Add("O nome é obrigatório.");

        if (Nome.Length < 3 || Nome.Length > 100)
            erros.Add("O nome deve conter entre 3 e 100 caracteres.");

        if (string.IsNullOrWhiteSpace(Email))
            erros.Add("O e-mail é obrigatório.");

        if (string.IsNullOrWhiteSpace(Telefone))
            erros.Add("O telefone é obrigatório.");

        return erros;
    }

    public override void Atualizar(Contato registroAtualizado)
    {
        Nome = registroAtualizado.Nome;
        Email = registroAtualizado.Email;
        Telefone = registroAtualizado.Telefone;
        Cargo = registroAtualizado.Cargo;
        Empresa = registroAtualizado.Empresa;
    }
}