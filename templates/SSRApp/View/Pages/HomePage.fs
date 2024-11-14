namespace SSRApp.View.Pages

open Microsoft.AspNetCore.Components
open Microsoft.AspNetCore.Components.Web
open Fun.Htmx
open Fun.Blazor
open SSRApp.View.Components

[<Route "/">]
type Home() =
    inherit FunComponent()

    override _.Render() = fragment {
        PageTitle'' { "Home" }
        SectionContent'' {
            SectionName "header"
            h1 { "Home" }
        }
        section {
            hxGetComponent typeof<OrderList>
            hxTrigger' hxEvt.intersect
            "Loading order list ..."
        }
    }
