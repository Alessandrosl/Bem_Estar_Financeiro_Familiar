using Bem_Estar_Financeiro_Familiar.Dao;
using System;
using System.Collections.Generic;

namespace Bem_Estar_Financeiro_Familiar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bem_Estar_Financeiro_Familiar.Utilitarios.Conexao.DatabaseManager.CreateTables();
            int opcao;
            do
            {
                // Dica: Console.Clear() ajuda a limpar a tela a cada iteração, se desejar.
                Console.WriteLine(">>> Bem Estar Financeiro Familiar <<<");
                Console.WriteLine("");
                Console.WriteLine("1 - Cadastrar Usuario");
                Console.WriteLine("2 - Listar Usuario");
                Console.WriteLine("3 - Atualizar Usuario");
                Console.WriteLine("4 - Deletar Usuario");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("");
                Console.Write("Escolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    opcao = -1;
                }

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("");
                        CadastrarUsuario(); // Corrigido Maiúscula
                        Console.WriteLine("");
                        break;
                    case 2:
                        Console.WriteLine("");
                        ListarUsuario(); // Corrigido nome do método
                        Console.WriteLine("");
                        break;
                    case 3:
                        Console.WriteLine("");
                        AtualizarUsuario(); // Corrigido nome do método
                        Console.WriteLine("");
                        break;
                    case 4:
                        Console.WriteLine("");
                        DeletarUsuario(); // Corrigido nome do método
                        Console.WriteLine("");
                        break;
                    case 0:
                        Console.WriteLine("");
                        Console.WriteLine("Saindo...");
                        Console.WriteLine("");
                        break;
                    default:
                        Console.WriteLine("");
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        Console.WriteLine("");
                        break;
                }

            } while (opcao != 0);
        }

        // Método renomeado para PascalCase (padrão C#) e consistente com a chamada
        static void CadastrarUsuario()
        {
            try
            {
                Usuario u1 = new Usuario();

                Console.Write("Nome: ");
                u1._Nome = Console.ReadLine();

                Console.Write("Email: ");
                u1._Email = Console.ReadLine();

                Console.Write("Senha: ");
                u1._Senha = Console.ReadLine();

                UsuarioDao cadastroUsuario = new UsuarioDao();
                cadastroUsuario.Insert(u1);

                Console.WriteLine("Usuário cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao cadastrar usuário: {ex.Message}");
            }
        }

        // Renomeado de ListarFuncionarios para ListarUsuario para manter coerência
        static void ListarUsuario()
        {
            try
            {
                UsuarioDao usuarioDao = new UsuarioDao();
                List<Usuario> listaUsuarios = usuarioDao.List(); // Mudei nome da variavel para evitar conflito

                if (listaUsuarios == null || listaUsuarios.Count == 0)
                {
                    Console.WriteLine("Nenhum usuário cadastrado.");
                    return;
                }

                Console.WriteLine("--- Lista de Usuários ---");
                // Corrigido: "var usuario" (singular) in "listaUsuarios" (plural)
                foreach (var usuario in listaUsuarios)
                {
                    Console.WriteLine($"Nome: {usuario._Nome}, Email: {usuario._Email}, Senha: {usuario._Senha}");
                }
                Console.WriteLine("-----------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao listar usuários: {ex.Message}");
            }
        }

        // Renomeado de AtualizarFuncionario para AtualizarUsuario
        static void AtualizarUsuario()
        {
            try
            {
                Usuario usuario = new Usuario();

                Console.Write("ID do Usuário a ser atualizado: ");
                if (!int.TryParse(Console.ReadLine(), out int _id_Usuario))
                {
                    Console.WriteLine("ID inválido. Por favor, digite um número.");
                    return;
                }
                usuario._Id_Usuario = _id_Usuario;

                Console.Write("Novo Nome: ");
                usuario._Nome = Console.ReadLine();

                Console.Write("Novo Email: ");
                usuario._Email = Console.ReadLine();

                Console.Write("Nova Senha: ");
                usuario._Senha = Console.ReadLine();

                UsuarioDao usuarioDao = new UsuarioDao();
                usuarioDao.Update(usuario);

                Console.WriteLine("Usuário atualizado com sucesso!");
            }
            catch (FormatException)
            {
                // Removido o switch duplicado que estava aqui incorretamente
                Console.WriteLine("Erro de formato na entrada. Certifique-se de digitar o ID corretamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar usuário: {ex.Message}");
            }
        }

        // Renomeado de DeletarFuncionario para DeletarUsuario
        static void DeletarUsuario()
        {
            try
            {
                Console.Write("Digite o ID do usuário a ser deletado: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("ID inválido.");
                    return;
                }

                UsuarioDao dao = new UsuarioDao();
                dao.Delete(id);

                Console.WriteLine("Usuário deletado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao deletar usuário: {ex.Message}");
            }
        }
    }
}