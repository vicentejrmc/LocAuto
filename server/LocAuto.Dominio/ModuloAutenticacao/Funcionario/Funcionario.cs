using LocAuto.Dominio.Compartilhado;

namespace LocAuto.Dominio.ModuloAutenticacao.Funcionario;

public class Funcionario : EntidadeBase<Funcionario>
{
    public Guid TenantId { get; private set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public decimal Salario { get; private set; }
    public DateTime DataAdmissao { get; private set; }

    public Funcionario(Guid tenantId, string nome, string email, decimal salario)
    {
        Id = Guid.NewGuid();
        TenantId = tenantId;
        Nome = nome;
        Email = email;
        Salario = salario;
        DataAdmissao = DateTime.Now;
    }

    public override void AtualizarRegistro(Funcionario registroAtualizado)
    {
        Nome = registroAtualizado.Nome;
        Email = registroAtualizado.Email;
        Salario = registroAtualizado.Salario;
    }
}
