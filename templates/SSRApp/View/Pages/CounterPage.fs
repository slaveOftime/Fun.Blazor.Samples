namespace SSRApp.View.Pages

open Microsoft.AspNetCore.Components
open Microsoft.AspNetCore.Components.Web
open Fun.Htmx
open Fun.Blazor
open SSRApp.View.Components

[<Route "/counter">]
type CounterPage() =
    inherit FunComponent()

    override _.Render() = fragment {
        PageTitle'() { "Counter" }
        SectionContent'() {
            SectionName "header"
            h1 { "Counter" }
        }

        h2 { "Prerendered for readonly" }
        html.blazor (ComponentAttrBuilder<Counter>().Add((fun x -> x.InitCount), 5))

        h2 { "Use custom element for interactivity" }
        div {
            hxGetCustomElement (QueryBuilder<Counter>().Add((fun x -> x.InitCount), 8))
            hxTrigger' (hxEvt.load, delayMs = 2000)
        }
        html.customElement (ComponentAttrBuilder<Counter>().Add((fun x -> x.InitCount), 10))
    }
