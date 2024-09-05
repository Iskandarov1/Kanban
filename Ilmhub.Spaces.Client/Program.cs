using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Ilmhub.Spaces.Client;
using Microsoft.FluentUI.AspNetCore.Components;
using Ilmhub.Spaces.Client.Services;
using Microsoft.FluentUI.AspNetCore.Components.Components.Tooltip;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddFluentUIComponents();

// Register the new services
builder.Services.AddScoped<ITooltipService, TooltipService>();
builder.Services.AddScoped<ICourseDataService, CourseDataService>();
builder.Services.AddScoped<ILeadDataService, LeadDataService>();

await builder.Build().RunAsync();