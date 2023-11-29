namespace SSRApp.View.Components

open System
open Microsoft.AspNetCore.Components
open Microsoft.AspNetCore.Components.Forms
open Fun.Css
open Fun.Htmx
open Fun.Blazor

type Login() as this =
    inherit FunComponent()

    [<Parameter>]
    member val Name = "" with get, set

    [<Parameter>]
    member val Password = "" with get, set

    override _.Render() = form {
        hxGetComponent typeof<Login>
        html.blazor<AntiforgeryToken> ()
        input {
            type' InputTypes.text
            name (nameof this.Name)
            value this.Name
        }
        input {
            type' InputTypes.password
            name (nameof this.Password)
            value this.Password
            style {
                borderWidth 1
                borderColor (
                    if String.IsNullOrEmpty this.Password || this.Password.Length < 3 then
                        color.red
                    else
                        color.green
                )
            }
        }
        button {
            type' InputTypes.submit
            "Login"
        }
    }
