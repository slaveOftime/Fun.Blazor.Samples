[<AutoOpen>]
module WASMShoelace.JsInterop

open System
open Microsoft.AspNetCore.Components
open FSharp.Data.Adaptive
open Fun.Blazor


type SlChangeEventArgs() =
    inherit EventArgs()

    member val Value = null with get, set


[<EventHandler("onsl-change", typeof<SlChangeEventArgs>, enableStopPropagation = true, enablePreventDefault = true)>]
[<AbstractClass; Sealed>]
type EventHandlers = class end


let jsInterops =
    fragment {
        js """
            Blazor.registerCustomEventType('sl-change', {
                browserEventName: 'sl-change',
                createEventArgs: event => {
                    return {
                        value: event.target.value
                    };
                }
            });
        """
    }