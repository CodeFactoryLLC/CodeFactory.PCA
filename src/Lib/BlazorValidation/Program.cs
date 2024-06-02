using BlazorValidation;
using BlazorValidation.Components;
using CodeFactory.PCA.Blazor;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTelerikBlazor();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<INotificationService>( sp => new  NotificationService() );
builder.Services.AddScoped<IDialogService>( sp => new DialogService() );

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
