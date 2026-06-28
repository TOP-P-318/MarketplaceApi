using dotenv.net;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Shared.Constants;
using Shared.Infrastructure;
using Shared.Users;
using Shared.Utils;
using UsersApi.Auth;

namespace UsersApi;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        if (!EnvironmentEx.IsRunningInContainer)
        {
            DotEnv.Load();
            builder.Configuration.AddEnvironmentVariables();
        }

        builder.Services.AddControllers();
        builder.Services.AddCookieAuthentication();
        builder.Services.AddAuthorization();

        builder.Services.AddOpenApi();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(
            new NpgsqlDataSourceBuilder(builder.Configuration[Config.Envs.Db.Connection])
                .EnableDynamicJson()
                .Build()
        ));

        builder.Services.AddScoped<UsersRepo>();
        builder.Services.AddSingleton<UserMapper>();

        builder.Services.AddScoped<UsersService>();
        builder.Services.AddSingleton<PasswordHasher<UserModel>>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();

        await app.RunAsync();
    }
}