namespace FunBlazor.MudBlazorDemo.Client.Pages

open Microsoft.AspNetCore.Components
open Microsoft.AspNetCore.Components.Web
open MudBlazor
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
            MudButton'() {
                Color Color.Success
                OnClick(fun _ -> count <- count + 1)
                "Click me"
            }
        |]
