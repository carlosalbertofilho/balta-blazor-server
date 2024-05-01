using BlazingShop.Components;
using Microsoft.AspNetCore.HttpsPolicy;


var builder = WebApplication.CreateBuilder(args);
builderAddComponents(builder);

var app = builder.Build();

IsDevelopment(app);

appAddComponents(app);

app.Run();

static void builderAddComponents(WebApplicationBuilder builder)
{
    // Configure o caminho do certificado SSL
    builder.WebHost.UseKestrel(options =>
    {
        options.ListenAnyIP(5001, listenOptions =>
        {
            listenOptions.UseHttps("/workspaces/balta-blazor-server/.aspnet/https/aspnetapp.pfx",
            "SecurePwdGoesHere");
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
    app.UseHttpsRedirection();

    app.UseStaticFiles();
    app.UseAntiforgery();

    app.MapRazorComponents<App>()
        .AddInteractiveServerRenderMode();
}