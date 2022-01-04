open System
open Microsoft.Extensions.DependencyInjection
open Microsoft.AspNetCore.Components.WebAssembly.Hosting
open MudBlazor.Services
open Demo

let builder = WebAssemblyHostBuilder.CreateDefault(Environment.GetCommandLineArgs())

builder.AddFunBlazorNode("#app", app).Services.AddFunBlazor().AddMudServices() |> ignore

builder.Build().RunAsync() |> ignore
