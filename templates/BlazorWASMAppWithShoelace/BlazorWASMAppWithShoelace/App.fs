// hot-reload
// hot-reload is the flag to let cli know this file should be included
// It has dependency requirement: the root is the app which is used in the Startup.fs
// All other files which want have hot reload, need to drill down to that file, and all the middle file should also add the '// hot-reload' flag at the top of taht file
[<AutoOpen>]
module BlazorWASMAppWithShoelace.App

open FSharp.Data.Adaptive
open Fun.Blazor


let welcome =
    Static.html """
        <p class="text-pink-600 text-xl font-semibold">Welcome to Fun.Blazor demo app!!!</p>
    """


let app =
    adaptiview () {
        let! count, setCount = cval(1).WithSetter()

        Template.html $"""
            <div class="p-10">
                {welcome}
                <div class="p-2 my-5 first-letter:text-2xl first-letter:text-pink-600 text-lg font-bold text-warning-600">Here is the count {count}</div>
                <sl-button type="primary" onclick="{fun _ -> setCount (count + 1)}">Increase</sl-button>
                <sl-range value="{count}" onsl-change="{callback (fun (e: SlChangeEventArgs) -> e.Value |> string |> int |> setCount)}"></sl-range>
            </div>
        """
    }


let entry =
    fragment {
        app
        jsInterops
//-:cnd:noEmit
#if DEBUG
        html.hotReloadJSInterop
#endif
//+:cnd:noEmit
    }
