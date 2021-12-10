CSharpWASMApp is created by blazorwasm official template

1. It will reference FSharpUI\FSharpUI.fsproj
2. In CSharpWASMApp\_Imports.razor add "@using FSharpUI" like you normally will do in csharp blazor app
3. In CSharpWASMApp\Pages\Counter.razor you can use GreatSection component exposed by FSharpUI


FSharpUI\GreatSection.fs:

    All you need to do is just wrap functional style Bolero.Node into a class.

    dotnet run --project .\CSharpWASMApp\CSharpWASMApp.csproj


Of course, you can reuse csharp library in a fsharp blazor app. To do that you will need Fun.Blazor.Cli to auto generate some binding files for you. It is just similar with MinimalBlazorWASMAppWithMudBlazor.
