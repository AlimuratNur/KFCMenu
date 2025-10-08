using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFCMenu.Services
{
    public class JsonDataService
    {
        private readonly string _FilePath;
        
        public JsonDataService(string filePath)
        {
            _FilePath = filePath;
        }

        public Task<string> LoadAsync(string path) 
        {

        }

    }
}
