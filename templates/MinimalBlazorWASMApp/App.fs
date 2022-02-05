[<AutoOpen>]
module Demo.App

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
