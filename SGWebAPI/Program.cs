using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.IdentityModel.Tokens;
using SGWebAPI.Extension;
using SGWebAPI.Models.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSGCors();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddIdentityServer()
    .AddDeveloperSigningCredential()
    .AddInMemoryApiScopes(IdentityServerExtension.ApiScopes)
    .AddInMemoryClients(IdentityServerExtension.Clients);

builder.Services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
            {
                options.Authority = "https://localhost:7010";

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false
                };
            });

//Using IOption pattern binds the configurable data
builder.Services.Configure<DataLocation>(options => builder.Configuration.GetSection("DataLocation").Bind(options));

//register all services for dependency injection
builder.Services.AddSGServices();

var app = builder.Build();

app.UseSGCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseIdentityServer();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
