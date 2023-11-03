This is an experimental project for combining [Fun.Blazor](https://slaveoftime.github.io/Fun.Blazor.Docs/) and [htmx](https://htmx.org/)

Startup.fs is for hooking up everything and configuring server. It also contains some very simple usage htmx example.

## Dev

    Recommend to use VSCode to get tailwindcss intellicense

    dotnet tool restore 
    dotnet watch run

## Update Fun.Blazor.Bindings

    fun-blazor generate .\BlazorApp.fsproj

> This required 'dotnet tool install --global Fun.Blazor.Cli'
