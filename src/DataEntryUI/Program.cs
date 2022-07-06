using Blazor.AdminLte;
using DataEntry.Infrastructure;
using DataEntry.Infrastructure.Repository.Interfaces;
using DataEntryUI.Handlers;
using DataEntryUI.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Syncfusion.Blazor;
using Syncfusion.Licensing;
using Toolbelt.Blazor.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddSignalR(e => {
    e.MaximumReceiveMessageSize = 65536;
});
builder.Services.AddAdminLte();
builder.Services.AddTransient<ValidateHeaderHandler>();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, TokenAuthenticationService>();
builder.Services.AddScoped<ILoginServices, TokenAuthenticationService>();
builder.Services.AddHttpClient("DataEntryApi", (sp, client) =>
{
    client.BaseAddress = new Uri(Constants.MainDetails.Api);
    client.EnableIntercept(sp);
});
builder.Services.AddScoped(sp => sp.GetService<IHttpClientFactory>()?.CreateClient("DataEntryApi"));
builder.Services.AddHttpClientInterceptor();
builder.Services.AddScoped<HttpInterceptorService>();

var app = builder.Build();

SyncfusionLicenseProvider.RegisterLicense("NTY0NDkzQDMxMzkyZTM0MmUzMGhUaU5ZczdHMUFkbmZPamhOb0dUZ3prbnVDWXNNYVpKRGhlanE3T3hDYnM9");
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
app.UseAuthentication();
app.UseAuthorization();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
