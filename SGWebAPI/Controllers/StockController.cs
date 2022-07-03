using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGWebAPI.Models;
using SGWebAPI.Models.Paging;
using SGWebAPI.Models.Search;
using SGWebAPI.Services.Stock;

namespace SGWebAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet]
        public async Task<PagedList<Stock>> GetStocksAsync([FromQuery] StockSearch param, CancellationToken cancellationToken = default)
        {
            return await _stockService.GetAllStocksAsync(param, cancellationToken);
        }

        [HttpPost]
        public async Task<CreateOrderResponse> CreateOrder(CreateOrderRequest createOrderRequest, CancellationToken cancellationToken = default)
        {
            var res = await _stockService.CreateOrderAsync(createOrderRequest, cancellationToken);
            return res;
        }
    }
}
