using PortoAPI.Models;
using PortoAPI.Services.Implementacoes;
using PortoAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PortoApiDbContext>();
builder.Services.AddTransient<IRelatorioService, RelatorioService>();
builder.Services.AddTransient<IMovimentacaoService, MovimentacaoService>();
builder.Services.AddTransient<IContainerService, ContainerService>();
builder.Services.AddTransient<INumeroDeContainerService, NumeroDeContainer>();

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
