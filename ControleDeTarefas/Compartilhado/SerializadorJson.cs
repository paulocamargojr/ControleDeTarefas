using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas
{
    public class SerializadorJson
    {

        private const string pathTarefa = @"D:\source\repos\ControleDeTarefas\jsonfiles\tarefas.json";
        private const string pathContato = @"D:\source\repos\ControleDeTarefas\jsonfiles\contatos.json";
        private const string pathCompromisso = @"D:\source\repos\ControleDeTarefas\jsonfiles\compromissos.json";

        public List<Tarefa> CarregarObjetosDoArquivoTarefa()
        {

            if (File.Exists(pathTarefa) == false)
                return new List<Tarefa>();

            string tarefasJson = File.ReadAllText(pathTarefa);

            JsonSerializerSettings settings = new JsonSerializerSettings();

            settings.Formatting = Formatting.Indented;

            return JsonConvert.DeserializeObject<List<Tarefa>>(tarefasJson, settings);

        }

        public void GravarObjetosEmArquivoTarefa(List<Tarefa> tarefa)
        {
            
            string jsonObject = JsonConvert.SerializeObject(tarefa);

            File.WriteAllText(pathTarefa, jsonObject);

        }

        public List<Contato.Contato> CarregarObjetosDoArquivoContato()
        {

            if (File.Exists(pathContato) == false)
                return new List<Contato.Contato>();

            string contatosJson = File.ReadAllText(pathContato);

            JsonSerializerSettings settings = new JsonSerializerSettings();

            settings.Formatting = Formatting.Indented;

            return JsonConvert.DeserializeObject<List<Contato.Contato>>(contatosJson, settings);

        }

        public void GravarObjetosEmArquivoContato(List<Contato.Contato> contato)
        {

            string jsonObject = JsonConvert.SerializeObject(contato);

            File.WriteAllText(pathContato, jsonObject);

        }

        public List<Compromisso.Compromisso> CarregarObjetosDoArquivoCompromisso()
        {

            if (File.Exists(pathCompromisso) == false)
                return new List<Compromisso.Compromisso>();

            string compromissosJson = File.ReadAllText(pathCompromisso);

            JsonSerializerSettings settings = new JsonSerializerSettings();

            settings.Formatting = Formatting.Indented;

            return JsonConvert.DeserializeObject<List<Compromisso.Compromisso>>(compromissosJson, settings);

        }

        public void GravarObjetosEmArquivoCompromisso(List<Compromisso.Compromisso> compromisso)
        {

            string jsonObject = JsonConvert.SerializeObject(compromisso);

            File.WriteAllText(pathCompromisso, jsonObject);

        }

    }
}
