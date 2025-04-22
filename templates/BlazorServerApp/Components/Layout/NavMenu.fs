namespace BlazorServerApp.Components.Layout

open Microsoft.AspNetCore.Components.Routing
open Fun.Blazor


type NavMenu =
    static member Create() = nav {
        style {
            displayFlex
            alignItemsCenter
            gap 10
        }
        NavLink'' {
            href ""
            Match NavLinkMatch.All
            "Home"
        }
        NavLink'' {
            href "counter"
            "Counter"
        }
        NavLink'' {
            href "form"
            "Form demo"
        }
    }
