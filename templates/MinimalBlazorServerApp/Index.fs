namespace MinimalBlazorServerApp

open Microsoft.AspNetCore.Mvc.Rendering
open Fun.Blazor

// page or page2 is just two styles for define Bolero.Node, you can pick one or use both
// page/page2 will be called in Startup.fs
type Index() =
    inherit HotReloadComponent("MinimalBlazorServerApp.App.app", app)

    // This requires Fun.Blazor.Feliz
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
                }
            }
        }


    // This requires Fun.Blazor.HtmlTemplate
    // You can use VSCode + Ionide-fsharp + Highlight HTML/SQL templates in F#
    // to get intellicense for embeded html
    static member page2 ctx =
        let root = rootComp<Index> ctx RenderMode.ServerPrerendered
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
</body>
</html>
        """

