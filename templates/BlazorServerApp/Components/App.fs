namespace BlazorServerApp.Components

open Fun.Blazor
open Microsoft.AspNetCore.Components.Web


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
                HeadOutlet'' { interactiveServer }
            }
            body {
                html.blazor<Routes> (renderMode = RenderMode.InteractiveServer)
                script { src "_framework/blazor.server.js" }
            }
        }
    }
