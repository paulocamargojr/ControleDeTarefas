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
        private readonly DataContext dataContext;
        List<Contato> contatos = new List<Contato>();
        private int contador = 0;

        public RepositorioContato(SerializadorJson serializador, DataContext dataContext)
        {

            this.serializador = serializador;
            this.dataContext = dataContext;

            dataContext.Contatos.AddRange(serializador.CarregarObjetosDoArquivo().Contatos);

            if (dataContext.Contatos.Count > 0)
                contador = dataContext.Contatos.Max(x => x.Numero);
        }

        public List<Contato> SelecionarTodos()
        {

            return dataContext.Contatos;

        }

        public void Inserir(Contato contato)
        {

            foreach (var item in dataContext.Contatos)
            {

                if (contato.Nome == item.Nome || contato.Email == item.Email || contato.Telefone == item.Telefone)
                    return;

            }
            

            contato.Numero = ++contador;
            dataContext.Contatos.Add(contato);

            serializador.GravarObjetosEmArquivo(dataContext);

        }

        public void Editar(Contato contato)
        {
            foreach (var c in dataContext.Contatos)
            {

                c.Nome = contato.Nome;
                break;

            }

            serializador.GravarObjetosEmArquivo(dataContext);

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
            dataContext.Contatos.Remove(contato);
            serializador.GravarObjetosEmArquivo(dataContext);
            //return true;
        }

        public bool VerificarContato(string nome)
        {

            foreach (var item in dataContext.Contatos)
            {

                if (nome == item.Nome)
                    return true;

            }
            return false;
        }
    } 
}
