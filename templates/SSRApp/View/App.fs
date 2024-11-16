namespace SSRApp.View

open Microsoft.AspNetCore.Components.Web
open Fun.Blazor


type App() =
    inherit FunComponent()

    override _.Render() = fragment {
        doctype "html"
        html' {
            lang "EN"
            head {
                baseUrl "/"
                meta { charset "utf-8" }
                meta {
                    name "viewport"
                    content "width=device-width, initial-scale=1.0"
                }
                link {
                    rel "icon"
                    type' "image/png"
                    href "favicon.png"
                }
                styleElt {
                    ruleset ".active" {
                        color "green"
                        fontWeightBold
                    }
                }
                HeadOutlet''
                CustomElement.lazyBlazorJs ()
            }
            body {
                html.blazor<Routes> ()
                script { src "https://unpkg.com/htmx.org@1.9.9" }
            }
        }
    }
