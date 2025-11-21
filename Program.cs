using System;
using Bem_Estar_Financeiro_Familiar.Dao;
using Bem_Estar_Financeiro_Familiar.Utilitarios;
//using Bem_Estar_Financeiro_Familiar.Models;

namespace Bem_Estar_Financeiro_Familiar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Testar a conexão com o banco de dados
                var conexao = Conexao.Conectar();
                Console.WriteLine("Conexão com o banco de dados estabelecida com sucesso.");
                // Criar um novo usuário
                Usuario novoUsuario = new Usuario
                {
                    Nome = "admin",
                    Email = "admin@gmail.com"
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }
    }
}
