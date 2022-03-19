// hot-reload
// hot-reload is the flag to let cli know this file should be included
// It has dependency requirement: the root is the app which is used in the Index.fs
// All other files which want have hot reload, need to drill down to that file, and all the middle file should also add the '// hot-reload' flag at the top of taht file
[<AutoOpen>]
module BlazorServerApp.App

open FSharp.Data.Adaptive
open Fun.Blazor

let app =
    adaptiview () {
        let! count, setCount = cval(1).WithSetter()

        div {
            div { $"Here is the count {count}" }
            button {
                onclick (fun _ -> setCount (count + 1))
                "Increase"
            }
        }
    }
