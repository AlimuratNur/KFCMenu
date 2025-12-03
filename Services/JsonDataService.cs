using System.Text.Json;
using System.IO;


namespace KFCMenu.Services
{
    public  class  JsonDataService<T>
    {
        public async Task<List<T>> LoadAsync(string _FilePath) 
        {
            if (!File.Exists(_FilePath)) return new List<T>();
            using var file = File.OpenRead(_FilePath);
            return await JsonSerializer.DeserializeAsync<List<T>>(file) 
                ?? new List<T>();
        }
    }
}
