namespace MudBlazorThreeAuth.Components.Account.Pages

open System
open Microsoft.AspNetCore.Components
open Fun.Blazor
open MudBlazor
open MudBlazorThreeAuth.Components.Layout

[<Route "/account/login">]
[<Layout(typeof<EmptyLayout>)>]
type Login() =
    inherit FunComponent()

    [<SupplyParameterFromQuery(Name = "returnUrl")>]
    member val ReturnUrl = String.Empty with get, set

    override this.Render() = div {
        style {
            displayFlex
            flexDirectionColumn
            alignItemsCenter
            justifyContentCenter
            height "100vh"
        }
        MudThemeProvider''
        MudPaper'' {
            style {
                width 300
                padding 12
            }
            Elevation 2
            MudForm'' {
                style { gap 8 }
                action $"/api/login?returnUrl={this.ReturnUrl}"
                method "post"
                MudTextField''<string> {
                    name "User"
                    Placeholder "User Name"
                }
                MudTextField''<string> {
                    name "Password"
                    Placeholder "Password"
                    InputType InputType.Password
                }
                MudButton'' {
                    ButtonType ButtonType.Submit
                    Color Color.Primary
                    Variant Variant.Filled
                    "Login"
                }
            }
        }
    }
