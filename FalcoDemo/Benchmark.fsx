#r "nuget:NBomber, 4.1.2"

open System
open System.Net.Http
open FSharp.Control.Tasks.NonAffine
open NBomber.FSharp
open NBomber.CSharp


let httpClient = new HttpClient()

let bomb senario =
    senario
    |> Scenario.withLoadSimulations [ 
        Simulation.Inject(rate = 10, interval = TimeSpan.FromSeconds 1, during = TimeSpan.FromSeconds 60)
    ]
    |> NBomberRunner.registerScenario
    |> NBomberRunner.run
    |> ignore


Scenario.create("Ping", fun _ -> task {
    let! response = httpClient.GetAsync("https://localhost:5001/ping")
    return if response.IsSuccessStatusCode then Response.ok () else Response.fail ()
})
|> bomb


Scenario.create("Fun.Blazor", fun _ -> task {
    let! response = httpClient.GetAsync("https://localhost:5001/fun-form")
    return if response.IsSuccessStatusCode then Response.ok () else Response.fail ()
})
|> bomb


Scenario.create("Falco.Marup", fun _ -> task {
    let! response = httpClient.GetAsync("https://localhost:5001/falco-form")
    return if response.IsSuccessStatusCode then Response.ok () else Response.fail ()
})
|> bomb
