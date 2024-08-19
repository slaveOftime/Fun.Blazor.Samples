namespace MudBlazorThreeAuth.Components.Layout

open Microsoft.AspNetCore.Components.Routing
open Microsoft.AspNetCore.Components.Authorization
open Fun.Blazor
open MudBlazor

type NavMenu =
    static member private LogoutBtn =
        html.inject (fun (auth: AuthenticationStateProvider) -> task {
            let! state = auth.GetAuthenticationStateAsync()
            if state.User <> null && state.User.Identity <> null && state.User.Identity.IsAuthenticated then
                return form {
                    method "post"
                    action "/api/logout"
                    MudButton'' {
                        Color Color.Warning
                        Variant Variant.Outlined
                        ButtonType ButtonType.Submit
                        "Logout " + state.User.Identity.Name
                    }
                }
            else
                return html.none
        })

    static member Create() = nav {
        style {
            displayFlex
            alignItemsCenter
            gap 10
        }
        childContent [|
            NavLink'() {
                href ""
                Match NavLinkMatch.All
                "Home"
            }
            NavLink'() {
                href "counter"
                "Counter"
            }
            NavLink'() {
                href "data-grid-demo"
                "Data Grid Demo"
            }
            NavLink'() {
                href "threejs"
                "Threejs Demo"
            }
            NavLink'() {
                href "form"
                "Form demo"
            }
            NavMenu.LogoutBtn
        |]
    }
