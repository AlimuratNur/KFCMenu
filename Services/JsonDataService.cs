using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using KFCMenu.Models;
using System.Runtime.InteropServices.Marshalling;
using System.IO;
using System.Windows.Markup;
using System.Windows.Documents;

namespace KFCMenu.Services
{
    public class JsonDataService<T>
    {
        private readonly string _FilePath;
        
        public JsonDataService(string filePath)
        {
            _FilePath = filePath;
        }

        public async Task<List<T>> LoadAsync() 
        {
            if (!File.Exists(_FilePath)) return new List<T>();
            using var file = File.OpenRead(_FilePath);
            return await JsonSerializer.DeserializeAsync<List<T>>(file) 
                ?? new List<T>();
        }
    }
}
