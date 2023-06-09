using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using eval_3.Data;

var builder = WebApplication.CreateBuilder(args);

// Configuración del servicio y la cadena de conexión
builder.Services.AddDbContext<DbEvaluacion>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Otros servicios y configuraciones necesarios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
