namespace rec HomagGroup.Blazor3D.DslInternals

open System.Threading.Tasks
open FSharp.Data.Adaptive
open Fun.Blazor
open Fun.Blazor.Operators
open HomagGroup.Blazor3D.DslInternals

type _ImportsBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit ComponentWithDomAndChildAttrBuilder<'FunBlazorGeneric>()


            
namespace rec HomagGroup.Blazor3D.DslInternals.Viewers

open System.Threading.Tasks
open FSharp.Data.Adaptive
open Fun.Blazor
open Fun.Blazor.Operators
open HomagGroup.Blazor3D.DslInternals

type ViewerBuilder<'FunBlazorGeneric when 'FunBlazorGeneric :> Microsoft.AspNetCore.Components.IComponent>() =
    inherit ComponentWithDomAndChildAttrBuilder<'FunBlazorGeneric>()
    [<CustomOperation("ViewerSettings")>] member inline _.ViewerSettings ([<InlineIfLambda>] render: AttrRenderFragment, x: HomagGroup.Blazor3D.Settings.ViewerSettings) = render ==> ("ViewerSettings" => x)
    [<CustomOperation("Scene")>] member inline _.Scene ([<InlineIfLambda>] render: AttrRenderFragment, x: HomagGroup.Blazor3D.Scenes.Scene) = render ==> ("Scene" => x)
    [<CustomOperation("UseDefaultScene")>] member inline _.UseDefaultScene ([<InlineIfLambda>] render: AttrRenderFragment, ?x: bool) = render ==> ("UseDefaultScene" => (defaultArg x true))
    [<CustomOperation("Camera")>] member inline _.Camera ([<InlineIfLambda>] render: AttrRenderFragment, x: HomagGroup.Blazor3D.Cameras.Camera) = render ==> ("Camera" => x)
    [<CustomOperation("OrbitControls")>] member inline _.OrbitControls ([<InlineIfLambda>] render: AttrRenderFragment, x: HomagGroup.Blazor3D.Controls.OrbitControls) = render ==> ("OrbitControls" => x)

            

// =======================================================================================================================

namespace HomagGroup.Blazor3D

[<AutoOpen>]
module DslCE =
  
    open System.Diagnostics.CodeAnalysis
    open HomagGroup.Blazor3D.DslInternals

    type _Imports' [<DynamicDependency(DynamicallyAccessedMemberTypes.All, typeof<HomagGroup.Blazor3D._Imports>)>] () = inherit _ImportsBuilder<HomagGroup.Blazor3D._Imports>()

[<AutoOpen>]
module DslCEInstances =
  
    open System.Diagnostics.CodeAnalysis
    open HomagGroup.Blazor3D.DslInternals

    let _Imports'' = _Imports'()
            
namespace HomagGroup.Blazor3D.Viewers

[<AutoOpen>]
module DslCE =
  
    open System.Diagnostics.CodeAnalysis
    open HomagGroup.Blazor3D.DslInternals.Viewers

    type Viewer' [<DynamicDependency(DynamicallyAccessedMemberTypes.All, typeof<HomagGroup.Blazor3D.Viewers.Viewer>)>] () = inherit ViewerBuilder<HomagGroup.Blazor3D.Viewers.Viewer>()

[<AutoOpen>]
module DslCEInstances =
  
    open System.Diagnostics.CodeAnalysis
    open HomagGroup.Blazor3D.DslInternals.Viewers

    let Viewer'' = Viewer'()
            