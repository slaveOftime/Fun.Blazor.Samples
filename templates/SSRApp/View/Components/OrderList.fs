namespace SSRApp.View.Components

open System
open System.Threading.Tasks
open Microsoft.AspNetCore.Components
open Fun.Css
open Fun.Htmx
open Fun.Blazor

type OrderList() as this =
    inherit FunComponent()

    let mutable orders = []

    [<Parameter>]
    member val Query = "" with get, set

    override _.OnInitializedAsync() = task {
        do! Task.Delay 3000

        orders <-
            [
                for i in 1..10 do
                    {|
                        Id = i
                        Name = $"Item {i}"
                        Quality = Random.Shared.Next(1, 100)
                    |}
            ]
            |> (if String.IsNullOrEmpty this.Query then
                    id
                else
                    Seq.filter (fun x -> x.Name.Contains(this.Query, StringComparison.OrdinalIgnoreCase)) >> Seq.toList)
    }

    override _.Render() = section {
        id "order-list"
        div {
            input {
                hxTrigger' (hxEvt.keyboard.keyup, delayMs = 500)
                hxGetComponent typeof<OrderList> // Load the component it self and replace the whole content
                hxTarget "#order-list"
                hxSwap_outerHTML
                hxIndicator ".htmx-indicator"
                name (nameof this.Query)
                value this.Query
                placeholder "Search by name..."
            }
        }
        progress { class' "htmx-indicator" }
        ul {
            for order in orders do
                li {
                    style { color (if order.Quality % 3 = 0 then color.blue else color.darkCyan) }
                    $"Order: {order.Name} [{order.Quality}]"
                }
        }
    }
