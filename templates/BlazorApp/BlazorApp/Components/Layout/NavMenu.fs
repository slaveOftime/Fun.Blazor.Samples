namespace BlazorApp.Components.Layout

open Microsoft.AspNetCore.Components.Routing
open Fun.Blazor


[<AutoOpen>]
module Extensions =
    open Fun.Blazor.Operators

    type NavLink' with

        [<CustomOperation "Href">]
        member inline _.Href([<InlineIfLambda>] render: AttrRenderFragment, url: string) = render ==> ("href" => url)

    let NavLink'' = NavLink'()


type NavMenu =
    static member Create() = nav {
        style {
            displayFlex
            alignItemsCenter
            gap 10
        }
        NavLink'' {
            Href ""
            Match NavLinkMatch.All
            "Home"
        }
        NavLink'' {
            Href "counter"
            "Counter"
        }
        NavLink'' {
            Href "form"
            "Form demo"
        }
    }
