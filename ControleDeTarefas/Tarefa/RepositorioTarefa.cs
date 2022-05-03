using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleDeTarefas
{
    public class RepositorioTarefa
    {
        private readonly SerializadorJson serializador;
        List<Tarefa> tarefas = new List<Tarefa>();
        private int contador = 0;

        public RepositorioTarefa(SerializadorJson serializador)
        {

            this.serializador = serializador;

            tarefas = serializador.CarregarObjetosDoArquivoTarefa();

            if (tarefas.Count > 0)
                contador = tarefas.Max(x => x.Numero);
        }

        public List<Tarefa> SelecionarTarefasConcluidas()
        {
            List<Tarefa> tarefasConcluidas = new List<Tarefa>();

            foreach (var item in tarefas)
            {

                decimal percentual = item.CalcularPercentualConcluido();
                if (percentual == 100)
                    tarefasConcluidas.Add(item);

            }
            return tarefasConcluidas;
        }

        public List<Tarefa> SelecionarTarefasPendentes()
        {

            List<Tarefa> tarefasPendentes = new List<Tarefa>();

            foreach (var item in tarefas)
            {

                decimal percentual = item.CalcularPercentualConcluido();
                if (percentual < 100)
                    tarefasPendentes.Add(item);

            }
            return tarefasPendentes;

        }

        public void Inserir(Tarefa tarefa)
        {

            tarefa.Numero = ++contador;
            tarefas.Add(tarefa);

            serializador.GravarObjetosEmArquivoTarefa(tarefas);

        }

        public void Editar(Tarefa tarefa)
        {
            foreach (var t in tarefas)
            {

                t.Titulo = tarefa.Titulo;
                break;

            }

            serializador.GravarObjetosEmArquivoTarefa(tarefas);

        }

        public void Excluir(Tarefa tarefa)
        {

            tarefas.Remove(tarefa);

            serializador.GravarObjetosEmArquivoTarefa(tarefas);
        }

        public void AdicionatItens(Tarefa tarefaSelecionada, List<ItemTarefa> itens)
        {

            foreach (var item in itens)
            {

                tarefaSelecionada.AdicionarItem(item);

            }

        }

        public void AtualizarItens(Tarefa tarefaSelecionada, List<ItemTarefa> itens, List<ItemTarefa> itensPendentes)
        {

            foreach (var item in itens)
            {

                tarefaSelecionada.ConcluirItem(item);

            }

            foreach (var item in itensPendentes)
            {

                tarefaSelecionada.MarcarPendente(item);

            }

            serializador.GravarObjetosEmArquivoTarefa(tarefas);

        }
    }
}