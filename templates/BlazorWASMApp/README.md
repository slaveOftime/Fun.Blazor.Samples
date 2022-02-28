This is a blazor WASM mode app with Fun.Blazor

wwwroot/index.html is the entry point for browser. it will load all the necessary files.

App.fs contains UI logic

Startup.fs is for hooking up everything and configuring server


## Dev with hot-reload

    cd to BlazorWASMApp.Server
    dotnet run

    cd to BlazorWASMApp
    fun-blazor watch .\BlazorWASMApp.fsproj -s https://localhost:5001

    > dotnet tool install --global Fun.Blazor.Cli --version 2.0.0-beta019


## Dev without hot-reload

    cd to BlazorWASMApp
    dotnet watch run
