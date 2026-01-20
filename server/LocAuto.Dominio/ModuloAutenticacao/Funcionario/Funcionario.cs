using LocAuto.Dominio.Compartilhado;

namespace LocAuto.Dominio.ModuloAutenticacao.Funcionario;

public class Funcionario : EntidadeBase<Funcionario>
{
    public Guid EmpresaId { get; private set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string SenhaHash { get; set; }
    public decimal Salario { get; private set; }
    public DateTime DataAdmissao { get; private set; }
    public bool Ativo { get; private set; }

    public Funcionario(Guid empresaId, string nome, string email, string senhaHash, decimal salario)
    {
        EmpresaId = empresaId;
        Nome = nome;
        Email = email;
        SenhaHash = senhaHash;
        Salario = salario;
        DataAdmissao = DateTime.Now;
        Ativo = true;

        Validar();
    }

    public override void AtualizarRegistro(Funcionario registroAtualizado)
    {
        Nome = registroAtualizado.Nome;
        Email = registroAtualizado.Email;
        Salario = registroAtualizado.Salario;
    }

    public void Validar()
    {
        if (string.IsNullOrWhiteSpace(Nome))
            throw new ArgumentException("O nome do funcionário é obrigatório.");

        if (string.IsNullOrWhiteSpace(Email))
            throw new ArgumentException("O email do funcionário é obrigatório.");

        if (string.IsNullOrWhiteSpace(SenhaHash))
            throw new ArgumentException("A senha do funcionário é obrigatória.");

        if (Salario <= 0)
            throw new ArgumentException("O salário do funcionário deve ser maior que zero.");
    }

    public void AlterarSenha(string novaSenhaHash)
    {
        SenhaHash = novaSenhaHash;
    }

    public void Desativar()
    {
        Ativo = false;
    }
}
