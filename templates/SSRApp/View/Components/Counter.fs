namespace SSRApp.View.Components

open Fun.Blazor
open Microsoft.AspNetCore.Components

[<FunBlazorCustomElement(TagName = "ce-counter")>]
type Counter() as this =
    inherit FunComponent()

    let mutable count = 0

    [<Parameter>]
    member val init_count = 0 with get, set

    override _.OnInitialized() = count <- this.init_count

    override _.Render() =
        html.fragment [|
            p { $"Current count: {count}" }
            button {
                onclick (fun _ -> count <- count + 1)
                "Click me"
            }
        |]
