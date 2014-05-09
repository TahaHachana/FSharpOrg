module Sitelet.Content

open IntelliFactory.Html
open IntelliFactory.WebSharper.Sitelets
open Sitelet.Nav

module Home =

    let nav ctx = navElt (Some "Home") ctx

    let body ctx : Content.HtmlElement =
        HTML5.Section [Class "featured"] -< [
                H2 [Text "News"] :> INode<_>
                new News.Control() :> _
            ]

module About =

    let nav ctx = navElt (Some "About") ctx

    let body ctx =            
        Div [Class "container"] -< [
            Div [Class "page-header"] -< [
                H1 [Text "About Page Header"]
            ]
        ]

module Sub =

    let nav ctx = navElt None ctx

    let body ctx pageId =
        Div [Class "container"] -< [
            Div [Class "page-header"] -< [
                H1 [Text <| "Sub Page " + pageId + " Header"]
            ]
        ]

module Login =

    let nav ctx = navElt None ctx

    let body action action' ctx =
        let link =
            match action with
            | Some action -> action
            | None -> action'
            |> ctx.Link
        Div [
            Div [Class "container"] -< [
                Div [new Login.Control(link)]
            ]
        ]

module Admin =

    let nav ctx = navElt None ctx

    let body ctx =
        Div [Class "container"] -< [
            Div [Class "page-header"] -< [
                H1 [Text "Admin Page Header"]
            ]
        ]

module Error =

    let nav ctx = navElt None ctx

    let body ctx =
        Div [Class "container"] -< [
            Div [Class "page-header"] -< [
                H1 [Text "Error"]
                P [Text "The requested URL doesn't exist."]
            ]
        ]