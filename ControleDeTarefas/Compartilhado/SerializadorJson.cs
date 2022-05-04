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

        private const string path = @"D:\source\repos\ControleDeTarefas\jsonfiles\Arquivo.json";

        
        public DataContext CarregarObjetosDoArquivo()
        {

            if (File.Exists(path) == false)
                return new DataContext();

            string dataContextJson = File.ReadAllText(path);

            JsonSerializerSettings settings = new JsonSerializerSettings();

            settings.Formatting = Formatting.Indented;

            return JsonConvert.DeserializeObject<DataContext>(dataContextJson, settings);

        }

        public void GravarObjetosEmArquivo(DataContext dataContext)
        {

            string jsonObject = JsonConvert.SerializeObject(dataContext);

            File.WriteAllText(path, jsonObject);

        }

    }
}
