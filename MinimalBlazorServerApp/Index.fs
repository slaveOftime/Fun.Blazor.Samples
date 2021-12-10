namespace Demo

open Fun.Blazor

// page or page2 is just two styles for define Bolero.Node, you can pick one or use both
// page/page2 will be called in Startup.fs
type Index() =
    inherit FunBlazorComponent()

    override _.Render() = app

    // This requires Fun.Blazor.HtmlTemplate
    // You can use VSCode + Ionide-fsharp + Highlight HTML/SQL templates in F#
    // to get intellicense for embeded html
    static member page =
        let root = Bolero.Server.Html.rootComp<Index>
        Template.html
            $"""
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

    // This requires Fun.Blazor.Feliz
    static member page2 =
        html.doctypeHtml [
            html.head [
                html.title "Fun Blazor"
                html.baseUrl "/"
                html.meta [ attr.charsetUtf8 ]
                html.meta [
                    attr.name "viewport"
                    attr.content "width=device-width, initial-scale=1.0"
                ]
            ]
            html.body [
                attr.childContent [
                    Bolero.Server.Html.rootComp<Index>
                    Bolero.Server.Html.boleroScript
                ]
            ]
        ]
