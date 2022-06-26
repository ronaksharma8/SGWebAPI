using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SGWebAPI.Models.Configuration;

namespace SGWebAPI.Services.FileService
{
    public class FileService : IFileService
    {
        private readonly DataLocation _dataLocationConfig;
        public FileService(IOptions<DataLocation> dataLocationConfig)
        {
            _dataLocationConfig = dataLocationConfig.Value;
        }

        public async Task<List<Models.Stock>> ReadFromFileAsync(CancellationToken cancellationToken)
        {
            using (StreamReader r = new StreamReader($"{_dataLocationConfig.FolderLocation}/{_dataLocationConfig.FileName}"))
            {
                string json = await r.ReadToEndAsync();
                return JsonConvert.DeserializeObject<List<Models.Stock>>(json);
            }
        }
    }
}
