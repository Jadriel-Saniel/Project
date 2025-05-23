
using Microsoft.EntityFrameworkCore;
using Project.Application.Interfaces;
using Project.Application.Services;
using Project.Infrastructure.Persistence;
using Project.Infrastructure.Repositories;
using System;

namespace Project.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ProjectDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppDbContextConnection")));

            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<CategoryService>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ProductService>();
            builder.Services.AddScoped<IStockRecordRepository, StockRecordRepository>();
            builder.Services.AddScoped<StockRecordService>();
            builder.Services.AddScoped<ISalesHistoryRepository, SalesHistoryRepository>();
            builder.Services.AddScoped<SalesHistoryService>();
            builder.Services.AddScoped<ISalesDetailRepository, SalesDetailRepository>();
            builder.Services.AddScoped<SalesDetailService>();
            builder.Services.AddScoped<IStockRepository, StockRepository>();
            builder.Services.AddScoped<StockService>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
