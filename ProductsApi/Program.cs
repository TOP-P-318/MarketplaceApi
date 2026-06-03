using ProductsApi.Modules.Products.Domain.Mappers;

namespace ProductsApi;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        #region Services

        builder.Services.AddControllers();
        builder.Services.AddAuthorization();

        #endregion

        #region API Docs

        builder.Services.AddOpenApi();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        #endregion

        #region DI

        #region Mappers

        builder.Services.AddSingleton<IProductMapper, ProductMapper>();

        #endregion

        #endregion

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
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