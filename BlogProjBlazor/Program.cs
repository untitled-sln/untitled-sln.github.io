using System;
using System.Net.Http;
using BlogProjBlazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
ConfigureServices(builder.Services,builder.HostEnvironment.BaseAddress);
static void ConfigureServices(IServiceCollection services, string baseAddress)
{
    services.AddSingleton<ErrorService>();
    services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(baseAddress) });
    services.AddMudServices();
}

await builder.Build().RunAsync();