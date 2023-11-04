// hot-reload
// hot-reload is the flag to let cli know this file should be included
// It has dependency requirement: the root is the app which is used in the Index.fs
// All other files which want have hot reload, need to drill down to that file, and all the middle file should also add the '// hot-reload' flag at the top of that file
namespace BlazorApp.Components

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
                HeadOutlet'()
            }
            body {
                html.blazor<Routes> ()
                script { src "_framework/blazor.web.js" }
            }
        }
    }
