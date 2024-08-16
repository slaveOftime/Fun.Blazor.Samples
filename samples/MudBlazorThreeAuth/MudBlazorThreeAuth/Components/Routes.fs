namespace MudBlazorThreeAuth.Components

open System.Reflection
open Microsoft.AspNetCore.Components.Authorization
open Fun.Blazor
open MudBlazorThreeAuth.Components.Layout

type Routes() =
    inherit FunComponent()

    override _.Render() = Router'() {
        AppAssembly(Assembly.GetExecutingAssembly())
        Found(fun routeData ->
            html.blazor (
                ComponentAttrBuilder<AuthorizeRouteView>()
                    .Add((fun x -> x.RouteData), routeData)
                    .Add((fun x -> x.DefaultLayout), typeof<MainLayout>)
            )
        )
    }
