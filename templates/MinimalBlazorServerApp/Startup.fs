open System
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.DependencyInjection
open Bolero.Server
open Demo


let builder = WebApplication.CreateBuilder(Environment.GetCommandLineArgs())

builder.Services.AddControllersWithViews() |> ignore
builder.Services.AddServerSideBlazor().Services.AddBoleroHost(true, true).AddFunBlazor() |> ignore


let app = builder.Build()

app.UseStaticFiles() |> ignore

app.MapBlazorHub() |> ignore
app.MapFallbackToBolero(Index.page) |> ignore
    
app.Run()
