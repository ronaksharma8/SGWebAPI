using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGWebAPI.Services.FileService
{
    public interface IFileService
    {
        Task<List<Models.Stock>> ReadFromFileAsync(CancellationToken cancellationToken);
    }
}
