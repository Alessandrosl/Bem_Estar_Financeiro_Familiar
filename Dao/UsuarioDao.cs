using System;
using Bem_Estar_Financeiro_Familiar.Utilitarios;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Bem_Estar_Financeiro_Familiar.Dao
{
    internal class UsuarioDao 
    {
        public void Insert(Usuario usuario)
        {
            try
            {
                string sql = "INSERT INTO usuarios (nome, email, senha)" +
                    " VALUES (@Nome, @Email, @Senha)";
                using (var conexao = Utilitarios.Conexao.Conectar())
                using (var comando = new MySql.Data.MySqlClient.MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@Nome", usuario._Nome);
                    comando.Parameters.AddWithValue("@Email", usuario._Email);
                    comando.Parameters.AddWithValue("@Senha", usuario._Senha);
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir usuário: " + ex.Message);
            }
        }
        public void Update(Usuario usuario)
        {
            try
            {
                string sql = "UPDATE usuarios SET nome = @Nome, email =" +
                    " @Email, senha = @Senha WHERE id_usuario = @Id_usuario";
                using (var conexao = Utilitarios.Conexao.Conectar())
                using (var comando = new MySql.Data.MySqlClient.MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@Nome", usuario._Nome);
                    comando.Parameters.AddWithValue("@Email", usuario._Email);
                    comando.Parameters.AddWithValue("@Senha", usuario._Senha);
                    comando.Parameters.AddWithValue("@Id_usuario", usuario._Id_Usuario);
                    var linhas = comando.ExecuteNonQuery();
                    if (linhas == 0)
                    {
                        throw new Exception("Usuário não encontrado para atualização.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar usuário: " + ex.Message);
            }
        }
        public void Delete(int id)
        {
            try
            {
                string sql = "DELETE FROM usuarios WHERE id = @Id";
                using (var conexao = Utilitarios.Conexao.Conectar())
                using (var comando = new MySql.Data.MySqlClient.MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@Id", id);
                    var linhasAfetadas = comando.ExecuteNonQuery();
                    if (linhasAfetadas == 0)
                    {
                        throw new Exception("Usuário não encontrado para exclusão.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar usuário: " + ex.Message);
            }
        }
        public List<Usuario> List()
        {
              List<Usuario> listaUusuarios = new List<Usuario>();
            try
            {              
                string sql = "SELECT id_usuario, nome, email, senha FROM usuarios";
                using (var conexao = Utilitarios.Conexao.Conectar())
                using (var comando = new MySql.Data.MySqlClient.MySqlCommand(sql, conexao))
                using (var leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        Usuario usuario = new Usuario
                        {
                            _Id_Usuario = leitor.GetInt32("id_usuario"),
                            _Nome = leitor.GetString("nome"),
                            _Email = leitor.GetString("email"),
                            _Senha = leitor.GetString("senha"),
                        };
                        listaUusuarios.Add(usuario);
                    }
                }
                return listaUusuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar usuários: " + ex.Message);
            }
        }
    }
    
    
}
