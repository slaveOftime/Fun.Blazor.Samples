namespace BlazorApp.Components.Pages

open Microsoft.AspNetCore.Components
open Microsoft.AspNetCore.Components.Web
open Fun.Blazor

[<Route "/counter">]
[<RenderModeInteractiveServer>]
type Counter() as this =
    inherit FunBlazorComponent()

    let mutable count = 0

    do this.DisableEventTriggerStateHasChanged <- false

    override _.Render() = fragment {
        h1 { "Counter" }
        p {
            "role", "status"
            $"Current count: {count}"
        }
        button {
            class' "btn btn-primary"
            onclick (fun _ -> count <- count + 1)
            "Click me"
        }
    }
