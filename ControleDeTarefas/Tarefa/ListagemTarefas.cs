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
    [Serializable]
    public partial class ListagemTarefas : Form
    {
        private RepositorioTarefa repositorioTarefa;
        public ListagemTarefas()
        {
            SerializadorJson serializadorJson = new SerializadorJson();
            repositorioTarefa = new RepositorioTarefa(serializadorJson);
            InitializeComponent();
            CarregarTarefas();
        }

        private void CarregarTarefas()
        {
            List<Tarefa> tarefasConcluidas = repositorioTarefa.SelecionarTarefasConcluidas();

            listTarefasConcluidas.Items.Clear();

            foreach (Tarefa t in tarefasConcluidas)
                listTarefasConcluidas.Items.Add(t);

            List<Tarefa> tarefasPendentes = repositorioTarefa.SelecionarTarefasPendentes();

            listTarefasPendentes.Items.Clear();

            foreach (Tarefa t in tarefasPendentes)
                listTarefasPendentes.Items.Add(t);
        }

        private void btnInserir_Click_1(object sender, EventArgs e)
        {

            CadastroTarefas tela = new CadastroTarefas();
            tela.Tarefa = new Tarefa();

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                repositorioTarefa.Inserir(tela.Tarefa);
                CarregarTarefas();
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            var tarefaSelecionada = (Tarefa)listTarefasPendentes.SelectedItem;

            if (tarefaSelecionada == null)
            {

                MessageBox.Show("Selecione uma tarefa primeiro!"
                , "Edição de tarefa"
                , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;

            }

            CadastroTarefas tela = new CadastroTarefas();

            tela.Tarefa = tarefaSelecionada;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                repositorioTarefa.Editar(tela.Tarefa);
                CarregarTarefas();
            }

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

            var tarefaSelecionada = (Tarefa)listTarefasPendentes.SelectedItem;

            if(tarefaSelecionada == null)
            {

                MessageBox.Show("Selecione uma tarefa primeiro!"
                , "Esclusão de tarefa"
                , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;

            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a tarefa?"
                , "Esclusão de tarefa"
                , MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if(resultado == DialogResult.OK)
            {

                repositorioTarefa.Excluir(tarefaSelecionada);
                CarregarTarefas();

            }
        }

        private void btnAdicionarItem_Click(object sender, EventArgs e)
        {

            var tarefaSelecionada = (Tarefa)listTarefasPendentes.SelectedItem;

            if (tarefaSelecionada == null)
            {

                MessageBox.Show("Selecione uma tarefa primeiro!"
                , "Adição itens tarefa"
                , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;

            }

            CadastroItensTarefa tela = new CadastroItensTarefa(tarefaSelecionada);

            if(tela.ShowDialog() == DialogResult.OK)
            {

                List<ItemTarefa> itens = tela.ItensAdicionados;

                repositorioTarefa.AdicionatItens(tarefaSelecionada, itens);

                CarregarTarefas();

            }

        }

        private void btnAtualizarItem_Click(object sender, EventArgs e)
        {

            var tarefaSelecionada = (Tarefa)listTarefasPendentes.SelectedItem;

            if (tarefaSelecionada == null)
            {

                MessageBox.Show("Selecione uma tarefa primeiro!"
                , "Adição itens tarefa"
                , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;

            }

            AtualizacaoItensTarefa tela = new AtualizacaoItensTarefa(tarefaSelecionada);

            if(tela.ShowDialog() == DialogResult.OK)
            {

                List<ItemTarefa> itensConcluidos = tela.ItensConcluidos;
                List<ItemTarefa> itensPendentes = tela.ItensPendentes;

                repositorioTarefa.AtualizarItens(tarefaSelecionada, itensConcluidos, itensPendentes);
                CarregarTarefas();

            }

            

        }
    }
}
