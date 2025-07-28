using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Utis_Test.Interfaces;
using Utis_Test.Services;

namespace Utis_Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<IAppDbContext, AppDbContext>();
            builder.Services.AddScoped<ITaskService, TaskService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
