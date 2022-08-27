#r "nuget: NBomber"

open System.Net.Http
open FSharp.Control.Tasks.NonAffine
open NBomber.Contracts
open NBomber.FSharp


let httpClient = new HttpClient()


Scenario.create "Ping" [
    Step.create (
        "fetch ping",
        fun _ -> task {
            let! response = httpClient.GetAsync("https://localhost:62162/ping")
            return if response.IsSuccessStatusCode then Response.ok () else Response.fail ()
        }
    )
]
|> NBomberRunner.registerScenario
|> NBomberRunner.run
|> printfn "%A"


Scenario.create "Fun.Blazor" [
    Step.create (
        "fetch fun-form",
        fun _ -> task {
            let! response = httpClient.GetAsync("https://localhost:62162/fun-form")
            return if response.IsSuccessStatusCode then Response.ok () else Response.fail ()
        }
    )
]
|> NBomberRunner.registerScenario
|> NBomberRunner.run
|> printfn "%A"


Scenario.create "Falco.Marup" [
    Step.create (
        "fetch falco-form",
        fun _ -> task {
            let! response = httpClient.GetAsync("https://localhost:62162/falco-form")
            return if response.IsSuccessStatusCode then Response.ok () else Response.fail ()
        }
    )
]
|> NBomberRunner.registerScenario
|> NBomberRunner.run
|> printfn "%A"
