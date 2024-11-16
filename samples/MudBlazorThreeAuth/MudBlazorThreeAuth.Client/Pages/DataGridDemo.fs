namespace MudBlazorThreeAuth.Client.Pages

open System
open System.Threading.Tasks
open FSharp.Data.Adaptive
open Microsoft.AspNetCore.Components
open MudBlazor
open Fun.Result
open Fun.Blazor

type Demo = { Name: string; Age: int; Birthday: DateTime }

type DataGrid =
    static member Create() =
        html.inject (
            "data-grid-demo",
            fun (hook: IComponentHook) ->
                let items = cval LoadingState<Demo list>.NotStartYet

                hook.AddFirstAfterRenderTask(fun () -> task {
                    items.Publish LoadingState.start

                    do! Task.Delay 1000

                    [
                        for i in 1..50 do
                            {
                                Name = $"name-{i}"
                                Age = Random.Shared.Next(1, 100)
                                Birthday = DateTime.Now.AddYears(Random.Shared.Next(1, 50))
                            }
                    ]
                    |> LoadingState.Loaded
                    |> items.Publish
                })

                adapt {
                    let! items = items
                    MudDataGrid'' {
                        Items(defaultArg items.Value List.empty)
                        Loading items.IsLoadingNow
                        SortMode SortMode.Single
                        Filterable
                        FilterMode DataGridFilterMode.ColumnFilterRow
                        Columns [|
                            PropertyColumn''<Demo, _> { Property(fun x -> x.Name) }
                            PropertyColumn''<Demo, _> { Property(fun x -> x.Age) }
                            PropertyColumn''<Demo, _> { Property(fun x -> x.Birthday) }
                        |]
                    }
                }
        )

[<Route "/data-grid-demo">]
[<FunInteractiveAuto>]
type DataGridDemo() =
    inherit FunComponent()
    override _.Render() =
        // Demo how to use module or static method to provide component of view instead of use the class based
        DataGrid.Create()
