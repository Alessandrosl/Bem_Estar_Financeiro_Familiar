using System;
using MySql.Data.MySqlClient;

namespace Bem_Estar_Financeiro_Familiar.Utilitarios
{
    internal class Conexao
    {
        // CORREÇÃO 1: String de conexão limpa (sem duplicidade de database)
        // Dica: Certifique-se que o banco 'Bem_Estar_Financeiro_Familiar' existe no MySQL ou altere para 'financas'
        public const string strconexao = "server=localhost;port=3306;uid=root;pwd=root;database=Bem_Estar_Financeiro_Familiar";

        public static MySqlConnection Conectar()
        {
            try
            {
                MySqlConnection conexao = new MySqlConnection(strconexao);
                conexao.Open();
                return conexao;
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro ao conectar ao banco de dados: " + ex.Message);
            }
        }

        // Classe para gerenciar a criação das tabelas
        public class DatabaseManager
        {
            // CORREÇÃO 2: Removemos o parâmetro string, ele pega direto da classe Conexao
            public static void CreateTables()
            {
                using (var connection = new MySqlConnection(Conexao.strconexao))
                {
                    try
                    {
                        connection.Open();
                        Console.WriteLine("Verificando banco de dados...");

                        // CORREÇÃO 3: Adicionada a coluna 'Senha' que faltava no SQL original
                        // e ajustado nomes para bater com o padrão comum
                        string createTableQuery = @"
                        CREATE TABLE IF NOT EXISTS Usuarios (
                            Id INT AUTO_INCREMENT PRIMARY KEY,
                            Nome VARCHAR(100) NOT NULL,
                            Email VARCHAR(100) NOT NULL UNIQUE,
                            Senha VARCHAR(100) NOT NULL,
                            DataCadastro TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                        ) ENGINE=InnoDB;";

                        using (var command = new MySqlCommand(createTableQuery, connection))
                        {
                            command.ExecuteNonQuery();
                            Console.WriteLine("Tabela 'Usuarios' verificada/criada com sucesso.");
                        }
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine($"Erro MySQL ao criar tabelas: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro geral: {ex.Message}");
                    }
                }
            }
        }
    }
}