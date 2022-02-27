open System
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.DependencyInjection


let builder = WebApplication.CreateBuilder(Environment.GetCommandLineArgs())

builder.Services.AddControllersWithViews() |> ignore
builder.Services.AddServerSideBlazor().Services.AddFunBlazorServer() |> ignore


let app = builder.Build()

app.UseStaticFiles() |> ignore

app.MapBlazorHub() |> ignore

//-:cnd:noEmit
#if DEBUG
app.MapFunBlazor(BlazorWASMApp.Server.Index.page, hotReload = true) |> ignore
#else
app.MapFunBlazor(BlazorWASMApp.Server.Index.page) |> ignore
#endif
//+:cnd:noEmit

app.Run()
