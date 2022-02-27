This is a server side blazor app

App.fs contains UI logic

Index.fs is for create the index template. You can think it as index.html

Startup.fs is for hooking up everything and configuring server


- Open terminal and run

    dotnet run

- Open terminal and run (for hot reload)

    fun-blazor watch .\Demo13.fsproj --server https://localhost:5001

    > This required 'dotnet tool install --global Fun.Blazor.Cli --version 2.0.0-beta018'
    