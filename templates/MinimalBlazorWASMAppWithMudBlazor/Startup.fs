open System
open Microsoft.Extensions.DependencyInjection
open Microsoft.AspNetCore.Components.WebAssembly.Hosting
open MudBlazor.Services
open Demo

let builder = WebAssemblyHostBuilder.CreateDefault(Environment.GetCommandLineArgs())

builder.AddFunBlazor("#app", app).Services.AddFunBlazorWasm().AddMudServices() |> ignore

builder.Build().RunAsync() |> ignore
