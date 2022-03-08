// hot-reload
[<AutoOpen>]
module BlazorWASMAppWithMudBlazor.App

open Fun.Blazor
open MudBlazor


let app =
    div {
        MudThemeProvider'()
        MudDialogProvider'()
        MudContainer'() {
            counter
            dialogDemo1
            dialogDemo2
        }
    }
