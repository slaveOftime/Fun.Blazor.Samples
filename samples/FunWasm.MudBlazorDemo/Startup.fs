#nowarn "0020"

open System
open Microsoft.Extensions.DependencyInjection
open Microsoft.AspNetCore.Components.WebAssembly.Hosting
open MudBlazor.Services
open Fun.Blazor
open FunWasm.MudBlazorDemo

let builder = WebAssemblyHostBuilder.CreateDefault(Environment.GetCommandLineArgs())

#if DEBUG
builder.AddFunBlazor("#app", html.hotReloadComp(app, "FunWasm.MudBlazorDemo.App.app"))
#else
builder.AddFunBlazor("#app", app)
#endif

builder.Services.AddFunBlazorWasm()
builder.Services.AddMudServices()

builder.Build().RunAsync()
