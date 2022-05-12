// hot-reload
// hot-reload is the flag to let cli know this file should be included
// It has dependency requirement: the root is the app which is used in the Startup.fs
// All other files which want have hot reload, need to drill down to that file, and all the middle file should also add the '// hot-reload' flag at the top of taht file
[<AutoOpen>]
module WASMMudBlazor.App

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
