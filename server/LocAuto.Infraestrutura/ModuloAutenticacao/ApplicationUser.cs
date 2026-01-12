using Microsoft.AspNetCore.Identity;

namespace LocAuto.Infraestrutura.ModuloAutenticacao;

public class ApplicationUser : IdentityUser
{
    public Guid TenantId { get; set; }
}
