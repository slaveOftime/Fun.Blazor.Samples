[<AutoOpen>]
module Demo.App

open FSharp.Data.Adaptive
open Fun.Blazor
open MudBlazor

let app =
    adaptiview () {
        let! count, setCount = cval(1).WithSetter()

        div () {
            childContent [
                div.create $"Here is the count {count}"
                MudButton'() {
                    Color Color.Primary
                    Variant Variant.Filled
                    OnClick(fun _ -> setCount (count + 1))
                    childContent "Increase"
                }
            ]
        }
    }
