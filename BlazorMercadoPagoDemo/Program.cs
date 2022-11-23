using BlazorMercadoPagoDemo.Data;
using MercadoPago.Config;

MercadoPagoConfig.AccessToken = Environment.GetEnvironmentVariable("MercadoPagoTest");
//MercadoPagoConfig.AccessToken = Environment.GetEnvironmentVariable("MercadoPagoProd");

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IMercadoPagoService, MercadoPagoService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();
