using System;
using System.IO;
using Lab10.Models;
using Newtonsoft.Json;
using System.Text;

namespace Lab10.Services
{
    class FileIO
    {
        private string path = $"{Environment.CurrentDirectory}\\MainInformList.json";
        public FileIO(string PATH)
        {
            path = PATH;
        }
        /// <summary>
        /// Сохранение
        /// </summary>
        /// <param name="data"></param>
        public void Save(object data)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(data));
        }
        /// <summary>
        /// Чтение данных из файла
        /// </summary>
        /// <returns></returns>
        public Data Load()
        {
            var check = File.Exists(path);
            if (!check)//проверка на существование файла
            {
                File.CreateText(path).Dispose();
                return new Data();
            }
            using (var reader = File.OpenText(path))
            {
                var fileText = reader.ReadToEnd();
                reader.Dispose();
                return JsonConvert.DeserializeObject<Data>(fileText);
            }
        }
    }
}
