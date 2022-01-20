Tips:

1. Check the line in file MinimalBlazorWASMApp.fsproj: 

    It required MudBlazor. Also has attribute FunBlazorStyle.

    ```
    <PackageReference Include="MudBlazor" FunBlazorStyle="CE" Version="5.2.0" />
    ```

2. dotnet tool install --global Fun.Blazor.Cli --version 1.1.2

    If you change the version of MudBlazor you should run "fun-blazor generate" under this folder to regenerate Fun.Blazor.Bindings

3. According to MudBlazor, you should also add related css/js resources in wwwroot/index.html

    dotnet run
