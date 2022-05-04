using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas.Compromisso
{
    public class RepositorioCompromisso
    {
        private readonly SerializadorJson serializador;
        private readonly DataContext dataContext;
        List<Compromisso> compromissos = new List<Compromisso>();
        private int contador = 0;

        public RepositorioCompromisso(SerializadorJson serializador, DataContext dataContext)
        {

            this.serializador = serializador;
            this.dataContext = dataContext;

            dataContext.Compromissos.AddRange(serializador.CarregarObjetosDoArquivo().Compromissos);

            if (dataContext.Compromissos.Count > 0)
                contador = dataContext.Compromissos.Max(x => x.Numero);
        }
        public List<Compromisso> SelecionarTodos()
        {
            
            return dataContext.Compromissos;

        }

        public void Inserir(Compromisso compromisso)
        {

            compromisso.Numero = ++contador;
            dataContext.Compromissos.Add(compromisso);
            serializador.GravarObjetosEmArquivo(dataContext);

        }

        public void Editar(Compromisso compromisso)
        {
            foreach (var c in dataContext.Compromissos)
            {

                c.Assunto = compromisso.Assunto;
                break;

            }
            serializador.GravarObjetosEmArquivo(dataContext);

        }

        public void Excluir(Compromisso compromisso)
        {

            dataContext.Compromissos.Remove(compromisso);
            serializador.GravarObjetosEmArquivo(dataContext);

        }

    }
}
