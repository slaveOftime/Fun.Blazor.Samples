#nowarn "0020"

open System
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.DependencyInjection
open Fun.Blazor
open Fun.Htmx


let builder = WebApplication.CreateBuilder(Environment.GetCommandLineArgs())

builder.Services.AddControllersWithViews()
builder.Services.AddFunBlazorServer()


let app = builder.Build()

app.UseStaticFiles()


let layout (node: NodeRenderFragment) = fragment {
    html' {
        head {
            title' "HTMX demo"
            baseUrl "/"
            stylesheet "/app-generated.css"
        }
        body {
            div {
                class' "max-w-[720px] mx-auto sm:p-5"
                h1 {
                    class' "text-3xl text-neutral-700 text-center"
                    "Please check more information on "
                    a {
                        class' "text-blue-500 font-bold hover:text-yellow-500"
                        href "https://htmx.org/"
                        "HTMX official site"
                    }
                }
                node
            }
            script { src "https://unpkg.com/htmx.org@1.8.0" }
        }
    }
}


app.MapGet(
    "/blogs",
    div {
        childContent [
            for i in [ 1..5 ] do
                div {
                    class' "rounded-md bg-slate-300 hover:bg-slate-600 hover:text-white hover:shadow-md mb-3 p-3 cursor-pointer"
                    h2 { "Blog #" + string i }
                    p {
                        class' "text-sm"
                        DateTime.Now.ToString("yyy-MM-dd HH:mm:ss")
                    }
                }
        ]
    }
)

app.MapGet(
    "/",
    layout (
        section {
            div {
                class' "text-center mt-5 text-slate-600"
                hxGet "/blogs"
                hxSwap_innerHTML
                hxTarget "#blogs"
                hxIndicator "#blogs_loader"
                hxTrigger' (hxEvt.load, delayMs = 3000)
                "Below is my demo blogs (will delay 3000)"
            }
            div {
                id "blogs_loader"
                class' "htmx-indicator text-purple-800 text-center"
                "Loading blogs ..."
            }
            div { id "blogs" }
        }
    )
)


app.Run()
