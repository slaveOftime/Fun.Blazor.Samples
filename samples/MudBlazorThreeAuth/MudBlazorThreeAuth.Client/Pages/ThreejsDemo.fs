namespace MudBlazorThreeAuth.Client.Pages

open System
open Microsoft.AspNetCore.Components
open Microsoft.AspNetCore.Components.Web
open Fun.Result
open Fun.Blazor
open MudBlazor
open HomagGroup.Blazor3D.Enums
open HomagGroup.Blazor3D.Maths
open HomagGroup.Blazor3D.Scenes
open HomagGroup.Blazor3D.Lights
open HomagGroup.Blazor3D.Objects
open HomagGroup.Blazor3D.Viewers
open HomagGroup.Blazor3D.Settings
open HomagGroup.Blazor3D.Geometires

// https://github.com/HomagGroup/Blazor3D?tab=readme-ov-file#with-custom-scene
// Try to use it with their example doc and use class based style
[<Route "/threejs">]
[<FunInteractiveAuto>]
type ThreejsDemo() as this =
    inherit FunComponent()

    let mutable viewerRef = Option<Viewer>.None
    let mutable isLoading = false

    let viewSettings = ViewerSettings(ContainerId = "demo")

    let scene =
        let scene = Scene()
        scene.Add(AmbientLight())
        scene.Add(PointLight(Position = Vector3(X = 1, Y = 3, Z = 0)))
        scene

    let loadStl (url) = task {
        isLoading <- true

        try
            match viewerRef with
            | Some viewerRef ->
                let settings = ImportSettings(Format = Import3DFormats.Stl, FileURL = url)
                do! viewerRef.Import3DModelAsync(settings) |> Task.map ignore
            | _ -> ()

        with ex ->
            this.Snackbar.Add(ex.Message, severity = Severity.Error) |> ignore

        isLoading <- false
    }

    let addRandomCube () = task {
        match viewerRef with
        | Some viewerRef ->
            scene.Add(
                Mesh(
                    Geometry = BoxGeometry(Width = 1, Height = 1, Depth = 1),
                    Position = Vector3(X = Random.Shared.Next(-5, 5), Y = Random.Shared.Next(-5, 5), Z = Random.Shared.Next(-5, 5))
                )
            )
            do! viewerRef.UpdateScene()

        | _ -> ()
    }

    [<Inject>]
    member val Snackbar: ISnackbar = Unchecked.defaultof<ISnackbar> with get, set

    override _.Render() =
        html.fragment [|
            PageTitle'() { "Threejs" }
            SectionContent'() {
                SectionName "header"
                h1 { "Threejs" }
            }
            div {
                MudButtonGroup'' {
                    Variant Variant.Outlined
                    MudButton'' {
                        StartIcon Icons.Material.Filled.Add
                        OnClick(fun _ -> addRandomCube ())
                        "Add cube"
                    }
                    MudButton'' {
                        StartIcon Icons.Material.Filled.Download
                        OnClick(fun _ -> loadStl "https://threejs.org/examples/models/stl/ascii/slotted_disk.stl")
                        "Load slotted_disk stl model"
                    }
                }
            }
            Viewer'' {
                Scene scene
                ViewerSettings viewSettings
                ref (fun x -> viewerRef <- Some x)
            }
        |]
