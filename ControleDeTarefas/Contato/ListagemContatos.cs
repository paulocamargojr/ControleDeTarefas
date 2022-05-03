using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ControleDeTarefas.Contato
{
    public partial class ListagemContatos : Form
    {
        RepositorioContato repositorioContato;
        public ListagemContatos()
        {
            SerializadorJson serializadorJson = new SerializadorJson();
            repositorioContato = new RepositorioContato(serializadorJson);
            InitializeComponent();
            CarregarContatos();
        }

        private void CarregarContatos()
        {
            List<Contato> contatos = repositorioContato.SelecionarTodos();
            List<Contato> contatosOrdenados = new List<Contato>();
            contatosOrdenados = contatos.OrderByDescending(x=>x.Cargo).ToList();

            listContatos.Items.Clear();

            foreach (Contato c in contatosOrdenados)
                listContatos.Items.Add(c);
        }

        private void btnInserir_Click(object sender, System.EventArgs e)
        {

            CadastroContatos tela = new CadastroContatos();
            tela.Contato = new Contato();

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                repositorioContato.Inserir(tela.Contato);
                CarregarContatos();
            }

        }

        private void btnEditar_Click(object sender, System.EventArgs e)
        {

            var contatoSelecionado = (Contato)listContatos.SelectedItem;

            if (contatoSelecionado == null)
            {

                MessageBox.Show("Selecione um contato primeiro!"
                , "Edição de contato"
                , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;

            }

            CadastroContatos tela = new CadastroContatos();

            tela.Contato = contatoSelecionado;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                repositorioContato.Editar(tela.Contato);
                CarregarContatos();
            }

        }

        private void btnExcluir_Click(object sender, System.EventArgs e)
        {

            var contatoSelecionado = (Contato)listContatos.SelectedItem;

            if (contatoSelecionado == null)
            {

                MessageBox.Show("Selecione um contato primeiro!"
                , "Exclusão de contato"
                , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;

            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o contato?"
                , "Esclusão de contato"
                , MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {

                repositorioContato.Excluir(contatoSelecionado);
                //if (!excluir)
                //{

                //    MessageBox.Show("Não é possivvel excluir contato, pois o mesmo está registrado em um compromisso!"
                //, "Exclusão de contato"
                //, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                //    return;

                //}
                CarregarContatos();

            }
        }

        public List<Contato> ListContatos()
        {

            List<Contato> contatoList = new List<Contato>();
            contatoList = repositorioContato.SelecionarTodos();

            return contatoList;

        }

    }
}
