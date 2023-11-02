namespace BlazorApp.Components.Layout

open Microsoft.AspNetCore.Components
open Fun.Blazor

type MainLayout() as this =
    inherit LayoutComponentBase()

    let content = fragment {
        div {
            class' "page"
            div {
                class' "sidebar"
                html.blazor<NavMenu> ()
            }
            main {
                div {
                    class' "top-row px-4"
                    a {
                        href "https://learn.microsoft.com/aspnet/core/"
                        target "_blank"
                        "About"
                    }
                }
                article {
                    class' "content px-4"
                    NodeRenderFragment(fun _ builder index ->
                        builder.OpenRegion(index)
                        this.Body.Invoke(builder)
                        builder.CloseRegion()
                        index + 1
                    )
                }
            }
        }
        div {
            id "blazor-error-ui"
            "An unhandled error has occurred."
            a {
                href ""
                class' "reload"
                "Reload"
            }
            a {
                class' "dismiss"
                "🗙"
            }
        }
    }


    override _.BuildRenderTree(builder) = content.Invoke(this, builder, 0) |> ignore
