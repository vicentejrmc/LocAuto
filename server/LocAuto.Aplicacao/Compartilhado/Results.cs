namespace LocAuto.Aplicacao.Compartilhado;

public class Results
{
    public bool Sucesso { get; }
    public bool Falha => !Sucesso;
    public string Mensagem { get; }

    protected Results(bool sucesso, string mensagem)
    {
        Sucesso = sucesso;
        Mensagem = mensagem;
    }

    public static Results Ok(string mensagem = "") => new Results(true, mensagem);
    public static Results Fail(string mensagem) => new Results(false, mensagem);
}


public class Results<T> : Results
{
    public T Valor { get; }

    protected Results(bool sucesso, T valor, string mensagem) : base(sucesso, mensagem)
    {
        Valor = valor;
    }

    public static Results<T> Ok(T valor, string mensagem = "") => new Results<T>(true, valor, mensagem);
    public static new Results<T> Fail(string mensagem) => new Results<T>(false, default, mensagem);
}
