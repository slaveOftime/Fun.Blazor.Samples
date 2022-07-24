Demo for using [Fun.Blazor](https://slaveoftime.github.io/Fun.Blazor.Docs/) to generate static html

Startup.fs is the entry file.

## Dev

    Recommend to use VSCode to get tailwindcss intellicense

    dotnet tool restore 
    dotnet watch run --no-hot-reload


## Deploy

    dotnet run -c Release

    index.html file will be generated into wwwroot folder, css will be inlined.