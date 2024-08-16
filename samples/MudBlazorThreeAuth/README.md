This project is trying to follow the default blazor official template


## Dev

Open terminal and run
    
    dotnet watch run --project .\MudBlazorThreeAuth\MudBlazorThreeAuth.fsproj


## Blazor3D

This is not a popular binding in blazor community, so the Fun.Blazor binding is not provided for it by default, but we can create it by [cli](https://slaveoftime.github.io/Fun.Blazor.Docs/Docs/Tooling/Code-Generation):

```bash
cd .\MudBlazorThreeAuth.Client\
dotnet fun-blazor generate .\MudBlazorThreeAuth.Client.fsproj
```