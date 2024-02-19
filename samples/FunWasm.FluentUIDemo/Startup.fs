#nowarn "0020"

open System
open Microsoft.Extensions.DependencyInjection
open Microsoft.AspNetCore.Components.WebAssembly.Hosting
open Microsoft.FluentUI.AspNetCore.Components
open Fun.Blazor
open FunWasm.FluentUIDemo

let builder = WebAssemblyHostBuilder.CreateDefault(Environment.GetCommandLineArgs())

#if DEBUG
builder.AddFunBlazor("#app", html.hotReloadComp(app, "FunWasm.FluentUIDemo.App.app"))
#else
builder.AddFunBlazor("#app", app)
#endif

builder.Services.AddFunBlazorWasm()
builder.Services.AddFluentUIComponents()

builder.Build().RunAsync()
