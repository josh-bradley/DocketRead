module Types

open System.Text.RegularExpressions

type AnnotationVerticy = { X: int; Y: int }
type Annotation = { Description: string; Verticies: AnnotationVerticy list}

type Price = Annotation
type LineDetails = { Id: int; Text: string; Annotations: Annotation list; Price: Option<Price> }

type Verticy = TopLeft | TopRight | BottomLeft | BottomRight

let getPoint v (anno : Annotation) = 
    let idx =  match v with 
                | TopLeft -> 0
                | TopRight -> 1
                | BottomRight -> 2
                | BottomLeft -> 3

    anno.Verticies.[idx]

let getTopLeftPoint = getPoint TopLeft
let getTopRightPoint = getPoint TopRight
let getBottomLeftPoint = getPoint BottomLeft
let getBottomRightPoint = getPoint BottomRight

let (|ItemDesc|Price|) (str:string) =
    let m = Regex.Match(str.Trim(), "^\d.*\.\d\d$");
    if m.Success then Price else ItemDesc

let (|KiloMeasure|Quantity|Other|) (str:string) =
    let mk = Regex.Match(str.Trim(), "^\d.\d{3} kg")
    if mk.Success then
        KiloMeasure
    else if Regex.Match(str.Trim(), "^Qty").Success then
        Quantity
    else
        Other