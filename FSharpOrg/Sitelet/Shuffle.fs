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

type Testimonial =
    {
        Permalink : string
        Text : string
        Link : string
        Author : string
    }

[<JavaScript>]
let main() =
    Div []
    |>! OnAfterRender(fun _ ->
        // supporters
        let srcs =
            JQuery.Of(".carousel-link")
                .ToArray()
            |> shuffle
            |> Array.map(fun elt -> elt.GetAttribute("href"), JQuery.Of(".carousel-img", elt).Attr("src"))
        JQuery.Of(".carousel-link").ToArray()
        |> Array.zip srcs
        |> Array.iter(fun ((href, src), elt) ->
            elt.SetAttribute("href", href)
            JQuery.Of(".carousel-img", elt).Attr("src", src).Ignore
        )   
        
        // testimonials
        JQuery.GetJSON("testimonials.json", (fun (json, _) ->
            As<Testimonial []> json
            |> shuffle
            |> fun arr -> arr.[..5]
            |> Array.map (fun x ->
                BlockQuote [
                    P [A [HRef x.Permalink; Attr.Class "testimonial"; Text x.Text]]
                    HTML5.Tags.Footer [
                        Cite [
                            A [
                                HRef x.Permalink
//                                Attr.Target "_blank"
                                Text x.Author
                            ]
                        ]
                    ]
                ]
            )
            |> fun arr ->
                let jq1 = JQuery.Of("#testimonials-col-1").Empty()
                arr.[..2] |> Array.iter(fun elt -> jq1.Append elt.Dom |> ignore)
                let jq2 = JQuery.Of("#testimonials-col-2").Empty()
                arr.[3..] |> Array.iter(fun elt -> jq2.Append elt.Dom |> ignore)
            )
        ) |> ignore
    )

type Control() =
    inherit Web.Control()

    [<JavaScript>]
    override __.Body = main() :> _