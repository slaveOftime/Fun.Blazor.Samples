#nowarn "0020"

open System
open System.Threading.Tasks
open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.DependencyInjection
open Fun.Htmx
open Fun.Blazor
open Fun.AspNetCore


type DbContext() =

    member _.GetBlogs() = task {
        do! Task.Delay 1000
        return [
            for i in 1..5 do
                {|
                    Id = i
                    Title = $"Blog #{i}"
                    CreatedAt = DateTime.Now.AddDays(float i)
                |}
        ]
    }


let builder = WebApplication.CreateBuilder(Environment.GetCommandLineArgs())

builder.Services.AddControllersWithViews()
builder.Services.AddFunBlazorServer()
builder.Services.AddTransient<DbContext>()


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


app.MapGroup(endpoints "" {
    enableFunBlazor
    
    get "/blogs" {
        handle (fun (db: DbContext) -> task {
            let! blogs = db.GetBlogs()
            return div {
                childContent [
                    for blog in blogs do
                        div {
                            class' "rounded-md bg-slate-300 hover:bg-slate-600 hover:text-white hover:shadow-md mb-3 p-3 cursor-pointer"
                            h2 { blog.Title }
                            p {
                                class' "text-sm"
                                blog.CreatedAt.ToString("yyy-MM-dd HH:mm:ss")
                            }
                        }
                ]
            }
        })
    }

    get "/" {
        layout (
            section {
                div {
                    class' "text-center mt-5 text-slate-600"
                    hxGet "/blogs"
                    hxSwap_innerHTML
                    hxTarget "#blogs"
                    hxIndicator "#blogs_loader"
                    hxTrigger' (hxEvt.load, delayMs = 1000)
                    "Below is my demo blogs"
                }
                div {
                    id "blogs_loader"
                    class' "htmx-indicator text-purple-800 text-center"
                    "Loading blogs ..."
                }
                div { id "blogs" }
            }
        )
    }
})


app.Run()
