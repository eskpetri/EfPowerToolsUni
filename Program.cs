using EfPowerToolsUni.Controllers;
using EfPowerToolsUni.Models;
using EfPowerToolsUni.Data;
using DateTimeAPI.Converters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Date and Time Converter Needs Converters sub directory classes and namaspace DateTimeAPI.Converters
builder.Services.AddControllers().AddJsonOptions(
    options =>
    {
        options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());  
        options.JsonSerializerOptions.Converters.Add(new TimeOnlyJsonConverter());  
    }
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Context needs to added as service manually in Program.cs
builder.Services.AddDbContext<universityContext>();

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

//app.MapUserEndpoints();

app.Run();
