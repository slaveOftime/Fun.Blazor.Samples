// hot-reload
[<AutoOpen>]
module WASMMudBlazor.DialogDemo

open FSharp.Data.Adaptive
open Fun.Blazor
open MudBlazor
open WASMMudBlazor.Controls


let dialogDemo1 =
    adaptiview () {
        let! isOpen, setIsOpen = cval(false).WithSetter()

        MudButton'() {
            Color Color.Primary
            Variant Variant.Filled
            OnClick(fun _ -> setIsOpen true)
            "Open Dialog 1"
        }
        MudDialog'() {
            IsVisible isOpen
            TitleContent "Dialog 1"
            DialogContent counter
            DialogActions [
                MudButton'() {
                    Color Color.Primary
                    Variant Variant.Filled
                    OnClick(fun _ -> setIsOpen false)
                    "Close"
                }
            ]
        }
    }


let dialogForDemo2 (onClose: unit -> unit) =
    MudDialog'() {
        TitleContent "Dalog 2"
        DialogContent counter
        DialogActions [
            MudButton'() {
                Color Color.Primary
                Variant Variant.Filled
                OnClick(fun _ -> onClose ())
                "Close"
            }
        ]
    }


let dialogDemo2 =
    html.inject (fun (dialog: IDialogService) ->
        MudButton'() {
            Color Color.Primary
            Variant Variant.Filled
            OnClick(fun _ -> dialog.Show(fun props -> dialogForDemo2 props.Close))
            "Open Dialog 2"
        }
    )
