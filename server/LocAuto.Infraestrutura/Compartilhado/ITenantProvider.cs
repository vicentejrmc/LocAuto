namespace LocAuto.Infraestrutura.Compartilhado;

public interface ITenantProvider
{
    Guid CurrentTenantId { get; }
}
