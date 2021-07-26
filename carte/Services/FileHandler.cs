using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carte.Services
{
    public class FileHandler : IFileHandler
    {
        private readonly IWebHostEnvironment _webHost = null;
        public FileHandler(IWebHostEnvironment webHostEnvironement)
        {
            _webHost = webHostEnvironement;
        }
        public IList<string> ReadFile(string path)
        {
            IList<string> lines = new List<string>();
            using var reader = new StreamReader(path) ;
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line);
            }
            return lines;
        }

        public async Task<IList<string>> SaveFile(IFormFile file, string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string currentMap = Path.Combine(path, file.FileName);
            using var stream = new FileStream(currentMap, FileMode.OpenOrCreate);
            await file.CopyToAsync(stream);
            var result = new List<string>();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    result.Add(reader.ReadLine());
            }
            return result;
        }

        public async Task WriteToFile(IList<string> lines, string path, string fileName)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            await File.WriteAllLinesAsync(Path.Combine(path,fileName), lines);
        }

    }
}
