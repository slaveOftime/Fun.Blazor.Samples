#nowarn "0020"

open System
open System.Reflection
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.DependencyInjection
open Fun.Blazor

let builder = WebApplication.CreateBuilder(Environment.GetCommandLineArgs())
let services = builder.Services

services.AddRazorComponents().AddInteractiveServerComponents()
services.AddServerSideBlazor(fun x -> x.RootComponents.RegisterCustomElementForFunBlazor(Assembly.GetExecutingAssembly()))
services.AddFunBlazorServer()


let app = builder.Build()

app.UseStaticFiles()
app.UseAntiforgery()

app.MapBlazorSSRComponents(Assembly.GetExecutingAssembly(), enableAntiforgery = true)
app.MapFunBlazorCustomElements(Assembly.GetExecutingAssembly(), enableAntiforgery = true)
app.MapRazorComponents<SSRApp.View.App>().AddInteractiveServerRenderMode()

app.Run()
