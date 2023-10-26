#nowarn "0020"

open System
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.DependencyInjection


let builder = WebApplication.CreateBuilder(Environment.GetCommandLineArgs())

builder.Services.AddRazorComponents().AddInteractiveServerComponents()
builder.Services.AddFunBlazorServer()


let app = builder.Build()

app.UseStaticFiles()

app.MapRazorComponents().AddInteractiveServerRenderMode()
app.MapFunBlazor(ServerApp.Index.page)

app.Run()
