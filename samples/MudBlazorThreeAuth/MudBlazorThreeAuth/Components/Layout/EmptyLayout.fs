namespace MudBlazorThreeAuth.Components.Layout

open Microsoft.AspNetCore.Components
open MudBlazor
open Fun.Blazor
open Microsoft.AspNetCore.Components.Web

// This can be used for login page etc.
type EmptyLayout() as this =
    inherit LayoutComponentBase()

    let content =
        div.create [|
            // Make those interactive, because by default it is static in this context
            MudThemeProvider'' { renderMode RenderMode.InteractiveAuto }
            MudPopoverProvider'' { renderMode RenderMode.InteractiveAuto }
            MudSnackbarProvider'' { renderMode RenderMode.InteractiveAuto }
            MudDialogProvider'' { renderMode RenderMode.InteractiveAuto }

            main { this.Body }
        |]

    override _.BuildRenderTree(builder) = content.Invoke(this, builder, 0) |> ignore
