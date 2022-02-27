#nowarn "0020"

open System
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.DependencyInjection
open MudBlazor.Services


let builder = WebApplication.CreateBuilder(Environment.GetCommandLineArgs())

builder.Services.AddControllersWithViews()
builder.Services.AddServerSideBlazor().Services.AddFunBlazorServer().AddMudServices()


let app = builder.Build()

app.UseStaticFiles()

app.MapBlazorHub()

//-:cnd:noEmit
#if DEBUG
app.MapFunBlazor(BlazorWASMAppWithMudBlazor.Server.Index.page, hotReload = true)
#else
app.MapFunBlazor(BlazorWASMAppWithMudBlazor.Server.Index.page)
#endif
//+:cnd:noEmit

app.Run()
