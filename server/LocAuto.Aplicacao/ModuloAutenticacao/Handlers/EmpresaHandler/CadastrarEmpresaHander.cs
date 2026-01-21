using LocAuto.Aplicacao.Compartilhado;
using LocAuto.Aplicacao.ModuloAutenticacao.Dtos;
using LocAuto.Dominio.Compartilhado;
using LocAuto.Dominio.ModuloAutenticacao.Empresa;



namespace LocAuto.Aplicacao.ModuloAutenticacao.Handlers.EmpresaHandler;

public class CadastrarEmpresaHander
{
    private readonly IRepositorioEmpresa _repositorioEmpresa;
    private readonly IPasswordHasher _passwordHasher;

    public CadastrarEmpresaHander(IRepositorioEmpresa repositorioEmpresa, IPasswordHasher passwordHasher)
    {
        _repositorioEmpresa = repositorioEmpresa;
        _passwordHasher = passwordHasher;
    }

    public Results<Empresa> ExecutarCadastro(CadastrarEmpresaComand command)
    {
        try
        {
            if (_repositorioEmpresa.SelecionarPorEmail(command.Email) != null)
                return Results<Empresa>.Fail(ErroResults.RegistroDuplicado($"Já existe uma empresa cadastrada com o email {command.Email}."));

            if (_repositorioEmpresa.SelecionarPorCnpj(command.Cnpj) != null)
                return Results<Empresa>.Fail(ErroResults.RegistroDuplicado($"Já existe uma empresa cadastrada com o CNPJ {command.Cnpj}."));

            var senhaHash = _passwordHasher.Hash(command.Senha);

            var novaEmpresa = new Empresa(command.Nome, command.Cnpj, command.Email, senhaHash);

            var empresaCriada = _repositorioEmpresa.Inserir(novaEmpresa);

            return Results<Empresa>.Ok(empresaCriada, "Empresa cadastrada com sucesso.");
        }
        catch(ArgumentException ex)
        {
            return Results<Empresa>.Fail(ErroResults.RequisicaoInvalida(ex.Message));
        }
        catch (Exception ex)
        {
            return Results<Empresa>.Fail(ErroResults.ErroInterno($"Ocorreu um erro ao cadastrar a empresa: {ex.Message}"));
        }
    }

}
