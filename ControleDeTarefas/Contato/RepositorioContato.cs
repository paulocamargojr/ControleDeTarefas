using ControleDeTarefas.Compromisso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas.Contato
{
    public class RepositorioContato
    {
        private readonly SerializadorJson serializador;
        List<Contato> contatos = new List<Contato>();
        private int contador = 0;

        public RepositorioContato(SerializadorJson serializador)
        {

            this.serializador = serializador;

            contatos = serializador.CarregarObjetosDoArquivoContato();

            if (contatos.Count > 0)
                contador = contatos.Max(x => x.Numero);
        }

        public List<Contato> SelecionarTodos()
        {

            return contatos;

        }

        public void Inserir(Contato contato)
        {

            foreach (var item in contatos)
            {

                if (contato.Nome == item.Nome || contato.Email == item.Email || contato.Telefone == item.Telefone)
                    return;

            }
            

            contato.Numero = ++contador;
            contatos.Add(contato);

            serializador.GravarObjetosEmArquivoContato(contatos);

        }

        public void Editar(Contato contato)
        {
            foreach (var c in contatos)
            {

                c.Nome = contato.Nome;
                break;

            }

            serializador.GravarObjetosEmArquivoContato(contatos);

        }

        public void Excluir(Contato contato)
        {

            //List<Compromisso.Compromisso> compromissos = new List<Compromisso.Compromisso>();
            //RepositorioCompromisso repositorioCompromisso = new RepositorioCompromisso(serializador);
            //compromissos = repositorioCompromisso.SelecionarTodos();
            //foreach (var item in compromissos)
            //{

            //    if (item.Contato.Nome == contato.Nome)
            //        return false;

            //}
            contatos.Remove(contato);
            serializador.GravarObjetosEmArquivoContato(contatos);
            //return true;
        }

        public bool VerificarContato(string nome)
        {

            foreach (var item in contatos)
            {

                if (nome == item.Nome)
                    return true;

            }
            return false;
        }
    } 
}
