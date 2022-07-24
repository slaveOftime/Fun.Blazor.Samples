open System.IO
open Fun.Result
open Fun.Blazor


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
