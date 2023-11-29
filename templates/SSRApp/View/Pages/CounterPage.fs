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
        html.blazor (ComponentAttrBuilder<Counter>().Add((fun x -> x.init_count), 5))

        h2 { "Use custom element for interactivity" }
        html.customElement (
            ComponentAttrBuilder<Counter>().Add((fun x -> x.init_count), 10),
            preRender = true,
            renderAfter = RenderAfter.Delay 2000,
            preRenderNode = h3 { "Lazy load in 2 secs" }
        )
        h3 {
            hxTrigger' (hxEvt.load, delayMs = 2000)
            hxGetCustomElement (QueryBuilder<Counter>().Add((fun x -> x.init_count), 15))
            hxSwap_outerHTML
            "Lazy load with htmx in 2 secs"
        }
    }
