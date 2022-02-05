[<AutoOpen>]
module Demo.App

open FSharp.Data.Adaptive
open Fun.Blazor
open MudBlazor

let app =
    adaptiview () {
        let! count, setCount = cval(1).WithSetter()

        div {
            div { $"Here is the count {count}" }
            MudThemeProvider'()
            MudButton'() {
                Color Color.Primary
                Variant Variant.Filled
                OnClick(fun _ -> setCount (count + 1))
                "Increase"
            }
        }
    }
