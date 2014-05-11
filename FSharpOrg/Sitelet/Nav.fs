module Sitelet.Nav

open IntelliFactory.Html
open IntelliFactory.WebSharper.Sitelets
open Sitelet.Model
open System

let randomize url = url + "?d=" + Uri.EscapeUriString(DateTime.Now.ToString())

let loginInfo (ctx:Context<_>) =
    let userOption = UserSession.GetLoggedInUser()
    match userOption with
        | Some user ->
            A [
                Class "navbar-right btn btn-default navbar-btn"
                HRef (randomize <| ctx.Link Action.Logout)
            ] -< [Text <| "Sign out (" + user + ")"]
        | None ->
            A [
                Class "navbar-right btn btn-default navbar-btn"
                HRef ("/login")
            ] -< [Text "Sign in"]

let navToggle =
    Button [
        Attributes.Type "button"
        Class "navbar-toggle"
        HTML5.Data "toggle" "collapse"
        HTML5.Data "target" ".navbar-collapse"
    ] -< [
        Span [Class "sr-only"] -< [Text "Toggle navigation"]
        Span [Class "icon-bar"]
        Span [Class "icon-bar"]
        Span [Class "icon-bar"]
    ]

let navHeader =
    Div [Class "navbar-header"] -< [
        navToggle
        A [Class "navbar-brand"; HRef "/"] -< [
            Img [Src "/Images/logo.png"; Alt "F# Logo"; Id "logo"]
        ]
//        A [Class "navbar-brand visible-xs"; HRef "/"] -< [Text "FSSF"]
    ]

let li activeLiOption href txt =
    match activeLiOption with
        | Some activeLi when txt = activeLi ->
            LI [Class "active"] -< [
                A [HRef href] -< [Text txt]
            ]
        | _ -> LI [A [HRef href] -< [Text txt]]

let navDiv activeLi ctx =
    Div [Class "collapse navbar-collapse"] -< [
        UL [Class "nav navbar-nav"] -< [
            li activeLi "/" "Home"
//            LI [Class "dropdown"] -< [
//                A [HRef "#"; Class "dropdown-toggle"; HTML5.Data "toggle" "dropdown"] -< [
//                    Text "Learn "
//                    B [Class "caret"]
//                ]
//                UL [Class "dropdown-menu"] -< [
//                    LI [A [HRef "#"] -< [Text "About F#"]]
//                    LI [A [HRef "#"] -< [Text "Resources"]]
//                    LI [A [HRef "#"] -< [Text "Videos"]]
//                    LI [A [HRef "#"] -< [Text "Documentation"]]
//                    LI [A [HRef "#"] -< [Text "Specification"]]
//                    LI [A [HRef "#"] -< [Text "Research"]]
//                    LI [A [HRef "#"] -< [Text "Commercial Support"]]
//                ]
//            ]
            LI [Class "dropdown"] -< [
                A [HRef "#"; Class "dropdown-toggle"; HTML5.Data "toggle" "dropdown"] -< [
                    Text "Contribute "
                    B [Class "caret"]
                ]
                UL [Class "dropdown-menu"] -< [
                    LI [A [HRef "#"] -< [Text "Mailing List"]]
                    LI [A [HRef "#"] -< [Text "Projects"]]
                    LI [A [HRef "#"] -< [Text "Blogs"]]
                    LI [A [HRef "#"] -< [Text "GitHub"]]
                    LI [A [HRef "#"] -< [Text "CodePlex"]]
                    LI [A [HRef "#"] -< [Text "Code Snippets"]]

                ]
            ]
            li activeLi "#" "Teach"
            LI [Class "dropdown"] -< [
                A [HRef "#"; Class "dropdown-toggle"; HTML5.Data "toggle" "dropdown"] -< [
                    Text "Applications "
                    B [Class "caret"]
                ]
                UL [Class "dropdown-menu"] -< [
                    LI [A [HRef "#"] -< [Text "Data Science"]]
                    LI [A [HRef "#"] -< [Text "Web programming"]]
                    LI [A [HRef "#"] -< [Text "Apps and games"]]
                    LI [A [HRef "#"] -< [Text "Machine learning"]]
                    LI [A [HRef "#"] -< [Text "Cloud programming"]]
                    LI [A [HRef "#"] -< [Text "Financial computing"]]
                    LI [A [HRef "#"] -< [Text "Math and statistics"]]
                    LI [A [HRef "#"] -< [Text "Data Access"]]

                ]
            ]

            li activeLi "/" "Testimonials"
            li activeLi "#" "Foundation"
        ]
//        loginInfo ctx
    ]

let navElt activeLi ctx : Content.HtmlElement =
    HTML5.Nav [
        Class "navbar navbar-default navbar-fixed-top"
        NewAttribute "role" "navigation"
    ] -< [
        Div [Class "container"] -< [
            navHeader
            navDiv activeLi ctx
        ]
    ]