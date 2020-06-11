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
    public partial class FrmCursoRe : Form
    {
        public FrmCursoRe()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Curso curso = new Curso();
            foreach (var item in curso.ListarTodos())
            {
                listBox1.Items.Add(item.Id + " - " + item.Nome + " - " +
                    item.CargaHoraria + " - " + item.Valor);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
