This is a server side blazor app

App.fs contains UI logic

Index.fs is for creating the index template. You can think it as index.html

Startup.fs is for hooking up everything and configuring server


## Dev with hot-reload

    Open terminal and run
    dotnet run

    Open terminal and run
    fun-blazor watch .\ServerApp.fsproj

    > This required 'dotnet tool install --global Fun.Blazor.Cli --version 2.0.0'
    
## Dev without hot-reload

    dotnet watch run