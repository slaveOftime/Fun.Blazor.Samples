[<AutoOpen>]
module Utils

open System.IO
open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Mvc.Rendering
open Microsoft.AspNetCore.Components
open Microsoft.AspNetCore.Components.Routing
open Microsoft.Extensions.DependencyInjection
open Fun.Blazor


type LocalNavigationManager() =
    inherit NavigationManager()

    interface IHostEnvironmentNavigationManager with
        member _.Initialize(_, _) = ()


let writeHtmlTo file (node: NodeRenderFragment) = task {
    let builder = WebApplication.CreateBuilder()
    builder.Services.AddControllersWithViews() |> ignore
    builder.Services.AddScoped<NavigationManager, LocalNavigationManager>() |> ignore

    let ctx = DefaultHttpContext(RequestServices = builder.Services.BuildServiceProvider())
    let! result = ctx.RenderFragment(typeof<FunFragmentComponent>, RenderMode.Static, dict [ "Fragment", box node ])

    do! File.WriteAllTextAsync(file, result)
}
