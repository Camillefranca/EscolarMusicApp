using EscolarMusicApp;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace escolademusica
{
    public class Usuario
    { //Declarando os parâmetros de acordo com db
        public Usuario(int id, string nome, string email, string senha, string situacao)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            Situacao = situacao;
        }

        public Usuario(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        public Usuario()
        {

        }

        public Usuario(string nome, string email, string senha, string situacao, int id)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Situacao = situacao;
            Id = Id;
        }

        public Usuario(string nome, string email, string senha, string situacao)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Situacao = situacao;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Situacao { get; set; }

      

        //efetuando os logins
        public bool EfetuarLogin(Usuario usuario)
        {
                bool valido = false;
                var cmd = Banco.AbriConexao();
                cmd.CommandText =
                    "select * from tb_usuario where senha_usuario = md5(@senha) and email_usuario = @email;";
                cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = usuario.Senha;
                cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = usuario.Email;
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Id = dr.GetInt32(0);
                    Nome = dr.GetString(1);
                    Situacao = dr.GetString(4);
                    valido = true;
                }
            return valido;
        }

        // Para inserir alunos/"como"

        public void Inserir(Usuario usuario)
        {
            var cmd = Banco.AbriConexao();
            cmd.CommandText = "insert tb_usuario values(null, @nome_usuario, @email_usuario, @senha_usuario, situacao_usuario);";
            cmd.Parameters.Add("@nome_usuario", MySqlDbType.VarChar).Value = usuario.Nome;
            cmd.Parameters.Add("@email_usuario", MySqlDbType.VarChar).Value = usuario.Email;
            cmd.Parameters.Add("@senha_usuario", MySqlDbType.VarChar).Value = usuario.Senha;
            cmd.Parameters.Add("@situacao_usuario", MySqlDbType.VarChar).Value = usuario.Situacao;
            cmd.ExecuteNonQuery();
        }
        public void Alterar(Usuario usuario) // para alterar aqui no visual e passar para o Mysql
        {
            MySqlCommand cmd = Banco.AbriConexao();
            cmd.CommandText = "update tb_usuario set nome_usuario = @nome_usuario ,  email_usuario = @email_usuario, senha_usuario = @senha_usuario, situacao_usuario = @situacao_usuario where id_usuario = @id ;";
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = usuario.Id;                        
            cmd.Parameters.Add("@nome_usuario", MySqlDbType.VarChar).Value = usuario.Nome;
            cmd.Parameters.Add("@email_usuario", MySqlDbType.VarChar).Value = usuario.Email;
            cmd.Parameters.Add("@senha_usuario", MySqlDbType.VarChar).Value = usuario.Senha;
            cmd.Parameters.Add("@situacao_usuario", MySqlDbType.VarChar).Value = usuario.Situacao;
            cmd.ExecuteNonQuery();
        }
        public List<Usuario> ListarTodos()  //lista todos os alunos cadastrados 

        {
            List<Usuario> usuario = new List<Usuario>();
            var cmd = Banco.AbriConexao();
            cmd.CommandText = "select * from tb_usuario";
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                usuario.Add(
                    new Usuario(dr.GetInt32(0),
                        dr.GetString(1),
                        dr.GetString(2),
                        dr.GetString(3),
                        dr.GetString(4)  
                        ));
            }
            return usuario;
        }

        public void ObterPorId(int id) //pesquisando só pelo ID
        {
            var cmd = Banco.AbriConexao();
            cmd.CommandText = "select * from tb_usuario where id_usuario = " + id;
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Id = dr.GetInt32(0);
                Nome = dr.GetString(1);
                Email = dr.GetString(2);
                Senha = dr.GetString(3);
                Situacao = dr.GetString(4);

            }
        }
        
    }
}