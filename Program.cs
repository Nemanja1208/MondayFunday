
using FluentValidation;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MondayFunday.Database;
using MondayFunday.Services.DummyService;
using MondayFunday.Services.Interfaces;
using MondayFunday.Services.ExternalApiService;
using MondayFunday.Services.OpenAiService;
using MondayFunday.Services.ProductService;
using Scalar.AspNetCore;
using static MondayFunday.Validators.AllValidators;

namespace MondayFunday
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            // Connection string
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
            // Database connection
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddScoped<IDummyInterface, DummyServiceCRUD>();

            builder.Services.AddScoped<IProductInterface, ProductServiceCRUD>();

            // HttpClient for JSONPlaceholder (public external API)
            builder.Services.AddHttpClient<IExternalApiInterface, ExternalApiServiceCRUD>(client =>
            {
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            });

            // HttpClient for OpenAI API
            builder.Services.AddHttpClient<IOpenAiInterface, OpenAiServiceCRUD>();

            builder.Services.AddValidatorsFromAssemblyContaining<ProductValidator>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
