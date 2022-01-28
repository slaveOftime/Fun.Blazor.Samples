open System
open System.Threading.Tasks
open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.DependencyInjection
open GrpcDemo.Protos.Greeter


type GreeterService() =
    inherit Greeter.GreeterBase()

    override _.SayHello(req, ctx) =
        task {
            do! Task.Delay 1000
            return HelloReply(Message = "Hello from grpc")
        }


let builder = WebApplication.CreateBuilder(Environment.GetCommandLineArgs())

builder.Services.AddGrpc() |> ignore

builder.Services.AddCors(fun options ->
    options.AddPolicy(
        "AllowAll",
        fun builder ->
            builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding")
            |> ignore
    )
)
|> ignore


let app = builder.Build()

app.UseCors() |> ignore
app.UseGrpcWeb() |> ignore

app.MapGrpcService<GreeterService>().EnableGrpcWeb().RequireCors("AllowAll") |> ignore
app.MapGet("/", (fun context -> context.Response.WriteAsync("Hello World!"))) |> ignore

app.Run()
