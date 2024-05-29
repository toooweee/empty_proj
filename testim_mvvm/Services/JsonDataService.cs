using System.IO;
using Newtonsoft.Json;

namespace testim_mvvm.Services
{
    public class JsonDataService
    {
        public T LoadData<T>(string filePath) where T : class
        {
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<T>(jsonData);
            }
            return null;
        }

        public void SaveData<T>(string filePath, T data) where T : class
        {
            string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
        }
    }
}
