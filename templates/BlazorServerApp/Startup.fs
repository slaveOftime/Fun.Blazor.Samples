#nowarn "0020"

open System
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.DependencyInjection
open BlazorServerApp.Components

let builder = WebApplication.CreateBuilder(Environment.GetCommandLineArgs())

builder.Services.AddRazorComponents().AddInteractiveServerComponents()

builder.Services.AddFunBlazorServer()


let app = builder.Build()

app.UseHttpsRedirection()
app.UseStaticFiles()
app.UseAntiforgery()

app.MapRazorComponents<App>().AddInteractiveServerRenderMode()

app.Run()
