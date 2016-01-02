
type Testimonial =
    {
        Text : string
        Link : string
        Author : string
    }

let testimonials =
    [
        {
            Text = "We see great potential for F# to be used as a scripting language in CAD, it fits very well for computational design challenges in the construction industry."
            Link = "http://www.waagner-biro.com/en/company/news-press/news/oriental-jewel-by-waagner-biro-the-domed-roof-of-the-louvre-abu-dhabi"
            Author = "Goswin Rothenthal"
        }
        {
            Text = "When F# is combined with Visual Studio� productivity goes through the roof!"
            Link = "http://webhome.cs.uvic.ca/~nigelh/"
            Author = "Prof Nigel Horspool"
        }
        {
            Text = "I have now delivered three business critical projects written in F#. I am still waiting for the first bug to come in."
            Link = "http://www.simontylercousins.net/journal/2013/2/22/does-the-language-you-choose-make-a-difference.html"
            Author = "Simon Cousins"
        }
        {
            Text = "The simple, well-designed and powerful core of the language was perfect for introducing the fundamental concepts of functional programming."
            Link = "http://www2.imm.dtu.dk/~mire"
            Author = "Michael R. Hansen"
        }
        {
            Text = "F# is the night vision goggles I need when I go into the dark and attempt to solve previously unsolved problems."
            Link = "http://research.microsoft.com/en-us/people/bycook/"
            Author = "Professor Byron Cook"
        }
        {
            Text = "We would recommend F# as an additional tool in the kit of any company building software on the .NET stack."
            Link = "http://15below.com/"
            Author = "Michael Newton"
        }
        {
            Text = "At Credit Suisse, we�ve been using F# to develop quantitative models for financial products."
            Link = "http://cufp.org/archive/2008/abstracts.html#MansellHoward"
            Author = "Howard Mansell"
        }
        {
            Text = "Grange Insurance parallelized its rating engine to take better advantage of multicore server hardware."
            Link = "http://www.microsoft.com/casestudies/case_study_detail.aspx?casestudyid=4000005226"
            Author = "Grange Insurance"
        }
        {
            Text = "Our risk and analytic capabilities (�) are entirely written in F#."
            Link = "http://cufp.org/users/lawrenceausten"
            Author = "Lawrence Austen"
        }
        {
            Text = "The F# solution offers us an order of magnitude increase in productivty."
            Link = "http://www.dotnetrocks.com/default.aspx?showNum=846"
            Author = "Yan Cui"
        }
        {
            Text = "At a major Investment Bank, we used F# to build an Early Warning Indicator System for Liquidity Risk."
            Link = "http://docs.cepheis.com/present/Early%20Warning%20Indicators.pdf"
            Author = "Stephen Channell"
        }
        {
            Text = "The efficient use of functional programming throughout the R&D cycle helped make the cycle faster and more efficient."
            Link = "http://stevanovichcenter.uchicago.edu/conferences/fp/Program.html"
            Author = "Moody Hadi"
        }
        {
            Text = "F# allows you to move smoothly in your programming style."
            Link = "http://www.slideshare.net/lgayowski/taking-functional-programming-into-the-mainstream-eclipse-summit-europe-2009"
            Author = "Julien Laugel"
        }
        {
            Text = "Type providers made working with external data sources simple and intuitive."
            Link = "http://propertytorenovate.co.uk/"
            Author = "Jon Canning"
        }
        {
            Text = "Around 95% of the code in these projects has been developed in F#."
            Link = "http://research.microsoft.com/en-us/events/2012summerschool/kenjifsharpfphdsummerschool2012new.pdf"
            Author = "Anton Schwaighofer"
        }
        {
            Text = "F# will continue to be our language of choice for scientific computing."
            Link = "http://research.microsoft.com/biology"
            Author = "Dr. Andrew Phillips"
        }
        {
            Text = " evaluated F# and it and found that for certain tasks it was better than C# in terms of performance while maintaining suitable readability."
            Link = "http://www.atalasoft.com/cs/blogs/stevehawley/archive/2011/08/01/building-pure-managed-dotimage.aspx"
            Author = "Atalasoft"
        }
        {
            Text = "This software provides the user with maximum flexibility to move quickly through multiple images."
            Link = "http://www.forensic-software.com/"
            Author = "Forensic Software"
        }
        {
            Text = "F# rocks ... building out various algorithms for DNA processing here and it�s like a drug."
            Link = "http://research.microsoft.com/en-us/events/2012summerschool/kenjifsharpfphdsummerschool2012new.pdf"
            Author = "Darren Platt"
        }
        {
            Text = "The power and flexibility of the language lets us ship features faster, with fewer bugs."
            Link = "http://reminderhero.com/"
            Author = "Marty Dill"
        }
    ]

testimonials.Length


#r """C:\Users\AHMED\Documents\GitHub\FSharpOrg\FSharpOrg\packages\Newtonsoft.Json.6.0.5\lib\net45\Newtonsoft.Json.dll"""

open Newtonsoft.Json

let json = JsonConvert.SerializeObject(testimonials, Formatting.Indented)

