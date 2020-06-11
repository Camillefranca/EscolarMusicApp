using EscolarMusicApp;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace escolademusica
{
    public class Curso
    {//Declarando os parâmetros de acordo com db

        public int Id { get; set; }
        public string Nome { get; set; }
        public int CargaHoraria { get; set; }
        public decimal Valor { get; set; }

        //encapesulado pela própria ferramenta do visual

        public Curso()
        {
            // tem que ter um plublic vazio
        }

        public Curso(int id, string nome, int cargaHoraria, decimal valor)
        {
            Id = id;
            Nome = nome;
            CargaHoraria = cargaHoraria;
            Valor = valor;
        }

        public Curso(string nome, int cargaHoraria, decimal valor)
        {
            Nome = nome;
            CargaHoraria = cargaHoraria;
            Valor = valor;
        }

        // Para inserir alunos/"como"

        public void Inserir(Curso curso)
        {
            var cmd = Banco.AbriConexao();
            cmd.CommandText = "insert tb_curso values(null, @Nome, @CargaHoraria, @Valor);";
            cmd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = curso.Nome;
            cmd.Parameters.Add("@CargaHoraria", MySqlDbType.VarChar).Value = curso.CargaHoraria;
            cmd.Parameters.Add("@Valor", MySqlDbType.VarChar).Value = curso.Valor;
            cmd.ExecuteNonQuery();
        }
        public void Alterar(Curso curso)   // para alterar aqui no visual e passar para o Mysql
        {
            MySqlCommand cmd = Banco.AbriConexao();
            cmd.CommandText = "update tb_curso set nome_curso = @nome, carga_horaria_curso = @cargaHoraria, valor_curso = @valor where id_curso = @id ;";
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = curso.Id;
            cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = curso.Nome;
            cmd.Parameters.Add("@cargaHoraria", MySqlDbType.VarChar).Value = curso.CargaHoraria;
            cmd.Parameters.Add("@valor", MySqlDbType.Int32).Value = curso.Valor;
            cmd.ExecuteNonQuery();

        }
        public List<Curso> ListarTodos() //lista todos os alunos cadastrados 

        {
            List<Curso> curso = new List<Curso>();
            var cmd = Banco.AbriConexao();
            cmd.CommandText = "select * from tb_curso";
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                curso.Add(
                    new Curso(dr.GetInt32(0),
                        dr.GetString(1),
                        dr.GetInt32(2),
                        dr.GetDecimal(3)
                        ));
            }
            return curso;
        }

        public void ObterPorId(int id)
        {
            var cmd = Banco.AbriConexao();
            cmd.CommandText = "select * from tb_curso where id_curso = " + id;
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Id = dr.GetInt32(0);
                Nome = dr.GetString(1);
                CargaHoraria = dr.GetInt32(2);
                Valor = dr.GetDecimal(3);

            }
        }
    }
}
