using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocAuto.Aplicacao.Compartilhado;

public static class ErroResults
{
    public static string RegistroDuplicado(string mensagem) =>
      $"Registro duplicado: {mensagem}";

    public static string RegistroNaoEncontrado(Guid id) =>
        $"Registro com ID {id} não encontrado.";

    public static string ExclusaoBloqueada(string mensagem) =>
        $"Exclusão bloqueada: {mensagem}";

    public static string RequisicaoInvalida(string mensagem) =>
        $"Requisição inválida: {mensagem}";

    public static string ErroInterno(string mensagem) =>
        $"Erro interno no servidor: {mensagem}";

    public static string PermissaoNegada(string mensagem) =>
        $"Acesso negado: {mensagem}";
}
