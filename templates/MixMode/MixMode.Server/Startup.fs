#nowarn "0020"

open System
open System.Threading.Tasks
open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.DependencyInjection
open MixMode.Server


let builder = WebApplication.CreateBuilder(Environment.GetCommandLineArgs())
let services = builder.Services

services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents()

services.AddFunBlazorServer()


let app = builder.Build()


app.UseBlazorFrameworkFiles($"/{WASM.UrlPath}")
app.UseStaticFiles()

app.MapRazorComponents()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    
app.MapBlazorHub($"/{SERVER.UrlPath}/_blazor")
app.MapFunBlazor($"/{SERVER.UrlPath}", Pages.create PageMode.SERVER)
app.MapFunBlazor($"/{WASM.UrlPath}", Pages.create PageMode.WASM)

app.MapFallback(
    RequestDelegate(fun ctx ->
        ctx.Response.Redirect($"/{WASM.UrlPath}")
        Task.CompletedTask
    )
)


app.Run()
