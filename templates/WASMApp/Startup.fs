#nowarn "0020"

open System
open Microsoft.Extensions.DependencyInjection
open Microsoft.AspNetCore.Components.WebAssembly.Hosting
open Fun.Blazor
open WASMApp

let builder = WebAssemblyHostBuilder.CreateDefault(Environment.GetCommandLineArgs())

//-:cnd:noEmit
#if DEBUG
builder.AddFunBlazor("#app", app) //html.hotReloadComp(app, "WASMApp.App.app"))
#else
builder.AddFunBlazor("#app", app)
#endif
//+:cnd:noEmit

builder.Services.AddFunBlazorWasm()

builder.Build().RunAsync()
