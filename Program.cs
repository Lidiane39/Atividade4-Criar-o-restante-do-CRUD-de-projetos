using Exo.WebApi.Contexts;
using Exo.WebApi.Repositories;
using Microsoft.EntityFrameworkCore; // Adicionado para habilitar o .UseSqlServer

var builder = WebApplication.CreateBuilder(args);

// 1. Pega a String de Conexão do appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. Registra o ExoContext configurando-o para usar o SQL Server
builder.Services.AddDbContext<ExoContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();

// Mantém o seu repositório registrado
builder.Services.AddTransient<ProjetoRepository, ProjetoRepository>();

var app = builder.Build();

app.UseRouting();
app.MapControllers(); // Substitui todo o bloco app.UseEndpoints(...)

app.Run();