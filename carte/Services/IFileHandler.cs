using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace carte.Services
{
    interface IFileHandler
    {
        public IList<string> ReadFile(string path);
        public Task<IList<string>> SaveFile(IFormFile file, string Path);
        public Task WriteToFile(IList<string> lines, string path, string fileName);

    }
}
