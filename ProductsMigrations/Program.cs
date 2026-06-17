using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProductsApi.Core.Constants;
using ProductsApi.Modules.Shared.Db;

namespace Migrations;

public class Program
{
    public static async Task Main(string[] args)
    {
        var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        var logger = loggerFactory.CreateLogger<Program>();

        logger.LogInformation("Migration Started...");

        var connectionString = Environment.GetEnvironmentVariable(Config.Envs.Db.Connection);
        if (string.IsNullOrEmpty(connectionString))
        {
            logger.LogWarning("DB Connection String {DbConnection} Is Missing.", Config.Envs.Db.Connection);
            return;
        }

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseNpgsql(connectionString).Options;
        await using var ctx = new AppDbContext(options);
        await ctx.Database.MigrateAsync();
        logger.LogInformation("Migration Succeed.");
    }
}