open System
open Microsoft.Extensions.DependencyInjection
open Microsoft.AspNetCore.Components.WebAssembly.Hosting
open MinimalBlazorWASMApp

let builder = WebAssemblyHostBuilder.CreateDefault(Environment.GetCommandLineArgs())

builder.AddFunBlazor("#app", app).Services.AddFunBlazorWasm() |> ignore

builder.Build().RunAsync() |> ignore
