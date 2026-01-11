namespace LocAuto.Dominio.Compartilhado;

public abstract class EntidadeBase<T>
{
    public Guid Id { get; set; }

    public EntidadeBase(Guid id)
    {
        Id = Guid.NewGuid();
    }

    public abstract void AtualizarRegistro(T registroAtualizado);
}
