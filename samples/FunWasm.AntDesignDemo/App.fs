// hot-reload
// hot-reload is the flag to let cli know this file should be included
// It has dependency requirement: the root is the app which is used in the Startup.fs
// All other files which want have hot reload, need to drill down to that file, and all the middle file should also add the '// hot-reload' flag at the top of taht file
[<AutoOpen>]
module FunWasm.AntDesignDemo.App

open AntDesign
open Fun.Blazor
open Fun.Blazor.Router
open Microsoft.AspNetCore.Components.Web

type IShareStore with

    member store.Count = store.CreateCVal(nameof store.Count, 0)
    member store.IsMenuOpen = store.CreateCVal(nameof store.IsMenuOpen, false)

let homePage =
    html.fragment [|
        SectionContent'() {
            SectionName "Title"
            "Home"
        }
        Title'() {
            Level 1
            Type TextElementType.Danger
            "Hi from FunBlazor"
        }
    |]

let counterPage =
    html.inject (fun (store: IShareStore, snackbar: NotificationService) ->
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
            Button'() {
                Type ButtonType.Primary
                OnClick(fun _ ->
                    task {
                        store.Count.Publish((+) 1)
                        let! _ = snackbar.Open(NotificationConfig(Message = $"Count = {store.Count.Value}"))
                        ()
                    }
                )
                "Increase by 1"
            }
        |]
    )


let appbar =
    html.injectWithNoKey (fun (store: IShareStore) ->
        html.fragment [|
            Header'.create [|
                Button'() {
                    Shape ButtonShape.Circle
                    Icon IconType.Outline.MenuFold
                    OnClick(fun _ -> store.IsMenuOpen.Publish(not))
                }
                span {
                    style { color "white" }
                    SectionOutlet'() { SectionName "Title" }
                }
            |]
        |]
    )

let navmenus =
    Sider'() {
        Width 200
        Menu'() {
            Mode MenuMode.Inline
            style {
                height "100%"
                borderRight "0"
            }
            childContent [|
                MenuItem'() {
                    a {
                        href "/"
                        "Home"
                    }
                }
                MenuItem'() {
                    a {
                        href "/counter"
                        "Counter"
                    }
                }
            |]
        }
    }


let routes = html.route [| 
    routeCi "/counter" counterPage
    routeAny homePage
|]


let app =
    ErrorBoundary'() {
#if DEBUG
        key (System.Random.Shared.Next()) // So hot reload can re-render correctly
#endif
        ErrorContent(fun e ->
            Alert'() {
                Type AlertType.Error
                string e
            }
        )
        AntContainer'.create ()
        Layout'() {
            style { height "100%" }
            childContent [|
                appbar
                Layout'.create [|
                    navmenus
                    Layout'() {
                        style { padding 10 }
                        Content'() { routes }
                    }
                |]
            |]
        }
    }
