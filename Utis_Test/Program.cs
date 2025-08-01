using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Utis_Test.Data;
using Utis_Test.Interfaces;
using Utis_Test.Repositories;
using Utis_Test.Services;

namespace Utis_Test
{
    public class Program
    {
        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();

            builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            builder.Services.AddScoped<ITaskService, TaskService>();
            builder.Services.AddScoped<ITaskRepository, TaskRepository>();

            var conString = builder.Configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(conString));
        }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var logger = app.Services.GetRequiredService<ILogger<Program>>();
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                logger.LogWarning("!!! При первом запуске, когда БД ещё не создана, ниже может возникнуть ошибка" +
                    "\"Microsoft.EntityFrameworkCore.Database.Connection[20004] " +
                    "An error occurred using the connection to database '<db_name>' on server 'tcp://localhost:<db_port>'.\"," +
                    "которая ни на что не влияет. БД создаётся, заполняется, приложение работает. !!!");

                dbContext.Database.Migrate();
            }

            app.UseHttpsRedirection();
            app.MapControllers();

            app.Run();
        }
    }
}
