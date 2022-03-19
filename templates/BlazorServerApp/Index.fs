namespace BlazorServerApp

open Microsoft.AspNetCore.Mvc.Rendering
open Fun.Blazor

// page or page2 is just two styles for define blazor node, you can pick anyone
// page/page2 will be called in Startup.fs
type Index() =
    inherit FunBlazorComponent()

    override _.Render() =
//-:cnd:noEmit
#if DEBUG       
        html.hotReloadComp (BlazorServerApp.App.app, "BlazorServerApp.App.app")
#else
        BlazorServerApp.App.app
#endif
//+:cnd:noEmit

    static member page1 ctx =
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


    // This requires Fun.Blazor.HtmlTemplate
    // You can use VSCode + Ionide-fsharp + Highlight HTML/SQL templates in F#
    // to get intellicense for embeded html
    static member page2 ctx =
        let root = rootComp<Index> ctx RenderMode.ServerPrerendered

        let hotReload =
//-:cnd:noEmit
#if DEBUG
            html.hotReloadJSInterop
#else
            html.none
#endif     
//+:cnd:noEmit

        Template.html $"""
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <title>Fun Blazor</title>
    <base href="/" />
</head>
<body>
    {root}
    <script src="_framework/blazor.server.js"></script>
    {hotReload}
</body>
</html>
        """

