using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas
{
    [Serializable]
    public class DataContext
    {

        public DataContext()
        {
            Tarefas = new List<Tarefa>();

            Contatos = new List<Contato.Contato>();

            Compromissos = new List<Compromisso.Compromisso>();
        }

        public List<Tarefa> Tarefas { get; set; } 
        public List<Contato.Contato> Contatos { get; set; }
        public List<Compromisso.Compromisso> Compromissos { get; set; }

    }
}
