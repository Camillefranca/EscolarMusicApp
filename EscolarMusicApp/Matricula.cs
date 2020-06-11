using escolademusica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace EscolarMusicApp
{
    public class Matricula
    {
       
        public int Id { get; set; }
        public Aluno Aluno { get; set; }
        public Curso Curso { get; set; }
        public string Situacao { get; set; }
        public decimal ValorCurso { get; set; }
        public DateTime DataMatricula { get; set; }
        public Usuario Usuario { get; set; }

        //public Matricula()
        //{

        //}
        public Matricula(int id, Aluno aluno, Curso curso, string situacao, decimal valorCurso, DateTime dataMatricula, Usuario usuario)
        {
            Id = id;
            Aluno = aluno;
            Curso = curso;
            Situacao = situacao;
            ValorCurso = valorCurso;
            DataMatricula = dataMatricula;
            Usuario = usuario;
        }
        public Matricula()
        {
            Aluno = new Aluno();
            Usuario = new Usuario();
            Curso = new Curso();

        }
        public Matricula( Aluno aluno, Curso curso, string situacao, decimal valorCurso, Usuario usuario)
        {
            Aluno = aluno;
            Curso = curso;
            Usuario = usuario;
        }
        public Matricula(Aluno aluno, Usuario usuario, Curso curso)
        {
            Aluno =  aluno;
            Curso =  curso;
            Usuario = usuario;
            

        }
        // insert tb_matricula values(null, 11,1,'A',5111,now(),18);
        public void Inserir(Aluno aluno, Curso curso, Usuario usuario)
        {
            var cmd = Banco.AbriConexao();
            cmd.CommandText = "insert tb_matricula values(null, @alunoId,@cursoId,'A',@valorCurso,now(),@IdUsuario);";
            cmd.Parameters.Add("@alunoId", MySqlDbType.Int32).Value = aluno.Id;
            cmd.Parameters.Add("@cursoId", MySqlDbType.Int32).Value = curso.Id;
            cmd.Parameters.Add("@valorCurso", MySqlDbType.Decimal).Value = curso.Valor;
            cmd.Parameters.Add("@IdUsuario", MySqlDbType.Int32).Value = usuario.Id;
            cmd.ExecuteNonQuery();
            cmd.CommandText = "select @@identity";
            Id = Convert.ToInt32(cmd.ExecuteScalar());
        }
        public MySqlDataReader ListarAtivas()
        {
            var cmd = Banco.AbriConexao();
            cmd.CommandText = "select id_matricula as ID, nome_aluno as Aluno, nome_curso as Curso, data_matricula from vw_matricula where situacao = 'A'";
            return cmd.ExecuteReader();
        }
    }

}
