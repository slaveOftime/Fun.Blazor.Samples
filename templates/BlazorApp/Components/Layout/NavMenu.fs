namespace BlazorApp.Components.Layout

open System.Diagnostics.CodeAnalysis
open Microsoft.AspNetCore.Components.Routing
open Fun.Blazor
open Fun.Blazor.Operators

/// A component that renders an anchor tag, automatically toggling its 'active'
/// class based on whether its 'href' matches the current URI.
type NavLink' [<DynamicDependency(DynamicallyAccessedMemberTypes.All, typeof<NavLink>)>] () =
    inherit ComponentWithDomAndChildAttrBuilder<NavLink>()

    /// Gets or sets the computed CSS class based on whether or not the link is active.
    [<CustomOperation("ActiveClass")>]
    member inline _.ActiveClass([<InlineIfLambda>] render: AttrRenderFragment, x: string) = render ==> ("ActiveClass" => x)

    /// Gets or sets a value representing the URL matching behavior.
    [<CustomOperation("Match")>]
    member inline _.Match([<InlineIfLambda>] render: AttrRenderFragment, x: NavLinkMatch) = render ==> ("Match" => x)


type NavMenu() =
    inherit FunBlazorComponent()

    override _.Render() = fragment {
        div {
            class' "top-row ps-3 navbar navbar-dark"
            div {
                class' "container-fluid"
                a {
                    class' "navbar-brand"
                    href ""
                    "BlazorApp"
                }
            }
        }
        input {
            type' "checkbox"
            title' "Navigation menu"
            class' "navbar-toggler"
        }
        div {
            class' "nav-scrollable"
            "onclick", "document.querySelector('.navbar-toggler').click()"
            nav {
                class' "flex-column"
                div {
                    class' "nav-item px-3"
                    NavLink'() {
                        class' "nav-link"
                        href ""
                        Match NavLinkMatch.All
                        span {
                            class' "bi bi-house-door-fill"
                            "aria-hidden", "true"
                        }
                        "Home"
                    }
                }
                div {
                    class' "nav-item px-3"
                    NavLink'() {
                        class' "nav-link"
                        href "counter"
                        span {
                            class' "bi bi-plus-square-fill"
                            "aria-hidden", "true"
                        }
                        "Counter"
                    }
                }
            }
        }
    }
