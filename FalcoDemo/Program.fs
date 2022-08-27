module FalcoDemo.Program

open System
open Falco
open Falco.Markup
open Falco.Routing
open Falco.HostBuilder
open Fun.Blazor
open Microsoft.Extensions.DependencyInjection


module Response =

    let ofFunHtml node : HttpHandler = fun ctx -> ctx.WriteFunDom node


let falcoForm =
    Templates.html5 "en" [] [
        Elem.body [] [
            Elem.form [ Attr.method "post" ] [
                Elem.input [ Attr.name "Person.first_name" ]
                Elem.input [ Attr.name "Person.last_name" ]
                Elem.br []
                Elem.input [ Attr.type' "Submit" ]
            ]
        ]
    ]

let funForm = fragment {
    doctype "html"
    html' {
        lang "en"
        body {
            form {
                method "post"
                input { name "Person.first_name" }
                input { name "Person.last_name" }
                br
                input { type' "Submit" }
            }
        }
    }
}

webHost (Environment.GetCommandLineArgs()) {
    add_service (fun services ->
        services.AddControllersWithViews() |> ignore
        services.AddFunBlazorServer()
    )
    endpoints [
        get "/ping" (Response.ofPlainText "pong")
        get "/fun-form" (Response.ofFunHtml funForm)
        get "/falco-form" (Response.ofHtml falcoForm)
    ]
}
