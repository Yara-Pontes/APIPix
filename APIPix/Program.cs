using APIPix.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Configurar o HttpClient para a API do Banco Inter
builder.Services.AddHttpClient<BancoInterService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["BancoInter:ApiBaseUrl"]);
});

builder.Services.AddScoped<BancoInterService>(); // Adiciona o serviço ao contêiner de injeção de dependência

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
