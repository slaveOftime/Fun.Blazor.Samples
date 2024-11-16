#nowarn "0020"

open System
open Microsoft.Extensions.DependencyInjection
open Microsoft.AspNetCore.Components.WebAssembly.Hosting
open Radzen
open FunWasm.RadzenDemo

let builder = WebAssemblyHostBuilder.CreateDefault(Environment.GetCommandLineArgs())

builder.AddFunBlazor("#app", app)
builder.Services.AddFunBlazorWasm()
builder.Services.AddRadzenComponents()

builder.Build().RunAsync()
