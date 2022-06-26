using SGWebAPI.Models;
using SGWebAPI.Models.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGWebAPI.Services.Stock
{
    public interface IStockService
    {
        Task<IEnumerable<Models.Stock>> GetAllStocksAsync(StockSearch param, CancellationToken cancellationToken);

        Task<CreateOrderResponse> CreateOrderAsync(CreateOrderRequest createOrderRequest, CancellationToken cancellationToken);
    }
}
