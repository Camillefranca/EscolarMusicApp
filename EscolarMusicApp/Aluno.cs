using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolarMusicApp
{
    //Declarando os parâmetros de acordo com db
    public class Aluno
    {
        private string text1;
        private string text2;
        private string text3;
        private string text4;

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCadastro { get; set; }

        public Aluno(string nome, string cpf, string sexo, string email, string telefone)
        {
            Nome = nome;
            Cpf = cpf;
            Sexo = sexo;
            Email = email;
            Telefone = telefone;
           
        }

        //encapesulado pela própria ferramenta do visual
        public Aluno(int id, string nome, string cpf, string sexo, string email, string telefone, DateTime dataCadastro)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Sexo = sexo;
            Email = email;
            Telefone = telefone;
            DataCadastro = dataCadastro;
        }

        public Aluno()
        {
            // tem que ter um plublic vazio
        }

        //public Aluno(string text1, string text2, string sexo, string text3, string text4)
        //{
        //    this.text1 = text1;
        //    this.text2 = text2;
        //    Sexo = sexo;
        //    this.text3 = text3;
        //    this.text4 = text4;
        //}


        //efetuando os logins
        public bool EfetuarLogin(Aluno aluno)
        {
            return true;
        }

        // Para inserir alunos/"como"
        public void Inserir(Aluno aluno)
        {
            MySqlCommand cmd = Banco.AbriConexao();
            cmd.CommandText = "insert tb_aluno values(null, @nome, @cpf, @sexo, @email, @telefone, default);";
            cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = aluno.Nome;
            cmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = aluno.Cpf;
            cmd.Parameters.Add("@sexo", MySqlDbType.VarChar).Value = aluno.Sexo;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = aluno.Email;
            cmd.Parameters.Add("@telefone", MySqlDbType.VarChar).Value = aluno.Telefone;
            cmd.ExecuteNonQuery();
        }
        public void Alterar(Aluno aluno) // para alterar aqui no visual e passar para o Mysql
        {
            MySqlCommand cmd = Banco.AbriConexao();
            cmd.CommandText = "update tb_aluno set nome_aluno = @nome , sexo_aluno = @sexo , telefone_aluno = @telefone where id_aluno = @id ;";
            cmd.Parameters.Add("@nome",MySqlDbType.VarChar).Value = aluno.Nome;
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = aluno.Id;
            cmd.Parameters.Add("@sexo", MySqlDbType.VarChar).Value = aluno.Sexo;
            cmd.Parameters.Add("@telefone", MySqlDbType.VarChar).Value = aluno.Telefone;
            cmd.ExecuteNonQuery();

        }

        //lista todos os alunos cadastrados 
        public List<Aluno> ListarTodos()
        {
            List<Aluno> alunos = new List<Aluno>();
            var cmd = Banco.AbriConexao();
            cmd.CommandText = "select * from tb_aluno";
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                alunos.Add(
                    new Aluno(dr.GetInt32(0),
                        dr.GetString(1),
                        dr.GetString(2),
                        dr.GetString(3),
                        dr.GetString(4),
                        dr.GetString(5),
                        dr.GetDateTime(6)
                        ));
            }
            return alunos;
        }

        public void ObterPorId(int id)
        {
            var cmd = Banco.AbriConexao();
            cmd.CommandText = "select * from tb_aluno where id_aluno = " + id;
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Id = dr.GetInt32(0);
                Nome = dr.GetString(1);
                Cpf = dr.GetString(2);
                Sexo = dr.GetString(3);
                Email = dr.GetString(4);
                Telefone = dr.GetString(5);
                DataCadastro = dr.GetDateTime(6);
            }
        }

    }
}
