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
    public partial class FrmAlunoRe : Form
    {
        public FrmAlunoRe()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Aluno aluno = new Aluno();
            foreach (var item in aluno.ListarTodos())
            {
                listBox1.Items.Add(item.Id + " - " + item.Nome + " - " +
                    item.Email + " - " + item.DataCadastro);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
