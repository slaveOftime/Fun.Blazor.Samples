namespace BlazorApp.Components.Pages

open System.Threading.Tasks
open Microsoft.AspNetCore.Components
open Microsoft.AspNetCore.Components.Web
open Fun.Blazor

[<Route "/">]
[<StreamRendering>]
type Home() as this =
    inherit FunComponent()

    let mutable isLoading = true

    override _.OnInitializedAsync() = task {
        do! Task.Delay 3000
        isLoading <- false
        this.StateHasChanged()
    }

    override _.Render() = fragment {
        PageTitle'() { "Home" }
        div { if isLoading then progress.create () else p { "data is loaded" } }
    }
