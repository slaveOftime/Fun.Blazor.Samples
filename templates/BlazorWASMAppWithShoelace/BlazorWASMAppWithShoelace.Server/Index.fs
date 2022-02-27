namespace BlazorWASMAppWithShoelace.Server

open Microsoft.AspNetCore.Mvc.Rendering
open Fun.Blazor


type Index() =

    //-:cnd:noEmit
#if DEBUG
    inherit HotReloadComponent("BlazorWASMAppWithShoelace.App.app", BlazorWASMAppWithShoelace.App.app)
#else
    inherit FunBlazorComponent()
    override _.Render() = BlazorWASMAppWithShoelace.App.app
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
<html class="bg-neutral-50 dark:bg-neutral-1000">

<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <title>Fun Blazor</title>
    <base href="/" />
    <link rel="stylesheet" media="(prefers-color-scheme:light)"
        href="https://cdn.jsdelivr.net/npm/@shoelace-style/shoelace@2.0.0-beta.62/dist/themes/light.css">
    <link rel="stylesheet" media="(prefers-color-scheme:dark)"
        href="https://cdn.jsdelivr.net/npm/@shoelace-style/shoelace@2.0.0-beta.62/dist/themes/dark.css"
        onload="document.documentElement.classList.add('sl-theme-dark');">
    <link href="app-generated.css" rel="stylesheet">
</head>

<body>
    {root}
    <script src="_framework/blazor.server.js"></script>
    <script type="module" src="https://cdn.jsdelivr.net/npm/@shoelace-style/shoelace@2.0.0-beta.62/dist/shoelace.js"></script>
    {hotReload}
</body>

</html>
        """
