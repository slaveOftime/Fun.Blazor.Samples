open System
open Microsoft.Extensions.DependencyInjection
open Microsoft.AspNetCore.Components.WebAssembly.Hosting
open Grpc.Net.Client
open Grpc.Net.Client.Web
open System.Net.Http


let builder = WebAssemblyHostBuilder.CreateDefault(Environment.GetCommandLineArgs())

builder
    .AddFunBlazor("#app", app)
    .Services
    .AddSingleton<GrpcChannel>(fun (_: IServiceProvider) ->
        let httpHandler = new GrpcWebHandler(GrpcWebMode.GrpcWebText, new HttpClientHandler())
        GrpcChannel.ForAddress("https://localhost:5001", GrpcChannelOptions(HttpHandler = httpHandler))
    )
    .AddFunBlazorWasm()
|> ignore

builder.Build().RunAsync() |> ignore
