using BlazingShop.Components;
using BlazingShop.Data;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builderAddComponents(builder);

var app = builder.Build();

IsDevelopment(app);

appAddComponents(app);

app.Run();

static void builderAddComponents(WebApplicationBuilder builder)
{
    // Add Db Context
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
    // Configure o caminho do certificado SSL
    builder.WebHost.UseKestrel(options =>
    {
        options.ListenAnyIP(5001, listenOptions =>
        {
            //listenOptions.UseHttps("/workspaces/balta-blazor-server/.aspnet/https/aspnetapp.pfx","SecurePwdGoesHere");
            listenOptions.UseHttps("C:\\Users\\solra\\.aspnet\\https\\aspnetapp.pfx", "SecurePwdGoesHere");
        });
    });
    // Add services to the container.
    builder.Services.AddRazorComponents()
        .AddInteractiveServerComponents();
}

static void IsDevelopment(WebApplication app)
{
    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error", createScopeForErrors: true);
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }
}

static void appAddComponents(WebApplication app)
{
    // Configure the HTTP request pipeline.
    app.UseHttpsRedirection();

    app.UseStaticFiles();
    app.UseAntiforgery();

    app.MapRazorComponents<App>()
        .AddInteractiveServerRenderMode();
}