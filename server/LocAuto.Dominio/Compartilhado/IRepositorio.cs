    namespace LocAuto.Dominio.Compartilhado;

public interface IRepositorio<T> where T : EntidadeBase<T>
{
    // crud - create, read, update, delete
    public void Inserir(T novoRegistro);
    public List<T> SelecionarTodos();
    public T SelecionarPorId(Guid id);
    public void Editar(Guid id, T registroAtualizado);
    public void Excluir(Guid id);
}
