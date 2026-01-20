    namespace LocAuto.Dominio.Compartilhado;

public interface IRepositorio<T> where T : EntidadeBase<T>
{
    // crud - create, read, update, delete
    public T Inserir(T novoRegistro);
    public List<T> SelecionarTodos();
    public T? SelecionarPorId(Guid id);
    public bool Editar(Guid id, T registroEditado);
    public bool Excluir(Guid id);
}
