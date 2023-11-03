namespace BlazorApp.Components.Pages

open Microsoft.AspNetCore.Components
open Microsoft.AspNetCore.Components.Web
open Fun.Blazor

[<Route "/counter">]
[<RenderModeInteractiveServer>]
type Counter() =
    inherit FunComponent()

    let mutable count = 0

    override _.Render() = fragment {
        PageTitle'() { "Counter" }
        h1 { "Counter" }
        p { $"Current count: {count}" }
        button {
            style { color "green" }
            onclick (fun _ -> count <- count + 1)
            "Click me"
        }
    }
