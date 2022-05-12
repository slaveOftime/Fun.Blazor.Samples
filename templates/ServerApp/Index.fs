namespace ServerApp

open Microsoft.AspNetCore.Mvc.Rendering
open Fun.Blazor


type Index() =
    inherit FunBlazorComponent()

    override _.Render() =
//-:cnd:noEmit
#if DEBUG       
        html.hotReloadComp (ServerApp.App.app, "ServerApp.App.app")
#else
        ServerApp.App.app
#endif
//+:cnd:noEmit

    static member page ctx =
        fragment {
            doctype "html"
            html' {
                head {
                    title { "Fun Blazor" }
                    baseUrl "/"
                    meta { charset "utf-8" }
                    meta {
                        name "viewport"
                        content "width=device-width, initial-scale=1.0"
                    }
                }
                body {
                    rootComp<Index> ctx RenderMode.ServerPrerendered
                    script { src "_framework/blazor.server.js" }
//-:cnd:noEmit
#if DEBUG
                    html.hotReloadJSInterop
#endif
//+:cnd:noEmit
                }
            }
        }
