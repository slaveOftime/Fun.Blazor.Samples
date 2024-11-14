namespace SSRApp.View.Pages

open Microsoft.AspNetCore.Components
open Microsoft.AspNetCore.Components.Web
open Fun.Htmx
open Fun.Blazor
open SSRApp.View.Components

[<Route "/form">]
type Form() =
    inherit FunComponent()

    override _.Render() = fragment {
        PageTitle'' { "Form demo" }
        SectionContent'' {
            SectionName "header"
            h1 { "Form demo" }
        }
        section {
            hxTrigger' hxEvt.load
            hxGetComponent typeof<Login>
            hxSwap_outerHTML
            "Loading login page..."
        }
    }
