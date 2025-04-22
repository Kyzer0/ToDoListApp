
using Scalar.AspNetCore;
using Services.BussinessLogicFolder;
using ToDoListApp.Dto_s;
using ToDoListApp.Models;
using ToDoListApp.Services.InterfaceFolder;

namespace ToDoListApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<TodoItemDtoLogic>();
            builder.Services.AddSingleton<ITodoInterface<TodoItem>, TodoBussinessLogic>();
            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddControllers()

            //remove all null values
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
            });

            builder.Services.AddOpenApiDocument();
            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseOpenApi();
                app.UseSwaggerUi();
;            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
