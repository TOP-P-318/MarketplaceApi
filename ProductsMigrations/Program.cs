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

        logger.LogInformation("Products DB Migration Started...");
        
        logger.LogInformation("Extracting Products DB Connection String From Environment {DbConnection}...", Config.Db.Connection);
        var connectionString = Environment.GetEnvironmentVariable(Config.Db.Connection);
        if (string.IsNullOrEmpty(connectionString))
        {
            logger.LogWarning("Products DB Connection String {DbConnection} Is Missing.", Config.Db.Connection);
            return;
        }
        logger.LogInformation("Products DB Connection String Extracted Successfully.");
      
        logger.LogInformation("Connecting To Products DB...");
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseNpgsql(connectionString).Options;
        await using var ctx = new AppDbContext(options);
        logger.LogInformation("Connection Successful.");
        
        logger.LogInformation("Migrating Products DB...");
        await ctx.Database.MigrateAsync();
        logger.LogInformation("Migration Successful.");
        
        logger.LogInformation("Products DB Migration Finished Successfully.");
    }
}