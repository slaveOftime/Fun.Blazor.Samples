[<AutoOpen>]
module Demo.App

open FSharp.Data.Adaptive
open Fun.Blazor

let app =
    adaptiview () {
        let! count, setCount = cval(1).WithSetter()

        div () {
            childContent [
                div.create $"Here is the count {count}"
                button () {
                    onclick (fun _ -> setCount (count + 1))
                    childContent "Increase"
                }
            ]
        }
    }
