[<AutoOpen>]
module FunWasm.RadzenDemo.App

open FSharp.Data.Adaptive
open Fun.Blazor
open Radzen
open Radzen.Blazor.Blazor

let private isDrawerOpen = cval false

let private counter = adapt {
    let amount = 1
    let! count, setCount = cval(1).WithSetter()

    div {
        div { $"Here is the count {count}" }
        RadzenButton'' {
            Click(fun _ -> setCount (count + amount))
            "Increase by "
            amount
        }
    }
}


let app = RadzenLayout'' {
    RadzenTheme'' { Theme "material" }
    RadzenHeader'' {
        RadzenStack'' {
            Orientation Orientation.Horizontal
            AlignItems AlignItems.Center
            Gap "0"
            RadzenSidebarToggle'' { Click(fun _ -> isDrawerOpen.Publish(not)) }
            RadzenLabel'' { "Header" }
        }
    }
    adapt {
        let! binding = isDrawerOpen.WithSetter()
        RadzenSidebar'' {
            Expanded' binding
            RadzenPanelMenu'' {
                RadzenPanelMenuItem'' {
                    Icon "home"
                    Text "Text"
                }
            }
        }
    }
    RadzenBody'' {
        counter
        br
        adapt {
            let! txt = cval("<h1>hi</h1>").WithSetter()
            RadzenHtmlEditor'' { Value' txt }
        }
    }
    RadzenFooter'' { "footer" }
}
