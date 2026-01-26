using LocAuto.Aplicacao.Compartilhado;
using LocAuto.Aplicacao.ModuloAutenticacao.Dtos;
using LocAuto.Dominio.Compartilhado;
using LocAuto.Dominio.ModuloAutenticacao.Empresa;
using LocAuto.Dominio.ModuloAutenticacao.Funcionario;

namespace LocAuto.Aplicacao.ModuloAutenticacao.Handlers.FuncionarioHandler;

public class CadastrarFuncionarioHandler
{
    private readonly IRepositorioFuncionario _repositorioFuncionario;
    private readonly IRepositorioEmpresa _repositorioEmpresa;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUnitOfWork _unitOfWork;

    public CadastrarFuncionarioHandler(
        IRepositorioFuncionario repositorioFuncionario,
        IRepositorioEmpresa repositorioEmpresa,
        IPasswordHasher passwordHasher,
        IUnitOfWork unitOfWork
        )
    {
        _repositorioFuncionario = repositorioFuncionario;
        _repositorioEmpresa = repositorioEmpresa;
        _passwordHasher = passwordHasher;
        _unitOfWork = unitOfWork;
    }

    public Results<Funcionario> ExecultarCadastro(CadastrarFuncionarioComand command)
    {
        try
        {
            var empresa = _repositorioEmpresa.SelecionarPorId(command.EmpresaId);
            if (empresa == null)
                return Results<Funcionario>.Fail(ErroResults.RegistroNaoEncontrado(command.EmpresaId));

            var compararFuncionario = _repositorioFuncionario.SelecionarPorEmail(command.Email);
            if (compararFuncionario != null)
                return Results<Funcionario>.Fail(ErroResults.RegistroDuplicado($"Já existe um funcionário cadastrado com o email {command.Email}."));

            var senhaHash = _passwordHasher.Hash(command.Senha);

            var novoFuncionario = new Funcionario(
                command.EmpresaId,
                command.Nome,
                command.Email,
                senhaHash,
                command.Salario
            );

            var funcionaarioCadastrado = _repositorioFuncionario.Inserir(novoFuncionario);

            _unitOfWork.Commit();

            return Results<Funcionario>.Ok(funcionaarioCadastrado, "Funcionário cadastrado com sucesso.");
        }
        catch(ArgumentException ex)
        {
            _unitOfWork.Rollback();
            return Results<Funcionario>.Fail(ErroResults.RequisicaoInvalida(ex.Message));
        }
        catch (Exception ex)
        {
            _unitOfWork.Rollback();
            return Results<Funcionario>.Fail(ErroResults.ErroInterno($"Ocorreu um erro ao cadastrar o funcionário. Detalhes: {ex.Message}"));
        }
    }
}
