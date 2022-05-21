// hot-reload
// hot-reload is the flag to let cli know this file should be included
// It has dependency requirement: the root is the app which is used in the Startup.fs
// All other files which want have hot reload, need to drill down to that file, and all the middle file should also add the '// hot-reload' flag at the top of taht file
[<AutoOpen>]
module MixMode.Wasm.App

open Microsoft.JSInterop
open FSharp.Data.Adaptive
open Fun.Result
open Fun.Blazor
open Fun.Blazor.Router


let private counter () =
    adaptiview () {
        let! count, setCount = cval(1).WithSetter()
        div { $"Here is the count {count}" }
        button {
            onclick (fun _ -> setCount (count + 1))
            "Increase"
        }
    }


let private sayHi (msg: string) = h1 { "Fun.Blazor: Hi, " + msg }


let private notfound = div { "Content is not found" }


let private modeSwitcher =
    html.comp (fun (hook: IComponentHook, jsRuntime: IJSRuntime) ->
        let isWasm = cval LoadingState<bool>.Loading

        hook.OnFirstAfterRender.Add(fun _ ->
            isWasm.Publish(
                match jsRuntime with
                | :? IJSInProcessRuntime -> true
                | _ -> false
                |> LoadingState.Loaded
            )
        )

        adaptiview () {
            match! isWasm with
            | LoadingState.NotStartYet -> ()
            | LoadingState.Loading -> div { "Loading ..." }
            | LoadingState.Loaded isWasm
            | LoadingState.Reloading isWasm ->
                a {
                    style { displayBlock }
                    href (if isWasm then "/server" else "/wasm")
                    target "_blank"
                    if isWasm then "Goto server mode" else "Go to wasm mode"
                }
        }
    )


let private routes = [ 
    routeCi "/counter" (counter ())
    routeCif "/hi/%s" sayHi
]


let private app =
    div {
        modeSwitcher
        div {
            style { displayFlex; flexDirectionColumn; marginBottom 20 }
            a {
                href "counter"
                "Route to counter"
            }
            a {
                href ""
                "Route to nothing"
            }
            a {
                href "hi/MixMode"
                "Hi MixMode"
            }
        }
        html.route [
            subRouteCi "/wasm" routes
            subRouteCi "/server" routes
            routeAny notfound
        ]
    }


type AppComp() =
    inherit FunBlazorComponent()

    override _.Render() =
//-:cnd:noEmit
#if DEBUG
        html.hotReloadComp (app, "MixMode.Wasm.App.app")
#else
        app
#endif
//+:cnd:noEmit
