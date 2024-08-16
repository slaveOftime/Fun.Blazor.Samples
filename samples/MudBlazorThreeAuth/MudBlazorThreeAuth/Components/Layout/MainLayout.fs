namespace MudBlazorThreeAuth.Components.Layout

open Microsoft.AspNetCore.Components
open MudBlazor
open Fun.Blazor
open Microsoft.AspNetCore.Components.Web

type MainLayout() as this =
    inherit LayoutComponentBase()

    let content =
        div.create [|
            NavMenu.Create()
            SectionOutlet'() { SectionName "header" }

            // Make those interactive, because by default it is static in this context
            MudThemeProvider'' { renderMode RenderMode.InteractiveAuto }
            MudPopoverProvider'' { renderMode RenderMode.InteractiveAuto }
            MudSnackbarProvider'' { renderMode RenderMode.InteractiveAuto }
            MudDialogProvider'' { renderMode RenderMode.InteractiveAuto }

            main { this.Body }
        |]

    override _.BuildRenderTree(builder) = content.Invoke(this, builder, 0) |> ignore
