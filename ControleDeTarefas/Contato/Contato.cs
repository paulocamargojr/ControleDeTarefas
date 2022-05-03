using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas.Contato
{
    public class Contato
    {

        public int Numero { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cargo { get; set; }
        public string Empresa { get; set; }

        public Contato()
        {



        }

        public override string ToString()
        {   
            return $"Número: {Numero}, Nome: {Nome}, Email: {Email}, Telefone: {Telefone}, Cargo: {Cargo}, Empresa: {Empresa}";
        }
    }
}
