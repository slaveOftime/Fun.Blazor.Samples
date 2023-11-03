namespace BlazorApp.Components.Layout

open Microsoft.AspNetCore.Components.Routing
open Fun.Blazor

type NavMenu() =
    inherit FunBlazorComponent()

    override _.Render() = nav {
        style {
            displayFlex
            alignItemsCenter
            gap 10
        }
        NavLink'() {
            href ""
            Match NavLinkMatch.All
            "Home"
        }
        NavLink'() {
            href "counter"
            "Counter"
        }
    }
