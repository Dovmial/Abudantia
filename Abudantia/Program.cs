using Abudantia.Components;
using Abudantia.Data;
using Abudantia.Models;
using Abudantia.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);
//"Abudantia"
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<EfContext>(options => options.UseSqlite(connectionString));

builder.Services.AddSingleton<Catalog>();
builder.Services.AddSingleton<Cart>();//TODO: у каждого пользовател€ сво€ корзина должна быть
builder.Services.AddScoped<ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
