[<AutoOpen>]
module MudBlazorThreeAuth.Endpoints.AccountExtensions

open System
open System.Security.Claims
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Routing
open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Authentication
open Microsoft.AspNetCore.Authentication.Cookies

// I am using asp.net core minimal APIs here, you can use others like controller/giraffe etc.
type IEndpointRouteBuilder with

    member endpoint.MapAccountApi() =
        endpoint.MapPost(
            "/api/login",
            Func<_, _, _>(fun (ctx: HttpContext) (returnUrl: string) -> task {
                let user = ctx.Request.Form["User"]
                let password = ctx.Request.Form["Password"]

                // Handle authentication

                let issuer = "demo"
                let claims = [ Claim(ClaimTypes.Name, user, ClaimValueTypes.String, issuer) ]

                let userIdentity =
                    ClaimsIdentity(
                        claims,
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        ClaimsIdentity.DefaultNameClaimType,
                        ClaimsIdentity.DefaultRoleClaimType
                    )

                let userPrincipal = ClaimsPrincipal(userIdentity)

                let authProperties =
                    AuthenticationProperties(ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1), IsPersistent = true, AllowRefresh = false)

                do! ctx.SignInAsync(userPrincipal, authProperties)

                if String.IsNullOrEmpty returnUrl |> not then
                    return Results.Redirect(returnUrl)
                else
                    return Results.Ok()
            })
        )
        |> ignore

        endpoint.MapPost(
            "/api/logout",
            Func<_, _>(fun (ctx: HttpContext) -> task {
                do! ctx.SignOutAsync()
                return Results.Redirect("/")
            })
        )
        |> ignore
