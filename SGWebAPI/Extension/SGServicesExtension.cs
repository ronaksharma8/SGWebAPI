using SGWebAPI.Services.FileService;
using SGWebAPI.Services.Stock;

namespace SGWebAPI.Extension
{
    public static class SGServicesExtension
    {
        public static IServiceCollection AddSGServices(this IServiceCollection services)
        {
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IStockService, StockService>();
            return services;
        }
    }
}
