using Babu.DAL;
using Babu.Service.Abstracts;
using Babu.Service.Implements;
using Microsoft.EntityFrameworkCore;
namespace Babu
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddScoped<ICategoriesService,CategoriesService>();
            builder.Services.AddDbContext<BabuDbContext>(s=> s.UseSqlServer(builder.Configuration.GetConnectionString("MSSql")));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
