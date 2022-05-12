#nowarn "0020"

open System
open System.Net.Http
open Microsoft.Extensions.DependencyInjection
open Microsoft.AspNetCore.Components.WebAssembly.Hosting
open Fun.Blazor
open WASMShoelace

let builder = WebAssemblyHostBuilder.CreateDefault(Environment.GetCommandLineArgs())


//-:cnd:noEmit
#if DEBUG
builder.AddFunBlazor("#app", html.hotReloadComp (entry, "WASMShoelace.App.entry"))
#else
builder.AddFunBlazor("#app", entry)
#endif
//+:cnd:noEmit

builder.Services.AddFunBlazorWasm()
builder.Services.AddScoped<HttpClient>(fun _ -> new HttpClient(BaseAddress = Uri builder.HostEnvironment.BaseAddress))

builder.Build().RunAsync()
