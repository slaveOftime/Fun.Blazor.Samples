[<AutoOpen>]
module Demo.App

open FSharp.Data.Adaptive
open Fun.Blazor

let app =
    adaptiview () {
        let! count, setCount = cval(1).WithSetter()

        Template.html
            $"""
            <div class="p-10">
                <div class="p-2 my-5 first-letter:text-2xl first-letter:text-primary-500 text-lg font-bold text-warning-600">Here is the count {count}</div>
                <sl-button type="primary" onclick="{fun _ -> setCount (count + 1)}">Increase</sl-button>
            </div>
            """
    }
