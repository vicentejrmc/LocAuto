using LocAuto.Dominio.ModuloAutenticacao.Empresa;
using LocAuto.Dominio.ModuloAutenticacao.Funcionario;
using Microsoft.AspNetCore.Identity;

namespace LocAuto.Infraestrutura.ModuloAutenticacao;

public class ApplicationUser : IdentityUser
{
    public Guid? EmpresatId { get; set; }
    public Guid? FuncionarioId { get; set; }


    public Empresa? Empresa { get; set; }
    public Funcionario? Funcionario { get; set; }
}
