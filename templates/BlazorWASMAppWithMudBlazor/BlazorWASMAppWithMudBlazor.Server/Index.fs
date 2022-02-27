namespace BlazorWASMAppWithMudBlazor.Server

open Microsoft.AspNetCore.Mvc.Rendering
open Fun.Blazor

type Index() =

//-:cnd:noEmit
#if DEBUG
    inherit HotReloadComponent
        (
            "BlazorWASMAppWithMudBlazor.App.app",
            BlazorWASMAppWithMudBlazor.App.app,
            staticAssetsDir = __SOURCE_DIRECTORY__ + "/../BlazorWASMAppWithMudBlazor/wwwroot"
        )
#else
    inherit FunBlazorComponent()
    override _.Render() = BlazorWASMAppWithMudBlazor.App.app
#endif
//+:cnd:noEmit

    static member page ctx =
        let root = rootComp<Index> ctx RenderMode.ServerPrerendered

        let hotReload =
//-:cnd:noEmit
#if DEBUG
            hotReloadJSInterop
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

