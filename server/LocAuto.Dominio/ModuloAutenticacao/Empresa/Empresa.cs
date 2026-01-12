using LocAuto.Dominio.Compartilhado;

namespace LocAuto.Dominio.ModuloAutenticacao.Empresa;

public class Empresa : EntidadeBase<Empresa>
{
    public string Nome { get; set; }
    public string Cnpj { get; set; }
    public bool Ativa { get; set; }
    public DateTime DataCadastro { get; private set; }

    public Empresa(string nome, string cnpj)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Cnpj = cnpj;
        Ativa = true;
        DataCadastro = DateTime.Now;
    }

    public override void AtualizarRegistro(Empresa registroAtualizado)
    {
       Nome = registroAtualizado.Nome;
       Cnpj = registroAtualizado.Cnpj;
    }
}
