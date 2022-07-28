This project mix blazor server and wasm mode.  
It server both mode in different urls.


## Dev with hot-reload

    Open terminal and run
    dotnet run --project .\MixMode.Server\MixMode.Server.fsproj

    Open terminal and run
    fun-blazor watch .\MixMode.Wasm\MixMode.Wasm.fsproj

    > This required 'dotnet tool install --global Fun.Blazor.Cli --version 2.1.*'
    
## Dev without hot-reload

    dotnet watch run