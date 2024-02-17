namespace FunBlazor.MudBlazorDemo.Client.Pages

open Microsoft.AspNetCore.Components
open Microsoft.AspNetCore.Components.Web
open Fun.Blazor

[<Route "/counter">]
[<FunInteractiveAuto>]
type Counter() =
    inherit FunComponent()

    let mutable count = 0

    override _.Render() =
        html.fragment [|
            PageTitle'() { "Counter" }
            SectionContent'() {
                SectionName "header"
                h1 { "Counter" }
            }
            p { $"Current count: {count}" }
            button {
                style { color "green" }
                on.click (fun _ -> count <- count + 1)
                "Click me"
            }
        |]
