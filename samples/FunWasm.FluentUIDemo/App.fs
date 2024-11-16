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

let homePage = fragment {
    SectionContent'' {
        SectionName "Title"
        "Home"
    }
    FluentLabel'' {
        Typo Typography.H1
        Color Color.Accent
        "Hi from FunBlazor"
    }
}

let counterPage =
    html.inject (fun (store: IShareStore, snackbar: IToastService) -> fragment {
        SectionContent'' {
            SectionName "Title"
            "Counter"
        }
        adapt {
            let! count = store.Count
            div {
                "Here is the count: "
                count
            }
        }
        FluentButton'' {
            Appearance Appearance.Accent
            OnClick(fun _ ->
                store.Count.Publish((+) 1)
                snackbar.ShowSuccess($"Count = {store.Count.Value}")
            )
            "Increase by 1"
        }
    })


let appbar =
    html.injectWithNoKey (fun (store: IShareStore) -> FluentHeader'' {
        FluentIcon'' {
            Value(Icons.Regular.Size24.Navigation())
            Color Color.Fill
            OnClick(fun _ -> store.IsMenuOpen.Publish(not))
        }
        FluentSpacer'' { Width 20 }
        SectionOutlet'' { SectionName "Title" }
    })

let navmenus =
    html.injectWithNoKey (fun (store: IShareStore) -> adaptiview () {
        let! binding = store.IsMenuOpen.WithSetter()
        FluentNavMenu'' {
            Width 200
            Expanded' binding
            FluentNavLink'' {
                Href "/"
                Match NavLinkMatch.All
                Icon(Icons.Regular.Size20.Home())
                "Home"
            }
            FluentNavLink'' {
                Href "/counter"
                Match NavLinkMatch.Prefix
                Icon(Icons.Regular.Size20.NumberSymbolSquare())
                "Counter"
            }
        }
    })

let routes = html.route [| routeCi "/counter" counterPage; routeAny homePage |]


let app = ErrorBoundary'' {
    ErrorContent(fun e -> FluentLabel'' {
        Color Color.Error
        string e
    })
    FluentToastProvider''
    FluentLayout'' {
        appbar
        FluentStack'' {
            Width "100%"
            Orientation Orientation.Horizontal
            navmenus
            FluentBodyContent'' {
                style { overflowHidden }
                routes
            }
        }
    }
}
