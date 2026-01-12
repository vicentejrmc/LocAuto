namespace LocAuto.Dominio.Compartilhado;

public abstract class EntidadeBase<T>
{
    protected Guid Id { get; set; }

    protected EntidadeBase()
    {
        Id = Guid.NewGuid();
    }

    public abstract void AtualizarRegistro(T registroAtualizado);
}
