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
    public partial class FrmUsuario : Form
    {
        public FrmUsuario()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario(txt_Nome.Text,txt_Email.Text,txt_Senha.Text,txt_Situacao.Text);
            usuario.Inserir(usuario);
            MessageBox.Show("Usuario inserido com sucesso!");
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            txt_Id.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Usuario usuario = new Usuario();
            foreach (var item in usuario.ListarTodos())
            {
                listBox1.Items.Add(item.Id + " - " + item.Nome + " - " + item.Email + " - " + item.Situacao);
                
            }
            
        }
        private void LimparCampos()
        {
            txt_Id.Clear();
            txt_Nome.Clear();
            txt_Email.Clear();
            txt_Senha.Clear();
            txt_Situacao.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txt_Id.ReadOnly)
            {
                txt_Id.ReadOnly = false;
                button2.Text = "Buscar";

                txt_Id.Focus();
                LimparCampos();
            }
            else
            {
                if(txt_Id.Text != string.Empty)
                {
                    Usuario usuario = new Usuario();
                    usuario.ObterPorId(int.Parse(txt_Id.Text));
                    if(usuario.Id > 0)
                    {
                        txt_Nome.Text = usuario.Nome;
                        txt_Email.Text = usuario.Email;

                        txt_Senha.Text = usuario.Senha;
                        txt_Situacao.Text = usuario.Situacao;
                    }
                    else
                    {
                        MessageBox.Show("Usuario não cadastrado!");
                    }
                    txt_Id.ReadOnly = true;
                }
                else
                {
                    MessageBox.Show("Digite um código para buscar...");
                    txt_Id.Focus();
                }
            }
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.Id = int.Parse(txt_Id.Text);
            usuario.Nome = txt_Nome.Text;
            usuario.Email = txt_Email.Text;
            usuario.Senha = txt_Senha.Text;
            usuario.Situacao = txt_Situacao.Text;
            MessageBox.Show("Usuario alterado com sucesso!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
