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
app.MapFunBlazor(Demo.Index.page1) |> ignore

app.Run()
