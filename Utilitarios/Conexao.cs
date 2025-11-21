using System;
using MySql.Data.MySqlClient;

namespace Bem_Estar_Financeiro_Familiar.Utilitarios
{
    internal class Conexao
    {
        private const string strconexao =
            "server=localhost;port=3306;database=financas;uid=root;pwd=root;database=Bem_Estar_Financeiro_Familiar";
        public static MySqlConnection Conectar()
        {
            MySqlConnection conexao = new MySqlConnection(strconexao);
            try
            {
                conexao.Open();
                return conexao;
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro ao conectar ao banco de dados: " + ex.Message);
            }
        }
    }
}
