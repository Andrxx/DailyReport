using Microsoft.EntityFrameworkCore;
using DailyReport.Models;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorPages();

//builder.WebHost.ConfigureKestrel(serverOptions =>
//{
//    serverOptions.ConfigureHttpsDefaults(listenOptions =>
//    {
//        ListenOptions.
//    });
//});

// получаем строку подключения из файла конфигурации
//string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlite(
    builder.Configuration.GetConnectionString("localDb")));


var app = builder.Build();

//app.Map("/", () => "Index Page");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
