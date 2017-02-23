module AnnotationMath

open Types
open System

let getMidValue (a: float) b =
        Math.Min(a, b) + Math.Abs(a - b) / 2.

let getMidPoint a b = 
    let midX = getMidValue (float a.X) (float b.X)
    let midY = getMidValue (float a.Y) (float b.Y)
    (midX, midY)

let getLineEquation ax ay bx by =
        let m = (ay - by) / (ax - bx)
        let b = ay - m * ax
        (m,b)

let getYForXOnLine x (m, b) =
        m * x + b

let getYForLineItem x lineItem = 
    let (leftMidX, leftMidY) = getMidPoint (getTopLeftPoint lineItem) (getBottomLeftPoint lineItem)
    let (rightMidX, rightMidY) = getMidPoint (getTopRightPoint lineItem) (getBottomRightPoint lineItem)

    match leftMidY = rightMidY with
        | true -> leftMidY
        | false -> getLineEquation leftMidX leftMidY rightMidX rightMidY 
                    |> getYForXOnLine x