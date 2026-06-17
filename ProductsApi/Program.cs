using dotenv.net;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Core.Constants;
using ProductsApi.Core.Infrastructure.Db.Mappers;
using ProductsApi.Core.Utils;
using ProductsApi.Modules.Products.Db.Entities;
using ProductsApi.Modules.Products.Db.Mappers;
using ProductsApi.Modules.Products.Db.Repos;
using ProductsApi.Modules.Products.Domain.Models;
using ProductsApi.Modules.Products.Services;
using ProductsApi.Modules.Shared.Db;

namespace ProductsApi;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        if (builder.Environment.IsLocal())
        {
            DotEnv.Load();
            builder.Configuration.AddEnvironmentVariables();
        }

        #region Services

        builder.Services.AddControllers();
        builder.Services.AddAuthorization();

        #endregion

        #region API Docs

        builder.Services.AddOpenApi();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        #endregion

        #region Db

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(builder.Configuration[Config.Envs.Db.Connection])
        );

        #endregion

        #region Services DI

        builder.Services.AddScoped<IProductsService, ProductsService>();

        #endregion

        #region Repos DI

        builder.Services.AddScoped<IProductsRepo, ProductsRepo>();

        #endregion

        #region Mappers DI

        builder.Services.AddSingleton<IMapper<ProductModel, ProductEntity>, ProductMapper>();

        #endregion

        var app = builder.Build();

        if (app.Environment.IsDevelopment() ||
            app.Environment.IsLocal())
        {
            app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.MapControllers();
        app.UseAuthorization();

        await app.RunAsync();
    }
}