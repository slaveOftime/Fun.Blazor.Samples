namespace FSharpUI

open FSharp.Data.Adaptive
open Microsoft.AspNetCore.Components
open Fun.Blazor


module GreatSection =
    let app initCount =
        adaptiview () {
            let! count, setCount = cval(initCount).WithSetter()

            div {
                div { $"Here is the count {count}" }
                button {
                    onclick (fun _ -> setCount (count + 1))
                    "Increase"
                }
            }
        }


type GreatSection() as this =
    inherit FunBlazorComponent()

    [<Parameter>]
    member val InitCount = 0 with get, set

    override _.Render() = GreatSection.app this.InitCount
