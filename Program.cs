using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using CadastroDeUsuarios.Services;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;
using CadastroDeUsuarios.Data;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7250/") });

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=app.db"));



builder.Services.AddControllers();

// 🔹 Configura o HttpClient para Blazor Server
builder.Services.AddHttpClient<IBGEService>();
builder.Services.AddHttpClient<CidadeService>();
builder.Services.AddHttpClient<ImagesService>();

// 🔹 Registra os serviços necessários para Blazor Server
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


var app = builder.Build();

using (var scope =app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

// 🔹 Configura o pipeline de requisições do Blazor Server
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.MapControllers();

app.Run();
