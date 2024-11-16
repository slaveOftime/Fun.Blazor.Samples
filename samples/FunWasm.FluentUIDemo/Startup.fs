﻿#nowarn "0020"

open System
open Microsoft.Extensions.DependencyInjection
open Microsoft.AspNetCore.Components.WebAssembly.Hosting
open Microsoft.FluentUI.AspNetCore.Components
open FunWasm.FluentUIDemo

let builder = WebAssemblyHostBuilder.CreateDefault(Environment.GetCommandLineArgs())

builder.AddFunBlazor("#app", app)

builder.Services.AddFunBlazorWasm()
builder.Services.AddFluentUIComponents()

builder.Build().RunAsync()
