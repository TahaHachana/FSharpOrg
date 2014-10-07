module Sitelet.Shuffle

open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html
open IntelliFactory.WebSharper.JQuery
open IntelliFactory.WebSharper.EcmaScript

[<JavaScript>]
let shuffle (array:'T []) =
    let currentIndex = ref array.Length

    while !currentIndex <> 0 do
        let randomIndex = Math.Floor(Math.Random() * float !currentIndex)
        currentIndex := !currentIndex - 1
        let temporaryValue = array.[!currentIndex]
        array.[!currentIndex] <- array.[randomIndex]
        array.[randomIndex] <- temporaryValue

    array

[<JavaScript>]
let main() =
    Div []
    |>! OnAfterRender(fun _ ->
        let srcs =
            JQuery.Of(".sponsor-link")
                .ToArray()
            |> shuffle
            |> Array.map(fun elt -> elt.GetAttribute("href"), JQuery.Of(".sponsor", elt).Attr("src"))
        JQuery.Of(".sponsor-link").ToArray()
        |> Array.zip srcs
        |> Array.iter(fun ((href, src), elt) ->
            elt.SetAttribute("href", href)
            JQuery.Of(".sponsor", elt).Attr("src", src).Ignore
        )                
    )

type Control() =
    inherit Web.Control()

    [<JavaScript>]
    override __.Body = main() :> _