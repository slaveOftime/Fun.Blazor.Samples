namespace ServerOnlyApp.Components.Layout

open Microsoft.AspNetCore.Components
open Fun.Blazor

type MainLayout() as this =
    inherit LayoutComponentBase()

    let content = div {
        NavMenu.Create()
        SectionOutlet'' { SectionName "header" }
        main { this.Body }
    }

    override _.BuildRenderTree(builder) = content.Invoke(this, builder, 0) |> ignore
