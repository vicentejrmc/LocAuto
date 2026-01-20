using BCrypt.Net;
using LocAuto.Dominio.Compartilhado;

namespace LocAuto.Infraestrutura.Serguranca;

public class BCryptPasswoardHasher : IPasswordHasher
{
    public string Hash(string senha)
    {
        return BCrypt.Net.BCrypt.HashPassword(senha);
    }

    public bool Verificar(string senha, string senhaHash)
    {
        return BCrypt.Net.BCrypt.Verify(senha, senhaHash);
    }
}
