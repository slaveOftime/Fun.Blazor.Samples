[<AutoOpen>]
module MinimalBlazorWASMAppWithMudBlazor.Counter

open FSharp.Data.Adaptive
open Fun.Blazor
open MudBlazor


let counter =
    adaptiview () {
        let! count, setCount = cval(1).WithSetter()

        div { $"Here is the count {count}" }
        MudButton'() {
            Color Color.Primary
            Variant Variant.Filled
            OnClick(fun _ -> setCount (count + 1))
            "Increase"
        }
    }