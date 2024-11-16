namespace MudBlazorThreeAuth.Components.Pages

open System
open System.Threading.Tasks
open Microsoft.AspNetCore.Components
open Microsoft.AspNetCore.Components.Web
open Microsoft.AspNetCore.Components.Forms
open Fun.Blazor

[<Route "/form">]
[<StreamRendering>]
type Form() as this =
    inherit FunComponent()

    let mutable isSubmitting = false

    [<SupplyParameterFromForm>]
    member val Query: string = null with get, set

    member _.Submit() = task {
        isSubmitting <- true
        this.StateHasChanged()

        do! Task.Delay 1000
        isSubmitting <- false
        this.StateHasChanged()
    }

    member _.FormView = form {
        onsubmit (ignore >> this.Submit)
        method "post"
        dataEnhance
        formName "person-info"
        html.blazor<AntiforgeryToken> ()
        input {
            type' InputTypes.text
            name (nameof this.Query)
            value this.Query
        }
        button {
            type' InputTypes.submit
            "Submit"
        }
        region {
            if String.IsNullOrEmpty this.Query || this.Query.Length > 5 then
                div {
                    style { color "red" }
                    $"{nameof this.Query} is not valid"
                }
        }
    }

    override _.Render() = fragment {
        PageTitle'' { "Form demo" }
        SectionContent'' {
            SectionName "header"
            h1 { "Form demo" }
        }
        div {
            style { height "100vh" }
            a {
                href "form?#person-info"
                "check the form"
            }
        }
        h2 {
            id "person-info"
            "person info"
        }
        this.FormView
        region { if isSubmitting then progress.create () }
        div { style { height "100vh" } }
    }
