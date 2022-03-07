This is a server side blazor app

App.fs contains UI logic

Index.fs is for create the index template. You can think it as index.html

Startup.fs is for hooking up everything and configuring server


## Dev with hot-reload

    Open terminal and run
    fun-blazor watch .\BlazorServerApp.fsproj

    Open terminal and run
    dotnet run

    > This required 'dotnet tool install --global Fun.Blazor.Cli --version 2.0.0-beta028'
    
## Dev without hot-reload

    dotnet watch run