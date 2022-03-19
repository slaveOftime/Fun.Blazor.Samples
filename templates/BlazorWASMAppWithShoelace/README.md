With shoelace you can use a great web component libraries for you UI.

With tailwindcss you can have a rich utilities for your design system.


Tailwindcss will drive all the theme, spacing etc. In ./wwwroot/app.css all the shoelace token will be override by tailwindcss. So if you want to customize something, you should change it in tailwind.config.js


It is recommend you to use VSCode for this and install extension: Tailwind CSS IntelliSense + Ionide-fsharp \
And open the the same folder as the README.md file in VSCode 

The reason you can get some intellisense for shoelace is because there is some meta file I downloaded from shoelace and put it in .vscode. [You can check more detail here](https://shoelace.style/getting-started/usage?id=code-completion). So if you want to support other web components code auto completion you can use this as a reference.


## Dev with hot-reload

    cd to BlazorWASMAppWithShoelace

    pnpm install
    pnpm run watch-css

    Open terminal and run
    dotnet run

    Open terminal and run
    fun-blazor watch .\BlazorWASMAppWithShoelace.fsproj

    > require: dotnet tool install --global Fun.Blazor.Cli --version 2.0.0-beta031


## Dev without hot-reload

    cd to BlazorWASMAppWithShoelace
    dotnet watch run
