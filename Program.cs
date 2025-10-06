using WebGallery.Repositories.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("postgresConfig.json", optional: false)
    .AddJsonFile("databases.json", optional: false);

builder.Services.AddSingleton<StatisticsContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
