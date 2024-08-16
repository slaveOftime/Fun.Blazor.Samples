namespace MudBlazorThreeAuth.Components.Layout

open Microsoft.AspNetCore.Components
open MudBlazor
open Fun.Blazor

type MainLayout() as this =
    inherit LayoutComponentBase()

    let content = div.create [|
        NavMenu.Create()
        SectionOutlet'() { SectionName "header" }
        MudThemeProvider'.create ()
        MudPopoverProvider'.create ()
        MudSnackbarProvider'.create ()
        MudDialogProvider'.create ()
        main { this.Body }
    |]

    override _.BuildRenderTree(builder) = content.Invoke(this, builder, 0) |> ignore
