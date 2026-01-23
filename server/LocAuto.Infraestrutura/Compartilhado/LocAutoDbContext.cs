using LocAuto.Dominio.ModuloAutenticacao.Empresa;
using LocAuto.Dominio.ModuloAutenticacao.Funcionario;
using Microsoft.EntityFrameworkCore;

namespace LocAuto.Infraestrutura.Compartilhado;

public class LocAutoDbContext : DbContext
{
    public LocAutoDbContext(DbContextOptions<LocAutoDbContext> options)
        : base(options) {}

    public DbSet<Empresa> Empresas { get; set; } = null!;
    public DbSet<Funcionario> Funcionarios { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empresa>()
            .HasIndex(e => e.Cnpj)
            .IsUnique();

        modelBuilder.Entity<Empresa>()
            .HasIndex(e => e.Email)
            .IsUnique();

        modelBuilder.Entity<Funcionario>()
            .HasIndex(f => f.Email)
            .IsUnique();

        modelBuilder.Entity<Funcionario>()
            .HasOne<Empresa>()
            .WithMany()
            .HasForeignKey(f => f.EmpresaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
