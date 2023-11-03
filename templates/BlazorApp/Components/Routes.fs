namespace BlazorApp.Components

open System
open System.Reflection
open Microsoft.AspNetCore.Components.Routing
open Fun.Blazor
open BlazorApp.Components.Layout

type Routes() =
    inherit FunComponent()

    override _.Render() = Router'() {
        AppAssembly(Assembly.GetExecutingAssembly())
        Found(fun routeData -> fragment {
            RouteView'() {
                RouteData routeData
                DefaultLayout typeof<MainLayout>
            }
        })
    }
