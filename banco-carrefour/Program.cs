using banco_carrefour.Domain.Entities;
using banco_carrefour.Infrastructure.Repository;
using banco_carrefour.Infrastructure.Repository.Interface;
using banco_carrefour.Infrastructure.Service;
using banco_carrefour.Infrastructure.Service.Interface;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services
    .AddTransient<ILancamentosRepository, LancamentosRepository>()
    .AddTransient<ISaldoConsolidadoService, SaldoConsolidadoService>()
    .AddTransient<ILancamentoService, LancamentoService>()
    .BuildServiceProvider();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Lancamentos", Version = "v1" });

});

//ALIMENTA LISTA DE LANCAMENTOS "FINGINDO" SER CARREGADO DE UMA DB
ListaLancamentos.Lancamentos.Add(new Lancamento { Valor = 50, TipoLancamento = 'd', DataLancamento = DateTime.Now.AddDays(-3) });
ListaLancamentos.Lancamentos.Add(new Lancamento { Valor = 20, TipoLancamento = 'd', DataLancamento = DateTime.Now.AddDays(-3) });
ListaLancamentos.Lancamentos.Add(new Lancamento { Valor = 50, TipoLancamento = 'c', DataLancamento = DateTime.Now.AddDays(-3) });
ListaLancamentos.Lancamentos.Add(new Lancamento { Valor = 20, TipoLancamento = 'd', DataLancamento = DateTime.Now.AddDays(-2) });
ListaLancamentos.Lancamentos.Add(new Lancamento { Valor = 30, TipoLancamento = 'd', DataLancamento = DateTime.Now.AddDays(-2) });
ListaLancamentos.Lancamentos.Add(new Lancamento { Valor = 60, TipoLancamento = 'c', DataLancamento = DateTime.Now.AddDays(-2) });
ListaLancamentos.Lancamentos.Add(new Lancamento { Valor = 60, TipoLancamento = 'd', DataLancamento = DateTime.Now.AddDays(-1) });
ListaLancamentos.Lancamentos.Add(new Lancamento { Valor = 50, TipoLancamento = 'd', DataLancamento = DateTime.Now.AddDays(-1) });
ListaLancamentos.Lancamentos.Add(new Lancamento { Valor = 20, TipoLancamento = 'c', DataLancamento = DateTime.Now.AddDays(-1) });

var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

// Configuração do Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Nome da Sua API V1");
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
