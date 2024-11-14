[<AutoOpen>]
module WASMApp.App

open FSharp.Data.Adaptive
open Fun.Blazor

let app = adapt {
    let amount = 1
    let! count, setCount = cval(1).WithSetter()

    div {
        div { $"Here is the count {count}" }
        button {
            onclick (fun _ -> setCount (count + amount))
            "Increase by "; amount
        }
    }
}
