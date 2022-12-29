using Blazored.LocalStorage;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using LolExplorer.Data;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using System.Globalization;
using Blazored.Modal;
using LolExplorer.Services;
using LolExplorer.Service;
using LolExplorer.Shared;
using Microsoft.Extensions.Logging;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
//builder.Services.AddScoped<IDataService, DataLocalService>();

builder.Services
.AddBlazorise()
   .AddBootstrapProviders()
   .AddFontAwesomeIcons();
builder.Services.AddHttpClient();



//builder.Services.AddSingleton<IDataAccess, DataAccess>();

// Add the controller of the app
builder.Services.AddControllers();

// Add the localization to the app and specify the resources path
builder.Services.AddLocalization(opts => { opts.ResourcesPath = "Resources"; });


builder.Services.Configure<PositionOptions>(option =>
{
    var positionOptions = builder.Configuration.GetSection(PositionOptions.Position).Get<PositionOptions>();

    option.Name = positionOptions.Name;
    option.Title = positionOptions.Title;
    option.Group= positionOptions.Group;
    option.Year = positionOptions.Year;
    option.Institution = positionOptions.Institution;

});
builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));

// Configure the localtization
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    // Set the default culture of the web site
    options.DefaultRequestCulture = new RequestCulture(new CultureInfo("en-US"));

    // Declare the supported culture
    options.SupportedCultures = new List<CultureInfo> { new CultureInfo("en-US"), new CultureInfo("fr-FR") };
    options.SupportedUICultures = new List<CultureInfo> { new CultureInfo("en-US"), new CultureInfo("fr-FR") };
});
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<IDataService, DataApiService>();
builder.Services.AddBlazoredModal();
var app = builder.Build();

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

// Get the current localization options
var options = ((IApplicationBuilder)app).ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();

if (options?.Value != null)
{
    // use the default localization
    app.UseRequestLocalization(options.Value);
}

// Add the controller to the endpoint
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
