using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas.Compromisso
{
    public class Compromisso
    {

        //public Contato.Contato contato = new Contato.Contato();
        //
        public Contato.Contato Contato { get; set; }
        public int Numero { get; set; }
        public string Assunto { get; set; }
        public string Local { get; set; }
        public DateTime Data { get; set; }
        public int HoraInicio { get; set; }
        public int HoraTermino { get; set; }

        public Compromisso()
        {

        }

        public override string ToString()
        {
            if(Contato == null)
            {

                return $"Número: {Numero}, Assunto: {Assunto}, Local: {Local}, Data: {Data}, \n" +
               $" Hora de inicio: {HoraInicio}, Hora de término: {HoraTermino}";

            }

            return $"Número: {Numero}, Contato: {Contato.Nome} Assunto: {Assunto}, Local: {Local}, Data: {Data}, \n" +
               $" Hora de inicio: {HoraInicio}, Hora de término: {HoraTermino}";

        }

    }
}
