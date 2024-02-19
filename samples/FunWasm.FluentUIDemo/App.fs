// hot-reload
// hot-reload is the flag to let cli know this file should be included
// It has dependency requirement: the root is the app which is used in the Startup.fs
// All other files which want have hot reload, need to drill down to that file, and all the middle file should also add the '// hot-reload' flag at the top of taht file
[<AutoOpen>]
module FunWasm.FluentUIDemo.App

open Microsoft.AspNetCore.Components.Web
open Microsoft.AspNetCore.Components.Routing
open Microsoft.FluentUI.AspNetCore.Components
open Fun.Blazor
open Fun.Blazor.Router


type IShareStore with

    member store.Count = store.CreateCVal(nameof store.Count, 0)
    member store.IsMenuOpen = store.CreateCVal(nameof store.IsMenuOpen, true)

let homePage =
    html.fragment [|
        SectionContent'() {
            SectionName "Title"
            "Home"
        }
        FluentLabel'() {
            Typo Typography.H1
            Color Color.Accent
            "Hi from FunBlazor"
        }
    |]

let counterPage =
    html.injectWithNoKey (fun (store: IShareStore, snackbar: IToastService) ->
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
            FluentButton'() {
                Appearance Appearance.Accent
                OnClick(fun _ ->
                    store.Count.Publish((+) 1)
                    snackbar.ShowSuccess($"Count = {store.Count.Value}")
                )
                "Increase by 1"
            }
        |]
    )


let appbar =
    html.injectWithNoKey (fun (store: IShareStore) ->
        FluentHeader'.create [|
            FluentIcon'() {
                Value(Icons.Regular.Size24.Navigation())
                Color Color.Fill
                OnClick(fun _ -> store.IsMenuOpen.Publish(not))
            }
            FluentSpacer'() { Width 20 }
            SectionOutlet'() { SectionName "Title" }
        |]
    )

let navmenus =
    html.injectWithNoKey (fun (store: IShareStore) -> adaptiview () {
        let! binding = store.IsMenuOpen.WithSetter()
        FluentNavMenu'() {
            Width 200
            Expanded' binding
            [|
                FluentNavLink'() {
                    Href "/"
                    Match NavLinkMatch.All
                    Icon(Icons.Regular.Size20.Home())
                    "Home"
                }
                FluentNavLink'() {
                    Href "/counter"
                    Match NavLinkMatch.Prefix
                    Icon(Icons.Regular.Size20.NumberSymbolSquare())
                    "Counter"
                }
            |]
        }
    })

let routes = html.route [| 
    routeCi "/counter" counterPage
    routeAny homePage
|]


let app = ErrorBoundary'() {
#if DEBUG
    key (System.Random.Shared.Next()) // So hot reload can re-render correctly
#endif
    ErrorContent(fun e -> FluentLabel'() {
        Color Color.Error
        string e
    })
    childContent [|
        FluentToastProvider'.create ()
        FluentLayout'.create [|
            appbar
            FluentStack'() {
                Width "100%"
                Orientation Orientation.Horizontal
                childContent [| 
                    navmenus
                    FluentBodyContent'() {
                        style { overflowHidden }
                        routes
                    }
                |]
            }
        |]
    |]
}
