namespace LocAuto.Dominio.Compartilhado;

public interface IPasswordHasher
{
    string Hash(string senha);
    bool Verificar(string senha, string senhaHash);
}
