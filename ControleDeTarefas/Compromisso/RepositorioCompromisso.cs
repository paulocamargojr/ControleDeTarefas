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
        List<Compromisso> compromissos = new List<Compromisso>();
        private int contador = 0;

        public RepositorioCompromisso(SerializadorJson serializador)
        {

            this.serializador = serializador;

            compromissos = serializador.CarregarObjetosDoArquivoCompromisso();

            if (compromissos.Count > 0)
                contador = compromissos.Max(x => x.Numero);
        }
        public List<Compromisso> SelecionarTodos()
        {
            
            return compromissos;

        }

        public void Inserir(Compromisso compromisso)
        {

            compromisso.Numero = ++contador;
            compromissos.Add(compromisso);
            serializador.GravarObjetosEmArquivoCompromisso(compromissos);

        }

        public void Editar(Compromisso compromisso)
        {
            foreach (var c in compromissos)
            {

                c.Assunto = compromisso.Assunto;
                break;

            }
            serializador.GravarObjetosEmArquivoCompromisso(compromissos);

        }

        public void Excluir(Compromisso compromisso)
        {

            compromissos.Remove(compromisso);
            serializador.GravarObjetosEmArquivoCompromisso(compromissos);

        }

    }
}
