#nowarn "0020"

open System
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.DependencyInjection
open MudBlazor.Services
open MudBlazorThreeAuth.Components
open MudBlazorThreeAuth.Client.Pages

let builder = WebApplication.CreateBuilder(Environment.GetCommandLineArgs())

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents()
    
builder.Services.AddFunBlazorServer()
builder.Services.AddMudServices()


let app = builder.Build()

app.UseStaticFiles()
app.UseAntiforgery()

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof<Counter>.Assembly);

app.Run()
