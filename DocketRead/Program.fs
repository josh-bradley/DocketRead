module Program 

open Google.Cloud.Vision.V1;
open System;
open System.IO;
open Types
open AnnotationMath
open TestData

//let printPercentOut f desc h (targetY: float) anno =
//    let expectedY = f anno
//    let diff = Math.Abs(targetY - expectedY)
//    let percentOutOfLine = diff / h * 100.
//    if diff < 100. then
//        printfn "checking for %s it is %f out for line %s" desc percentOutOfLine anno.Description
//    ()

let getPercentOutOfLine (line : Annotation list) item = 
    if line.Length = 0 then
       5000.
    else 
        let itemHeight = (float ((getBottomLeftPoint item).Y - (getTopLeftPoint item).Y))
        let (itemMidX, itemMidY) = getMidPoint (getTopLeftPoint item) (getBottomLeftPoint item)
        let getYForLineItemAndX = getYForLineItem itemMidX 
        //let t = printPercentOut getYForLineItemAndX item.Description itemHeight itemMidY
        //let o = line |> List.map t
        let avgExpected = line |> List.averageBy getYForLineItemAndX
        let diff = Math.Abs(itemMidY - avgExpected)
        diff / itemHeight * 100.
    

let isInSameLine (line : Annotation list) item = 
    let percentOutOfLine = getPercentOutOfLine line item
    //printfn "checking for %s it is %f out for line %s" item.Description percentOutOfLine (line |> List.fold (fun a b -> a + " " + b.Description) "")
    percentOutOfLine < 100.

let rec matchAnnotationsToLine (lineText:string) annos =
        match annos with
        | [] -> ([], [])
        | next::tail -> 
            match lineText.Contains(next.Description) with
            | true -> let (ms, leftOver) = matchAnnotationsToLine lineText tail
                      (next::ms, leftOver)
            | false -> ([], tail)

let rec matchAnnotationsToLines lines annos lastId =
        match lines with
            | [] -> []
            | next::tail -> let (matchingAnnos, annosLeft) = matchAnnotationsToLine next annos
                            let newId = lastId + 1
                            { Id = newId; Text = next; Annotations = matchingAnnos; Price = None}::matchAnnotationsToLines tail annosLeft newId

let rec seperatePricesAndDesc annos =
    match annos with
    | [] -> ([], [])
    | f::tail -> 
            let (descs, prices) = seperatePricesAndDesc tail
            match f.Description with
            | ItemDesc -> (f::descs, prices)
            | Price -> (descs, f::prices)


let rec matchPrices prices lines =
        match prices with
        | [] -> []
        | p::tail ->    let line = List.minBy (fun x -> getPercentOutOfLine x.Annotations p) lines                  
                        { line with Price = Some p }::matchPrices tail lines 

let rec collapseDoubleLines lines = 
        match lines with
        | [] -> []
        | f::tail -> 
                match collapseDoubleLines tail with
                | [] -> [f]
                | p::pt ->
                    match f.Price with
                    | Some _ -> f::p::pt
                    | None ->
                        match p.Text with 
                        | KiloMeasure | Quantity -> 
                            let o = { p with Text = sprintf "%s %s" f.Text p.Text }
                            o::pt 
                        | _ -> f::p::pt

[<EntryPoint>]
let main argv = 
//    let fileName = "docket3"
//    
//    let client = ImageAnnotatorClient.Create();
//    
//    let image = Image.FromFile(sprintf "%s.jpg" fileName);
//    let response = client.DetectText(image);
//
//    let compiledList::annos = [for anno in response do yield  { Description = anno.Description; Verticies = [for v in anno.BoundingPoly.Vertices do yield { X = v.X; Y = v.Y }]}]
//    File.WriteAllLines(sprintf @"e:\%s.txt" fileName, [|for a in document do yield sprintf "{Description = \"%s\"; Verticies = %s};" a.Description (printVerticies a)|]);

    //let result = processAnnotation document []

    let compiledList::annos = getDocket3

    let list = [for a in compiledList.Description.Split('\n') do yield a];
    let descs = List.filter (fun x -> match x with | ItemDesc -> true | _ -> false) list
    let (dannos, pannos) = seperatePricesAndDesc annos 
    let lines = matchAnnotationsToLines descs dannos 0
    let linesWithPrice = matchPrices pannos lines

    let ml = ((List.filter (fun x -> (List.forall (fun y -> x.Id <> y.Id) linesWithPrice)) lines) @ linesWithPrice) |> List.sortBy (fun x -> x.Id)
    let cl = collapseDoubleLines ml

    for line in cl do printfn "%s %s" line.Text (if line.Price.IsSome then line.Price.Value.Description else String.Empty)
    Console.Read()
    0 // return an integer exit code