using LocAuto.Dominio.ModuloAutenticacao.Empresa;
using LocAuto.Dominio.ModuloAutenticacao.Funcionario;
using LocAuto.Infraestrutura.Compartilhado;
using LocAuto.Infraestrutura.ModuloAutenticacao;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LocAuto.Infrastructure;

public class LocAutoDbContext : IdentityDbContext<ApplicationUser>
{
    private readonly Guid _tenantId;

    public LocAutoDbContext(DbContextOptions<LocAutoDbContext> options, ITenantProvider tenantProvider)
        : base(options)
    {
        _tenantId = tenantProvider.CurrentTenantId;
    }

    public DbSet<Empresa> Empresas { get; set; } 
    public DbSet<Funcionario> Funcionarios { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<ApplicationUser>(b =>
        {
            b.HasOne(e => e.Empresa)
            .WithMany()
            .HasForeignKey(e => e.EmpresatId)
            .OnDelete(DeleteBehavior.Restrict);

            b.HasOne(f => f.Funcionario)
            .WithOne()
            .HasForeignKey<ApplicationUser>(f => f.FuncionarioId)
            .OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<Funcionario>()
            .HasQueryFilter(f => f.TenantId == _tenantId);

    }
}

