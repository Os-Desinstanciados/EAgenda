using EAgenda.WebApp.Compartilhado.Aplicacao;
using EAgenda.WebApp.Compartilhado.Apresentacao;
using EAgenda.WebApp.Compartilhado.Infra;

var builder = WebApplication.CreateBuilder(args);

// Configuração do container de injeção de dependência
builder.Services.AddInfraRepositories(builder.Configuration);

builder.Services.AddApplicationServices(builder.Configuration, builder.Logging);

builder.Services.AddPresentationConfig(builder.Configuration);

var app = builder.Build();

// Middlewares de roteamento
app.UseRouting();
app.MapDefaultControllerRoute();

// Execução do Servidor
app.Run();