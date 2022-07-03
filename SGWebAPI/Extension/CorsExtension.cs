namespace SGWebAPI.Extension
{
    public static class CorsExtension
    {
        private const string PolicyName = "CorsPolicy";

        public static IServiceCollection AddSGCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(PolicyName, builder =>
                {
                    builder
                        .AllowAnyMethod()
                        .AllowAnyHeader()                        
                        .AllowAnyOrigin();
                });
            });
            return services;
        }

        public static IApplicationBuilder UseSGCors(this IApplicationBuilder app)
        {
            app.UseCors(PolicyName);
            return app;
        }
    }
}
