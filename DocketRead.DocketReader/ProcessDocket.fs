module ProcessDocket 

open System
open Types
open AnnotationMath

let getPercentOutOfLine (line : Annotation list) item = 
    if line.Length = 0 then
       5000.
    else 
        let itemHeight = (float ((getBottomLeftPoint item).Y - (getTopLeftPoint item).Y))
        let (itemMidX, itemMidY) = getMidPoint (getTopLeftPoint item) (getBottomLeftPoint item)
        let getYForLineItemAndX = getYForLineItem itemMidX        
        let avgExpected = line |> List.averageBy getYForLineItemAndX
        let diff = Math.Abs(itemMidY - avgExpected)
        diff / itemHeight * 100.

let rec matchAnnotationsToLine (lineText:string) annos =
        match annos with
        | [] -> ([], [])
        | annotation::tail -> 
            match lineText.Contains(annotation.Description) with
            | true -> let (matchingAnnotations, leftOver) = matchAnnotationsToLine lineText tail
                      (annotation::matchingAnnotations, leftOver)
            | false -> ([], tail)

let rec matchAnnotationsToLines lines annos lastId =
        match lines with
            | [] -> []
            | lineText::tail -> 
                            let (matchingAnnos, annosLeft) = matchAnnotationsToLine lineText annos
                            let id = lastId + 1
                            { Id = id; Text = lineText; Annotations = matchingAnnos; Price = None}::matchAnnotationsToLines tail annosLeft id

let rec seperatePricesAndDesc annos =
    match annos with
    | [] -> ([], [])
    | annotation::tail -> 
                    let (descriptions, prices) = seperatePricesAndDesc tail
                    match annotation.Description with
                    | ItemDesc -> (annotation::descriptions, prices)
                    | Price -> (descriptions, annotation::prices)


let rec matchPrices prices lines =
        match prices with
        | [] -> []
        | price::tail ->    let line = List.minBy (fun x -> getPercentOutOfLine x.Annotations price) lines                  
                            { line with Price = Some price }::matchPrices tail lines

let rec mergePriceLines linesWithPrice lines =
        ((List.filter 
            (fun line -> 
                (List.forall (fun lineWithPrice -> 
                                line.Id <> lineWithPrice.Id) linesWithPrice)) lines) 
                        @ linesWithPrice) 
                        |> List.sortBy (fun line -> line.Id)

let rec collapseDoubleLines lines = 
        match lines with
        | [] -> []
        | line::tail -> 
                match collapseDoubleLines tail with
                | [] -> [line]
                | prevLine::prevTail ->
                    match line.Price with
                    | Some _ -> line::prevLine::prevTail
                    | None ->
                        match prevLine.Text with 
                        | KiloMeasure | Quantity ->
                            let mergedLine = { prevLine with Text = sprintf "%s %s" line.Text prevLine.Text }
                            mergedLine::prevTail
                        | _ -> line::prevLine::prevTail


let processDocketData compiledList annos = 
    let list = [for a in compiledList.Description.Split('\n') do yield a.Trim()];
    let descs = List.filter (fun x -> match x with | ItemDesc -> true | _ -> false) list
    let (dannos, pannos) = seperatePricesAndDesc annos 
    let lines = matchAnnotationsToLines descs dannos 0
    let linesWithPrice = matchPrices pannos lines

    mergePriceLines linesWithPrice lines |> collapseDoubleLines