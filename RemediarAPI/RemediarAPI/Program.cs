using Microsoft.EntityFrameworkCore;
using RemediarAPI.Context;
using RemediarAPI.Repository.Doacoes;
using RemediarAPI.Repository.Medicamentos;
using RemediarAPI.Repository.MedicamentosDescartados;
using RemediarAPI.Repository.Pedidos;
using RemediarAPI.Repository.Usuario;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IPedidosRepository, PedidosRepository>();
builder.Services.AddScoped<IDoacoesRepository, DoacoesRepository>();
builder.Services.AddScoped<IMedicamentosRepository, MedicamentosRepository>();
builder.Services.AddScoped<IMedicamentosDescartadosRepository, MedicamentosDescartadosRepository>();

builder.Services.AddDbContext<ContextDb>(c => c.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString")));
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
