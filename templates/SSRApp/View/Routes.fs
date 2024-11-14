namespace SSRApp.View

open System.Reflection
open Fun.Blazor
open SSRApp.View.Layout

type Routes() =
    inherit FunComponent()

    override _.Render() = Router'' {
        AppAssembly(Assembly.GetExecutingAssembly())
        Found(fun routeData -> RouteView'' {
            RouteData routeData
            DefaultLayout typeof<MainLayout>
        })
    }
