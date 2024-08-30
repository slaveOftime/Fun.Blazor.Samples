namespace MudBlazorThreeAuth.Components

open System.Reflection
open Microsoft.AspNetCore.Components.Authorization
open Fun.Blazor
open MudBlazorThreeAuth.Components.Layout

type Routes() =
    inherit FunComponent()

    override _.Render() = Router'() {
        AppAssembly(Assembly.GetExecutingAssembly())
        Found(fun routeData -> AuthorizeRouteView'' {
            RouteData routeData
            DefaultLayout typeof<MainLayout>
        })
    }
