using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shared.Constants;
using Shared.Infrastructure;

namespace Migrations;

public class Program
{
    public static async Task Main(string[] args)
    {
        var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        var logger = loggerFactory.CreateLogger<Program>();

        logger.LogInformation("Migration Started...");

        var dbCtxFactory = new AppDbContextFactory();
        await using var ctx = dbCtxFactory.CreateDbContext(args);
        await ctx.Database.MigrateAsync();
        logger.LogInformation("Migration Succeed.");
    }
}