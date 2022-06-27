using AutoMapper;
using FakeItEasy;
using FizzWare.NBuilder;
using SGWebAPI.Services.FileService;
using SGWebAPI.Services.Stock;
using SGWebAPI.Models.Search;
using SGWebAPI.Models;
using SGWebAPI.Core;
using SGWebAPI.Profiles;

namespace SGWebAPI.Test
{
    public class StockServiceTest
    {
        private readonly List<Stock> _fakeStockList = new();
        private IStockService _stockService;
        private IFileService _fileService;
        private IMapper? _mapperService;

        private const string _5HK = "5 HK";
        private const string _11HK = "11 HK";

        [OneTimeSetUp]
        public void Setup()
        {
            _fakeStockList.Add(new Stock
            {
                StockId = Guid.NewGuid(),
                Currency = "HKD",
                Ric = "0434.HK",
                BloomerbergTicket = "434 HK",
                BlommerbergTicketLocal = "434 HK",
                Name = "Boyaa Interactive International Ltd",
                Country = "Hong Kong",
                Price = 500.24
            });

            //configure mapperConfig to use as same as WebAPI
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UserProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            _mapperService = mapper;

            _fileService = A.Fake<IFileService>();
            _stockService = new StockService(_fileService, _mapperService);
        }

        [Test]
        public async Task GetAllStocksAsync_GetAllStock_ShouldReturnListOfStock()
        {
            var param = Builder<StockSearch>.CreateNew()
                          .Build();

            A.CallTo(() => _fileService.ReadFromFileAsync(new CancellationToken())).Returns(_fakeStockList);

            var pagedList = await _stockService.GetAllStocksAsync(param, new CancellationToken());

            Assert.That(pagedList.Items.Count(), Is.EqualTo(1));
        }

        [Test]
        public void CreateOrderAsync_StockCodeWith5HK_ShouldGiveException()
        {
            var param = Builder<CreateOrderRequest>.CreateNew()
                        .With(x => x.OrderType = OrderType.Buy)
                        .With(x => x.StockId = Guid.NewGuid())
                        .With(x => x.StockCode = _5HK)
                        .Build();

            async Task Result() => await _stockService.CreateOrderAsync(param, new CancellationToken());

            Assert.ThrowsAsync<Exception5HK>(Result, $"Cannot execute an order having stock code as {_5HK}");
        }

        [Test]
        public void CreateOrderAsync_StockCodeWith11HK_ShouldGiveException()
        {
            var param = Builder<CreateOrderRequest>.CreateNew()
                        .With(x => x.OrderType = OrderType.Buy)
                        .With(x => x.StockId = Guid.NewGuid())
                        .With(x => x.StockCode = _11HK)
                        .Build();

            async Task Result() => await _stockService.CreateOrderAsync(param, new CancellationToken());

            Assert.ThrowsAsync<Exception11HK>(Result, $"Cannot execute an order having stock code as {_11HK}");
        }

        [Test]
        public async Task CreateOrderAsync_WhenExecutionModeIsMarket_ShouldReturnRandomPositiveOrderPrice()
        {
            var createOrderRequest = Builder<CreateOrderRequest>.CreateNew()
                        .With(x => x.OrderType = OrderType.Buy)
                        .With(x => x.StockId = Guid.NewGuid())
                        .With(x => x.StockCode = "25 HK")
                        .With(x => x.OrderPrice = 25.12)
                        .With(x => x.ExecutionMode = ExecutionMode.Market)
                        .Build();

            var res = await _stockService.CreateOrderAsync(createOrderRequest, new CancellationToken());

            Assert.That(res, Is.InstanceOf<CreateOrderResponse>());
            Assert.Multiple(() =>
            {
                Assert.That(res.OrderPrice, Is.GreaterThan(0.00));
                Assert.That(createOrderRequest.OrderPrice, Is.Not.EqualTo(res.OrderPrice));
            });
        }

        [Test]
        public async Task CreateOrderAsync_WhenExecutionModeIsLimit_ShouldReturnSameOrderPrice()
        {
            var createOrderRequest = Builder<CreateOrderRequest>.CreateNew()
                        .With(x => x.OrderType = OrderType.Buy)
                        .With(x => x.StockId = Guid.NewGuid())
                        .With(x => x.StockCode = "25 HK")
                        .With(x => x.OrderPrice = 25.12)
                        .With(x => x.ExecutionMode = ExecutionMode.Limit)
                        .Build();

            var res = await _stockService.CreateOrderAsync(createOrderRequest, new CancellationToken());

            Assert.That(res, Is.InstanceOf<CreateOrderResponse>());
            Assert.That(res.OrderPrice, Is.EqualTo(createOrderRequest.OrderPrice));
        }
    }
}