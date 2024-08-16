namespace MudBlazorThreeAuth.Components.Layout

open Microsoft.AspNetCore.Components.Routing
open Fun.Blazor


[<AutoOpen>]
module Extensions =
    open Fun.Blazor.Operators

    type NavLink' with

        [<CustomOperation "Href">]
        member inline _.Href([<InlineIfLambda>] render: AttrRenderFragment, url: string) = render ==> ("href" => url)


type NavMenu =
    static member Create() = nav {
        style {
            displayFlex
            alignItemsCenter
            gap 10
        }
        childContent [|
            NavLink'() {
                Href ""
                Match NavLinkMatch.All
                "Home"
            }
            NavLink'() {
                Href "counter"
                "Counter"
            }
            NavLink'() {
                Href "data-grid-demo"
                "Data Grid Demo"
            }
            NavLink'() {
                Href "form"
                "Form demo"
            }
        |]
    }
