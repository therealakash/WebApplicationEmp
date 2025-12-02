
using Microsoft.EntityFrameworkCore;
using WebApplicationEmpProject.Repositry;
using WebApplicationEmpProject.Services;

namespace WebApplicationEmpProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            
            builder.Services.AddControllers();
            var b = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContext<Appdbcontext>((op)=>op.UseSqlServer(b));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IServices, Servie>();

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
