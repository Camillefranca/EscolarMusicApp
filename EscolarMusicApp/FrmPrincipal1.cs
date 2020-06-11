using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EscolarMusicApp
{
    public partial class FrmPrincipal1 : Form
    {
        public FrmPrincipal1()
        {
            InitializeComponent();
        }

        private void alunosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //criar uma instância de Form1 (FrmAluno)
            FrmAluno frmAluno = new FrmAluno();
            frmAluno.MdiParent = this;
            frmAluno.Show();
        }

        private void professoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProfessor frmProfessor = new FrmProfessor();
            frmProfessor.MdiParent = this;
            frmProfessor.Show();
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuario frmUsuario = new FrmUsuario();
            frmUsuario.MdiParent = this;
            frmUsuario.Show();
        }

        private void cursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCurso frmCurso = new FrmCurso();
            frmCurso.MdiParent = this;
            frmCurso.Show();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPrincipal1_Load(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.ShowDialog();
            if (Program.usuarioLogado != null)
            {
                Text = "FrmPrincipal - " + Program.usuarioLogado.Nome;
            }
            else
            {
                Application.Exit();
            }
        }

        private void matrículaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMatricula frmMatricula = new FrmMatricula();
            frmMatricula.MdiParent = this;
            frmMatricula.Show();
        }

        private void alunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAlunoRe frmAlunoRe = new FrmAlunoRe();
            frmAlunoRe.MdiParent = this;
            frmAlunoRe.Show();
        }

        private void professorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProfessorRe frmProfessorRe = new FrmProfessorRe();
            frmProfessorRe.MdiParent = this;
            frmProfessorRe.Show();
        }

        private void usuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuarioRe frmUsuarioRe = new FrmUsuarioRe();
            frmUsuarioRe.MdiParent = this;
            frmUsuarioRe.Show();
        }

        private void cursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCursoRe frmCursoRe = new FrmCursoRe();
            frmCursoRe.MdiParent = this;
            frmCursoRe.Show();
        }
    }
}
