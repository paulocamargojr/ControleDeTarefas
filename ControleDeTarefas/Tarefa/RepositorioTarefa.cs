using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleDeTarefas
{
    public class RepositorioTarefa
    {
        private readonly SerializadorJson serializador;
        private readonly DataContext dataContext;
        List<Tarefa> tarefas = new List<Tarefa>();
        private int contador = 0;

        public RepositorioTarefa(SerializadorJson serializador, DataContext dataContext)
        {

            this.serializador = serializador;
            this.dataContext = dataContext;

            dataContext.Tarefas.AddRange(serializador.CarregarObjetosDoArquivo().Tarefas);

            if (dataContext.Tarefas.Count > 0)
                contador = dataContext.Tarefas.Max(x => x.Numero);
        }

        public List<Tarefa> SelecionarTarefasConcluidas()
        {
            List<Tarefa> tarefasConcluidas = new List<Tarefa>();

            foreach (var item in dataContext.Tarefas)
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

            foreach (var item in dataContext.Tarefas)
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
            dataContext.Tarefas.Add(tarefa);

            serializador.GravarObjetosEmArquivo(dataContext);

        }

        public void Editar(Tarefa tarefa)
        {
            foreach (var t in dataContext.Tarefas)
            {

                t.Titulo = tarefa.Titulo;
                break;

            }

            serializador.GravarObjetosEmArquivo(dataContext);

        }

        public void Excluir(Tarefa tarefa)
        {

            dataContext.Tarefas.Remove(tarefa);

            serializador.GravarObjetosEmArquivo(dataContext);
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

            serializador.GravarObjetosEmArquivo(dataContext);

        }
    }
}