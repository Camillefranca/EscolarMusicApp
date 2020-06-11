using escolademusica;
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
    public partial class FrmProfessor : Form
    {
        public FrmProfessor()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            Professor professor = new Professor(txtNome.Text, txtCpf.Text, txtEmail.Text, txtTelefone.Text);
            professor.Inserir(professor);
            MessageBox.Show("Professor inserido com sucesso!");
        }

        private void FrmProfessor_Load(object sender, EventArgs e)
        {
            txtID.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Professor professor = new Professor();
            foreach (var item in professor.ListarTodos())
            {
                listBox1.Items.Add(item.Id + " - " + item.Nome + " - " +
                    item.Email + " - " + item.DataCadastro);
            }
        }
        private void LimparCampos()
        {
            txtID.Clear();
            txtNome.Clear();
            txtCpf.Clear();
            txtEmail.Clear();
            txtTelefone.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (txtID.ReadOnly)
            {
                txtID.ReadOnly = false;
                button1.Text = "Buscar";
                txtID.Focus();
            }
            else
            {
                if (txtID.Text != string.Empty)
                {
                    Professor professor = new Professor();
                    professor.ObterPorId(int.Parse(txtID.Text));
                    if (professor.Id > 0)
                    {
                        txtNome.Text = professor.Nome;
                        txtCpf.Text = professor.Cpf;
                        txtEmail.Text = professor.Email;
                        txtTelefone.Text = professor.Telefone;
                    }
                    else
                    {
                        MessageBox.Show("Professor não cadastrado !!");
                        txtID.Focus();
                        LimparCampos();
                    }
                }
                else
                {
                    MessageBox.Show("Digite um Id !!");
                    txtID.Focus();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Professor professor = new Professor();
            professor.Id = int.Parse(txtID.Text);
            professor.Nome = txtNome.Text;
            professor.Telefone = txtTelefone.Text;
            professor.Alterar(professor);
            MessageBox.Show("Professor Alterado com sucesso!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
