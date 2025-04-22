namespace BlazorServerApp.Components

open System.Reflection
open Fun.Blazor
open BlazorServerApp.Components.Layout

type Routes() =
    inherit FunComponent()

    override _.Render() = Router'' {
        AppAssembly(Assembly.GetExecutingAssembly())
        Found(fun routeData -> RouteView'' {
            RouteData routeData
            DefaultLayout typeof<MainLayout>
        })
    }
