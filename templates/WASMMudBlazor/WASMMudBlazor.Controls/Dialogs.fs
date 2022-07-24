[<AutoOpen>]
module WASMMudBlazor.Controls.Dialogs

open Fun.Blazor
open MudBlazor
open Microsoft.AspNetCore.Components


type FunDialogProps = { Close: unit -> unit; Options: DialogOptions }


type FunDialog() =
    inherit FunBlazorComponent()


    let mutable dialogView = None


    [<CascadingParameter>]
    member val MudDialogInstance = Unchecked.defaultof<MudDialogInstance> with get, set

    [<Parameter>]
    member val RenderFn = Unchecked.defaultof<FunDialogProps -> NodeRenderFragment> with get, set

    member this.CloseDialog() = this.InvokeAsync(fun _ -> this.MudDialogInstance.Close()) |> ignore


    override this.Render() =
        match dialogView with
        | None ->
            let newView =
                this.RenderFn
                    {
                        Close = this.CloseDialog
                        Options = this.MudDialogInstance.Options
                    }
            dialogView <- Some newView
            newView

        | Some x -> x


type IDialogService with

    member this.Show(title, render: FunDialogProps -> NodeRenderFragment, ?options) =
        let options = options |> Option.defaultWith (fun _ -> DialogOptions())
        let parameters = DialogParameters()
        parameters.Add("RenderFn", render)
        this.Show<FunDialog>(title, parameters, options)

    member this.Show(title, render: FunDialogProps -> NodeRenderFragment) = this.Show(title, render, DialogOptions()) |> ignore

    member this.Show(render: FunDialogProps -> NodeRenderFragment) = this.Show("", render, DialogOptions()) |> ignore

    member this.Show(options, render: FunDialogProps -> NodeRenderFragment) = this.Show("", render, options) |> ignore
