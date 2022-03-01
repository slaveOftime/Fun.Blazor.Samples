open System
open Microsoft.Extensions.DependencyInjection
open Microsoft.AspNetCore.Components.WebAssembly.Hosting
open MudBlazor.Services
open Fun.Blazor
open BlazorWASMAppWithMudBlazor

let builder = WebAssemblyHostBuilder.CreateDefault(Environment.GetCommandLineArgs())

//-:cnd:noEmit
#if DEBUG
builder.AddFunBlazor("#app", html.hotReloadComp(app, "BlazorWASMAppWithMudBlazor.App.app")) |> ignore
#else
builder.AddFunBlazor("#app", app) |> ignore
#endif
//+:cnd:noEmit

builder.Services.AddFunBlazorWasm().AddMudServices() |> ignore


builder.Build().RunAsync() |> ignore
