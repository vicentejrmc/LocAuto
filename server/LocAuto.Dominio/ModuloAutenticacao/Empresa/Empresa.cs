using LocAuto.Dominio.Compartilhado;

namespace LocAuto.Dominio.ModuloAutenticacao.Empresa;

public class Empresa : EntidadeBase<Empresa>
{
    public string Nome { get; set; }
    public string Cnpj { get; set; }
    public string Email { get; set; }
    public string SenhaHash { get; set; }
    public bool Ativa { get; set; }
    public DateTime DataCadastro { get; private set; }

    public Empresa(string nome, string cnpj, string email, string senhahash)
    {
        Nome = nome;
        Cnpj = cnpj;
        Email = email;
        SenhaHash = senhahash;
        Ativa = true;
        DataCadastro = DateTime.Now;

        Validar();
    }

    public override void AtualizarRegistro(Empresa registroAtualizado)
    {
       Nome = registroAtualizado.Nome;
       Cnpj = registroAtualizado.Cnpj;
       Email = registroAtualizado.Email;
    }

    public void Validar()
    {
        if (string.IsNullOrWhiteSpace(Nome))
            throw new ArgumentException("O nome da empresa é obrigatório.");

        if (string.IsNullOrWhiteSpace(Cnpj))
            throw new ArgumentException("O CNPJ da empresa é obrigatório.");

        if (string.IsNullOrWhiteSpace(Email))
            throw new ArgumentException("O email da empresa é obrigatório.");

        if (string.IsNullOrWhiteSpace(SenhaHash))
            throw new ArgumentException("A senha da empresa é obrigatória.");
    }

    public void AuterarSenha(string novaSenhaHash)
    {
        SenhaHash = novaSenhaHash;
    }
}
