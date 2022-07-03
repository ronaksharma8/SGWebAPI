using SGWebAPI.Services.FileService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGWebAPI.Models;
using SGWebAPI.Core;
using AutoMapper;
using SGWebAPI.Models.Search;
using SGWebAPI.Models.Paging;
using SGWebAPI.Models.Helper;

namespace SGWebAPI.Services.Stock
{
    public class StockService : IStockService
    {
        private const string _5HK = "5 HK";
        private const string _11HK = "11 HK";

        private readonly IFileService _fileService;
        private readonly IMapper _mapper;

        public StockService(IFileService fileService, IMapper mapper)
        {
            _fileService = fileService;
            _mapper = mapper;
        }

        public async Task<CreateOrderResponse> CreateOrderAsync(CreateOrderRequest createOrderRequest, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
              {
                  //validation here..
                  if (createOrderRequest.StockCode == _5HK)
                  {
                      throw new Exception5HK($"Cannot execute an order having stock code as {_5HK}");
                  }

                  if (createOrderRequest.StockCode == _11HK)
                  {
                      throw new Exception11HK($"Cannot execute an order having stock code as {_11HK}");
                  }

                  //success logic..
                  var res = _mapper.Map<CreateOrderResponse>(createOrderRequest);
                  if (res.ExecutionMode == ExecutionMode.Market)
                  {
                      res.OrderPrice = (double)(new Random().Next()) / 100;
                  }
                  return res;
              }, cancellationToken);
        }

        public async Task<PagedList<Models.Stock>> GetAllStocksAsync(StockSearch param, CancellationToken cancellationToken)
        {
            var lstStocks = await _fileService.ReadFromFileAsync(cancellationToken);
            var lst = lstStocks.ToPagedList(param.PageSize, param.PageNo);
            return lst;
        }
    }
}
