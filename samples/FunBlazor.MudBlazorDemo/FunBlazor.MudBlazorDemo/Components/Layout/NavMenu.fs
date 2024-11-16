namespace FunBlazor.MudBlazorDemo.Components.Layout

open Microsoft.AspNetCore.Components.Routing
open MudBlazor


type NavMenu =
    static member Create() = MudNavMenu'' {
        MudNavLink'' {
            Href ""
            Match NavLinkMatch.All
            Icon Icons.Material.Filled.Home
            "Home"
        }
        MudNavLink'' {
            Href "counter"
            Match NavLinkMatch.Prefix
            Icon Icons.Material.Filled.Add
            "Counter"
        }
        MudNavLink'' {
            Href "form"
            Match NavLinkMatch.Prefix
            Icon Icons.Material.Filled.List
            "Form demo"
        }
    }
