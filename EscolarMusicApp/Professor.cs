using EscolarMusicApp;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace escolademusica
{
    public class Professor
    { //Declarando os parâmetros de acordo com dbb
     
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCadastro { get; set; }

        
        //encapesulado pela própria ferramenta do visual
      

        public Professor()
        {
        }

        public Professor(int id, string nome, string cpf, string email, string telefone, DateTime dataCadastro)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Email = email;
            Telefone = telefone;
            DataCadastro = dataCadastro;
        }

        public Professor(string nome, string cpf, string email, string telefone)
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;
            Telefone = telefone;
        }

        //public Professor(string text1, string text2, string text3, string text4)
        //{
        //    this.text1 = text1;
        //  this.text2 = text2;
        //    this.text3 = text3;
        //   this.text4 = text4;
        //}



        //efetuando os logins
        public bool EfetuarLogin(Professor professor)
        {
            return true;
        }

        // Para inserir alunos/"como"

        public void Inserir(Professor professor)
        {
            var cmd = Banco.AbriConexao();
            cmd.CommandText = "insert tb_professor values(null, @Nome, @Cpf, @Email, @Telefone, default);";
            cmd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = professor.Nome;
            cmd.Parameters.Add("@Cpf", MySqlDbType.VarChar).Value = professor.Cpf;
            cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = professor.Email;
            cmd.Parameters.Add("@Telefone", MySqlDbType.VarChar).Value = professor.Telefone;
            cmd.ExecuteNonQuery();
        }
        public void Alterar(Professor professor)   // para alterar aqui no visual e passar para o Mysql
        {                                           
            MySqlCommand cmd = Banco.AbriConexao();
            cmd.CommandText = "update tb_professor set nome_professor = @nome , cpf_professor = @cpf , email_professor = @email, telefone_professor = @telefone  where id_professor = @id ;";
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = professor.Id;
            cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = professor.Nome;
            cmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = professor.Cpf;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = professor.Email;
            cmd.Parameters.Add("@telefone", MySqlDbType.VarChar).Value = professor.Telefone;
            cmd.ExecuteNonQuery();

        }
        public List<Professor> ListarTodos()    //lista todos os alunos cadastrados
        {            

            List<Professor> professor = new List<Professor>();
            var cmd = Banco.AbriConexao();
            cmd.CommandText = "select * from tb_professor";
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                professor.Add(
                    new Professor(dr.GetInt32(0),
                        dr.GetString(1),
                        dr.GetString(2),
                        dr.GetString(3),
                        dr.GetString(4),
                        dr.GetDateTime(5)
                        ));
            }
            return professor;
        }

        public void ObterPorId(int id) //pesquisando só pelo ID
        {
            var cmd = Banco.AbriConexao();
            cmd.CommandText = "select * from tb_professor where id_professor = " + id;
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Id = dr.GetInt32(0);
                Nome = dr.GetString(1);
                Cpf = dr.GetString(2);
                Email = dr.GetString(3);
                Telefone = dr.GetString(4);
                DataCadastro = dr.GetDateTime(5);


            }
        }
    }
}
