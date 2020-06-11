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
    public partial class FrmCurso : Form
    {
        public FrmCurso()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e) //botão gravar "tudo"
        {
            Curso curso = new Curso(txt_Nome.Text,int.Parse(txt_Carga.Text),decimal.Parse(txt_Valor.Text));
            curso.Inserir(curso);
            MessageBox.Show("Curso Inserido com sucesso!");

        }

        private void FrmCurso_Load(object sender, EventArgs e)  //para o cursor ficar no id quando iniciar o programa
        {
            txt_Id.Focus();    
        }

        private void button1_Click(object sender, EventArgs e)   // botão listar todos
        {
            listBox1.Items.Clear();
            Curso curso = new Curso();
            foreach (var item in curso.ListarTodos())
            {
                listBox1.Items.Add(item.Id + " - " + item.Nome + " - " +
                    item.CargaHoraria + " - " + item.Valor);
            }
        }
        private void LimparCampos() // limpa os dados depois da pesquisa 
        {
            txt_Id.Clear();
            txt_Nome.Clear();
            txt_Carga.Clear();
            txt_Valor.Clear();

        }

        private void button2_Click(object sender, EventArgs e)  // botão busca por ID
        {
            if (txt_Id.ReadOnly)
            {
                txt_Id.ReadOnly = false;
                button2.Text = "Buscar";  // QUANDO  clicar muda de ... para buscar
                txt_Id.Focus();
            }
            else
            {
                if (txt_Id.Text != string.Empty)
                {
                    Curso curso = new Curso();
                    curso.ObterPorId(int.Parse(txt_Id.Text));
                    if (curso.Id > 0)
                    {
                        txt_Nome.Text = curso.Nome;
                        txt_Carga.Text = Convert.ToString(curso.CargaHoraria);
                        txt_Valor.Text = Convert.ToString(curso.Valor);
                    }
                    else
                    {
                        MessageBox.Show("Curso não cadastrado!");
                        txt_Id.Focus();
                        LimparCampos();
                    }
                }
                else
                {
                    MessageBox.Show("Digite um Id !!");
                    txt_Id.Focus();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)  // botão alterar através da busca por id
        {
            Curso curso = new Curso();
            curso.Id = int.Parse(txt_Id.Text);
            curso.Nome = txt_Nome.Text;
            curso.CargaHoraria = int.Parse(txt_Carga.Text);
            curso.Valor = Decimal.Parse(txt_Valor.Text);
            curso.Alterar(curso);
            MessageBox.Show("Curso alterado com sucesso!");
        }

        private void button5_Click(object sender, EventArgs e)  // fecha a classe
        {
            this.Close();
        }
    }

}
