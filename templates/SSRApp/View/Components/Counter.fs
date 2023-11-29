namespace SSRApp.View.Components

open Fun.Blazor
open Microsoft.AspNetCore.Components

[<FunBlazorCustomElement>]
type Counter() as this =
    inherit FunComponent()

    let mutable count = 0

    [<Parameter>]
    member val InitCount = 0 with get, set

    override _.OnInitialized() = count <- this.InitCount

    override _.Render() = fragment {
        p { $"Current count: {count}" }
        button {
            onclick (fun _ -> count <- count + 1)
            "Click me"
        }
    }
