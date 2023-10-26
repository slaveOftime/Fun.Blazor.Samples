#nowarn "0020"

open System
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.DependencyInjection
open HtmxApp

let builder = WebApplication.CreateBuilder(Environment.GetCommandLineArgs())
let services = builder.Services

services.AddRazorComponents()
services.AddFunBlazorServer()
services.AddTransient<DbContext>()


let app = builder.Build()

app.UseStaticFiles()
app.MapRazorComponents()

app.MapGet("/blogs", Func<_, _>Blogs.Partial).AddFunBlazor()
app.MapGet("/", Func<_>Blogs.Page).AddFunBlazor()

app.Run()
