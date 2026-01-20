using LocAuto.Dominio.Compartilhado;

namespace LocAuto.Dominio.ModuloAutenticacao.Funcionario;

public interface IRepositorioFuncionario : IRepositorio<Funcionario> 
{
    Funcionario SelecionarPorEmail(string email);
    List<Funcionario> ListarPorEmpresa(Guid empresaId);
}
