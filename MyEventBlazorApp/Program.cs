using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MyEventBlazorApp.Data;
using MyEventBlazorApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

string apiUrl = builder.Configuration["ApiUrl"];

builder.Services.AddHttpClient<IEventsService, EventsService>(httpClient =>
{
    httpClient.BaseAddress = new Uri($"{apiUrl}");
});

builder.Services.AddHttpClient<IUserProfileService, UserProfileService>(httpClient =>
{
    httpClient.BaseAddress = new Uri($"{apiUrl}");
});



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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
