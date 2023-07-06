using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MultiTracksAPI.Models;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
builder.Services.AddControllers();
builder.Services.AddDbContext<MultiTracksDBContext>(options =>
            options.UseSqlServer(configuration.GetValue<string>("MultiTracksDatabase:ConnectionStrings")));


builder.Services.AddEndpointsApiExplorer();


builder.Services.AddScoped<DbContext, MultiTracksDBContext>();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger(c =>
    {
        c.RouteTemplate = "api.multitracks.com/{documentname}/swagger.json";

    });
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/api.multitracks.com/v1/swagger.json", "api.multitracks.com");
        c.RoutePrefix = "api.multitracks.com";

    });


}

app.UseHttpsRedirection();

app.MapControllers();

app.UseAuthorization();

app.Run();
