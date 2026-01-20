using LocAuto.Dominio.Compartilhado;

namespace LocAuto.Dominio.ModuloAutenticacao.Empresa;

public interface IRepositorioEmpresa : IRepositorio<Empresa>
{
    Empresa SelecionarPorEmail(string email);

    Empresa SelecionarPorCnpj(string cnpj);
}
