open System
open Microsoft.Extensions.DependencyInjection
open Microsoft.AspNetCore.Components.WebAssembly.Hosting
open Fun.Blazor
open Demo

let builder = WebAssemblyHostBuilder.CreateDefault(Environment.GetCommandLineArgs())

builder.AddFunBlazorNode("#app", app).Services.AddFunBlazor() |> ignore

builder.Build().RunAsync() |> ignore
