namespace HtmxApp

open Fun.Blazor

type Layout =
    
    static member Create(node: NodeRenderFragment) = fragment {
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