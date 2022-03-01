namespace BlazorWASMAppWithMudBlazor.Server

open Microsoft.AspNetCore.Mvc.Rendering
open Fun.Blazor

type Index() =
    inherit FunBlazorComponent()

    override _.Render() =
//-:cnd:noEmit
#if DEBUG       
        html.hotReloadComp (BlazorWASMAppWithMudBlazor.App.app, "BlazorWASMAppWithMudBlazor.App.app")
#else
        BlazorWASMAppWithMudBlazor.App.app
#endif
//+:cnd:noEmit

    static member page ctx =
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
    <link rel="stylesheet" href="_content/MudBlazor/MudBlazor.min.css" />
</head>

<body>
    {root}
    <script src="_content/MudBlazor/MudBlazor.min.js"></script>
    <script src="_framework/blazor.server.js"></script>
    {hotReload}
</body>

</html>
        """

