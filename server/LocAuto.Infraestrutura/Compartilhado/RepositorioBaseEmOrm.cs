using LocAuto.Dominio.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocAuto.Infraestrutura.Compartilhado;

public class RepositorioBaseEmOrm<T> : IRepositorio<T> where T : EntidadeBase<T>
{
    protected readonly LocAutoDbContext dbContext;
    protected readonly DbSet<T> dbSet;

    public RepositorioBaseEmOrm(LocAutoDbContext dbContext, DbSet<T> dbSet)
    {
        this.dbContext = dbContext;
        this.dbSet = dbSet;
    }

    public T Inserir(T novoRegistro)
    {
        dbSet.Add(novoRegistro);
        return novoRegistro;
    }

    public bool Editar(Guid id, T registroEditado)
    {
        var existente = SelecionarPorId(id);
        if (existente == null)
            return false; 
        
        existente.AtualizarRegistro(registroEditado);
        dbSet.Update(existente);
        return true;
    }

    public bool Excluir(Guid id)
    {
        var existente = SelecionarPorId(id); 
        if (existente == null)
            return false;
        
        dbSet.Remove(existente);
        return true;
    }

    public T? SelecionarPorId(Guid id)
    {
        return dbSet.Find(id);
    }

    public List<T> SelecionarTodos()
    {
        return dbSet.ToList();
    }
}
