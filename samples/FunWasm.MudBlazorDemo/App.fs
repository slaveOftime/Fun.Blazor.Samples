// hot-reload
[<AutoOpen>]
module FunWasm.MudBlazorDemo.App

open Microsoft.AspNetCore.Components.Web
open Microsoft.AspNetCore.Components.Routing
open MudBlazor
open Fun.Blazor
open Fun.Blazor.Router


type IShareStore with

    member store.Count = store.CreateCVal(nameof store.Count, 0)
    member store.IsMenuOpen = store.CreateCVal(nameof store.IsMenuOpen, false)

let homePage =
    html.fragment [|
        SectionContent'() {
            SectionName "Title"
            "Home"
        }
        MudText'() {
            Typo Typo.h1
            Color Color.Info
            "Hi from FunBlazor"
        }
    |]

let counterPage =
    html.injectWithNoKey (fun (store: IShareStore, snackbar: ISnackbar) ->
        html.fragment [|
            SectionContent'() {
                SectionName "Title"
                "Counter"
            }
            adaptiview () {
                let! count = store.Count
                div {
                    "Here is the count: "
                    count
                }
            }
            MudButton'() {
                Variant Variant.Filled
                Color Color.Primary
                OnClick(fun _ -> 
                    store.Count.Publish((+) 1)
                    snackbar.Add($"Count = {store.Count.Value}", severity = Severity.Success) |> ignore
                )
                "Increase by 1"
            }
        |]
    )


let appbar =
    // We should use a fixed key or no key here to avoid infinite re-redner caused MudDrawer and MudLayout
    html.injectWithNoKey (fun (store: IShareStore) ->
        html.fragment [|
            MudAppBar'.create [|
                MudIconButton'() {
                    Icon Icons.Material.Filled.Menu
                    Color Color.Inherit
                    Edge Edge.Start
                    OnClick(fun _ -> store.IsMenuOpen.Publish(not))
                }
                SectionOutlet'() { SectionName "Title" }
            |]
            adaptiview () {
                let! binding = store.IsMenuOpen.WithSetter()
                MudDrawer'() {
                    Open' binding
                    Elevation 1
                    MudNavMenu'.create [|
                        MudNavLink'() {
                            Href "/"
                            Match NavLinkMatch.All
                            "Home"
                        }
                        MudNavLink'() {
                            Href "/counter"
                            Match NavLinkMatch.Prefix
                            "Counter"
                        }
                    |]
                }
            }
        |]
    )

let routes = html.route [| 
    routeCi "/counter" counterPage
    routeAny homePage
|]


let app = 
    ErrorBoundary'() {
#if DEBUG
        key (System.Random.Shared.Next()) // So hot reload can re-render correctly
#endif
        ErrorContent(fun e -> MudAlert'() {
            Severity Severity.Error
            string e
        })
        childContent [|
            MudThemeProvider'.create ()
            MudDialogProvider'.create ()
            MudSnackbarProvider'.create ()
            MudLayout'.create [|
                appbar
                MudMainContent'() {
                    MudContainer'() {
                        MaxWidth MaxWidth.ExtraLarge
                        routes
                    }
                }
            |]
        |]
    }
