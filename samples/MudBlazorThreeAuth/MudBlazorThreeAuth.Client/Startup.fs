#nowarn "0020"

open System
open Microsoft.AspNetCore.Components.WebAssembly.Hosting

let builder = WebAssemblyHostBuilder.CreateDefault(Environment.GetCommandLineArgs())

builder.Build().RunAsync()
