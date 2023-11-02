namespace BlazorApp.Components.Pages

open System.Threading.Tasks
open Microsoft.AspNetCore.Components
open Fun.Blazor

[<Route "/">]
[<StreamRendering>]
type Home() as this =
    inherit FunBlazorComponent()

    let mutable isLoading = true

    override _.OnAfterRenderAsync(fisrtRender) = task {
        do! Task.Delay 3000
        isLoading <- false
        this.StateHasChanged()
    }

    override _.Render() = div { if isLoading then "loading ..." else "data is loaded" }
