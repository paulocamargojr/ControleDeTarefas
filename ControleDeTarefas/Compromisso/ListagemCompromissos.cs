using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeTarefas.Compromisso
{
    public partial class ListagemCompromissos : Form
    {
        RepositorioCompromisso repositorioCompromisso;
        public ListagemCompromissos()
        {
            SerializadorJson serializadorJson = new SerializadorJson();
            DataContext dataContext = new DataContext();
            repositorioCompromisso = new RepositorioCompromisso(serializadorJson, dataContext);
            InitializeComponent();
            CarregarCompromissos();
            
        }

        private void CarregarCompromissos()
        {
            List<Compromisso> compromissos = repositorioCompromisso.SelecionarTodos();

            listCompromissos.Items.Clear();

            foreach (Compromisso c in compromissos)
                listCompromissos.Items.Add(c);
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {

            CadastroCompromissos tela = new CadastroCompromissos();
            tela.Compromisso = new Compromisso();

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                repositorioCompromisso.Inserir(tela.Compromisso);
                CarregarCompromissos();
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            var compromissoSelecionado = (Compromisso)listCompromissos.SelectedItem;

            if (compromissoSelecionado == null)
            {

                MessageBox.Show("Selecione um compromisso primeiro!"
                , "Edição de compromissos"
                , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                DialogResult = DialogResult.None;

            }

            CadastroCompromissos tela = new CadastroCompromissos();

            tela.Compromisso = compromissoSelecionado;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                repositorioCompromisso.Editar(tela.Compromisso);
                CarregarCompromissos();
            }

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

            var compromissoSelecionado = (Compromisso)listCompromissos.SelectedItem;

            if (compromissoSelecionado == null)
            {

                MessageBox.Show("Selecione um compromisso primeiro!"
                , "Exclusão de compromissos"
                , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;

            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o compromisso?"
               , "Esclusão de compromisso"
               , MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {

                repositorioCompromisso.Excluir(compromissoSelecionado);
                CarregarCompromissos();

            }

        }
    }
}
