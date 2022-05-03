using ControleDeTarefas.Compromisso;
using ControleDeTarefas.Contato;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeTarefas
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ListagemTarefas listagemTarefas = new ListagemTarefas();

            listagemTarefas.ShowDialog();

        }

        private void button4_Click(object sender, EventArgs e)
        {

            this.Close();

        }

        private void btnContatos_Click(object sender, EventArgs e)
        {

            ListagemContatos listagemContatos = new ListagemContatos();
            listagemContatos.ShowDialog();

        }

        private void btnCompromissos_Click(object sender, EventArgs e)
        {

            ListagemCompromissos listagemCompromissos = new ListagemCompromissos();
            listagemCompromissos.ShowDialog();

        }
    }
}
