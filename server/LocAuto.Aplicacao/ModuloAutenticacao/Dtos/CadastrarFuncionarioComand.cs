namespace LocAuto.Aplicacao.ModuloAutenticacao.Dtos;

public class CadastrarFuncionarioComand
{
    public Guid EmpresaId { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public decimal Salario { get; set; }
}
