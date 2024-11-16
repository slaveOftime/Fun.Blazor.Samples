#nowarn "0020"

open System
open Microsoft.Extensions.DependencyInjection
open Microsoft.AspNetCore.Components.WebAssembly.Hosting
open MudBlazor.Services
open FunWasm.MudBlazorDemo

let builder = WebAssemblyHostBuilder.CreateDefault(Environment.GetCommandLineArgs())

builder.AddFunBlazor("#app", app)

builder.Services.AddFunBlazorWasm()
builder.Services.AddMudServices()

builder.Build().RunAsync()
