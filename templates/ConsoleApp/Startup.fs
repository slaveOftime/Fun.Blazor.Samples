open System.IO
open Microsoft.AspNetCore.Components
open Microsoft.AspNetCore.Components.Web
open Microsoft.Extensions.Logging
open Microsoft.Extensions.DependencyInjection
open Fun.Blazor
open Fun.Result


let writeHtmlTo file (node: NodeRenderFragment) = task {
    let serviceProvider = 
        (new ServiceCollection())
            .AddLogging()
            .BuildServiceProvider()

    let loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>()
    use htmlRenderer = new HtmlRenderer(serviceProvider, loggerFactory)

    do! htmlRenderer.Dispatcher.InvokeAsync<unit>(fun () -> task {
        let ps = ParameterView.FromDictionary(dict [ "Fragment", box node ])
        let! output = htmlRenderer.RenderComponentAsync<FunFragmentComponent>(ps)
        do! File.WriteAllTextAsync(file, output.ToHtmlString())
    })
}


html' {
    head {
        title' "HTMX demo"
        baseUrl "/"
        styleElt { childContentRaw (File.ReadAllText("wwwroot/app-generated.css")) }
    }
    body {
        div {
            class' "max-w-[720px] mx-auto sm:p-5"
            h1 {
                class' "text-3xl text-neutral-700 text-center"
                "Please check more information on "
                a {
                    class' "text-blue-500 font-bold hover:text-yellow-500"
                    href "https://slaveoftime.github.io/Fun.Blazor.Docs/"
                    "Fun.Blazor"
                }
            }
            p {
                class' "text-center text-purple-600 mt-5"
                "This is a demo of Fun.Blazor. It is a simple example of how to use Fun.Blazor in a console application, just for generating static html."
            }
        }
    }
}
|> writeHtmlTo "wwwroot/index.html"
|> Task.runSynchronously
