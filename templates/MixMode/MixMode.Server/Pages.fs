namespace MixMode.Server

open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Mvc.Rendering
open Microsoft.AspNetCore.Components.Web
open Fun.Blazor


type PageMode =
    | WASM
    | SERVER

    member this.UrlPath =
        match this with
        | WASM -> "wasm" // This should be synced with the StaticWebAssetBasePath which defined in MixMode.Wasm.fsproj file
        | SERVER -> "server"

    member this.RenderMode =
        match this with
        | SERVER -> RenderMode.ServerPrerendered
        | WASM -> RenderMode.WebAssemblyPrerendered


module Pages =

    let create (mode: PageMode) (_: HttpContext) =

        let blazorJs =
            fragment {
                match mode with
                | SERVER -> script { src "/_framework/blazor.server.js" }
                | WASM -> script { src "_framework/blazor.webassembly.js" }
//-:cnd:noEmit
#if DEBUG
                html.hotReloadJSInterop
#endif
//+:cnd:noEmit
            }

        fragment {
            doctype "html"
            html' {
                head {
                    title { "MixMode" }
                    meta { charset "utf-8" }
                    meta {
                        name "viewport"
                        content "width=device-width, initial-scale=1.0"
                    }
                    link {
                        rel "shortcut icon"
                        type' "image/x-icon"
                        href $"/{PageMode.WASM}/favicon.ico"
                    }
                    baseUrl $"/{mode.UrlPath}/"
                }
                body {
                    
                    match mode with
                    | PageMode.SERVER -> html.blazor<MixMode.Wasm.App.AppComp>(RenderMode.InteractiveServer)
                    | PageMode.WASM -> html.blazor<MixMode.Wasm.App.AppComp>(RenderMode.InteractiveWebAssembly)
                    blazorJs
                }
            }
        }
