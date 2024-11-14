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
        hxPostComponent typeof<Login>
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
        }
        button {
            type' InputTypes.submit
            "Login"
        }
        if String.IsNullOrEmpty this.Password || this.Password.Length < 3 then
            div {
                style { color color.red }
                "Wrong password"
            }
    }
