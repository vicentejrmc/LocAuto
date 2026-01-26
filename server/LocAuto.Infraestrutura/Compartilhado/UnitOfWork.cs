using LocAuto.Dominio.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocAuto.Infraestrutura.Compartilhado;

public class UnitOfWork : IUnitOfWork
{
    private readonly LocAutoDbContext _dbContext;
    public UnitOfWork(LocAutoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Commit()
    {
        _dbContext.SaveChanges();
    }

    public void Rollback()
    {
        foreach (var entry in _dbContext.ChangeTracker.Entries())
        {
            switch (entry.State)
            {
                case EntityState.Modified:
                    entry.State = EntityState.Unchanged;
                    break;

                case EntityState.Added:
                    entry.State = EntityState.Detached;
                    break;

                case EntityState.Deleted:
                    entry.Reload();
                    break;
            }
        }
    }
}
