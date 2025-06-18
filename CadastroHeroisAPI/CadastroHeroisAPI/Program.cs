
using CadastroHeroisAPI.Controllers;
using CadastroHeroisAPI.Data;
using CadastroHeroisAPI.Services.Herois;
using CadastroHeroisAPI.Services.HeroisService;
using Microsoft.EntityFrameworkCore;
using CadastroHeroisAPI.Extensions;


namespace CadastroHeroisAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IHeroisInterface, HeroisService>();
            builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("HeroisDb"));
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", policy =>
                {
                    policy.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });
            //builder.Services.AddDbContext<AppDbContext>(options => 
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            //    );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.CadastroHerois();

            app.UseHttpsRedirection();

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
