using dotenv.net;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Shared.Constants;
using Shared.Utils;

namespace Shared.Infrastructure;

public sealed class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        if (!EnvironmentEx.IsRunningInContainer) DotEnv.Load();

        var connectionString = Environment.GetEnvironmentVariable(Config.Envs.Db.Connection);
        if (string.IsNullOrEmpty(connectionString))
            throw new InvalidOperationException();

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseNpgsql(connectionString).Options;
        return new AppDbContext(options);
    }
}