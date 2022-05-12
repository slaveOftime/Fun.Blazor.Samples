[<AutoOpen>]
module WASMShoelace.Stores

open System.Net.Http
open Fun.Blazor


type IShareStore with


    member store.I18n = store.CreateCVal(nameof store.I18n, I18n())


type IComponentHook with

    member hook.InitI18n() =
        hook.OnFirstAfterRender.Add(fun () ->
            task {
                let store, http = hook.ServiceProvider.GetMultipleServices<IShareStore * HttpClient>()
                let! result = http.GetStringAsync("/i18n/en-US/app.json")
                store.I18n.Publish(I18n result)
            }
            |> ignore
        )
