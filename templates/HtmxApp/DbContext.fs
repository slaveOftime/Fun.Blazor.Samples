namespace HtmxApp

open System
open System.Threading.Tasks

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