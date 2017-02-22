module Program 

open Google.Cloud.Vision.V1;
open System;
open System.Text.RegularExpressions
open System.IO;
open Types
open AnnotationMath

type TextLine = { orderedItems: string list } 

let printPercentOut f desc h (targetY: float) anno =
    let expectedY = f anno
    let diff = Math.Abs(targetY - expectedY)
    let percentOutOfLine = diff / h * 100.
    if diff < 100. then
        printfn "checking for %s it is %f out for line %s" desc percentOutOfLine anno.Description
    ()

let getPercentOutOfLine (line : Annotation list) item = 
    if line.Length = 0 then
       5000.
    else 
    //    let lineItemCenter = (float (getTopRightPoint lineItem).Y) + (float ((getBottomRightPoint lineItem).Y - (getTopRightPoint lineItem).Y) / 2.)
        let itemHeight = (float ((getBottomLeftPoint item).Y - (getTopLeftPoint item).Y))
    //    let itemCenter = (float (getTopLeftPoint item).Y) + itemHeight / 2.
    //
    //    let diff = Math.Abs(Math.Abs(lineItemCenter) - Math.Abs(itemCenter))
    //    let percentOutOfLine = Math.Min(diff, itemHeight) / itemHeight * 100.

        let (itemMidX, itemMidY) = getMidPoint (getTopLeftPoint item) (getBottomLeftPoint item)
        let getYForLineItemAndX = getYForLineItem itemMidX 
        let t = printPercentOut getYForLineItemAndX item.Description itemHeight itemMidY
        let o = line |> List.map t
        let avgExpected = line |> List.averageBy getYForLineItemAndX
        let diff = Math.Abs(itemMidY - avgExpected)
        diff / itemHeight * 100.
    

let isInSameLine (line : Annotation list) item = 
    let percentOutOfLine = getPercentOutOfLine line item
    //printfn "checking for %s it is %f out for line %s" item.Description percentOutOfLine (line |> List.fold (fun a b -> a + " " + b.Description) "")
    percentOutOfLine < 100.

// let fitToLine item line = 
//     match line with 
//     | [] -> (false, line)
//     | lastItem::tail -> 
// //        let x1 = (nextLineItem |> getTopRightPoint).X
// //        let x2 = (item |> getTopLeftPoint).X
// //        match x1 > x2 with 
// //        | true ->
//             match isInSameLine line item with
//             | true -> (true, item::line)
//             | false -> (false, line)
//        | false -> fitToLine item tail  

// let rec processItem item lines = 
//         match lines with 
//         | [] -> [[item]]
//         | nextLine::tail ->  
//             match fitToLine item nextLine with 
//             | (success, updatedLine) when success -> updatedLine::tail
//             | _ -> nextLine::(processItem item tail)
        
// let rec processAnnotation document lines = 
//         match document with 
//         | [] -> lines
//         | nextItem:: rest -> 
//             printfn ""
//             processItem nextItem lines 
//             |> processAnnotation rest


let printVerticies (a: EntityAnnotation) =
    let v1 = a.BoundingPoly.Vertices.[0]
    let v2 = a.BoundingPoly.Vertices.[1]
    let v3 = a.BoundingPoly.Vertices.[2]
    let v4 = a.BoundingPoly.Vertices.[3]
    sprintf "[{X = %i; Y = %i};{X = %i; Y = %i};{X = %i; Y = %i};{X = %i; Y = %i}]" v1.X v1.Y v2.X v2.Y v3.X v3.Y v4.X v4.Y

let (|ItemDesc|Price|) (str:string) =
    let m = Regex.Match(str.Trim(), "^\d.*\.\d\d$");
    if m.Success then Price else ItemDesc
        
let rec getItemDescriptionsAndPrices list = 
        match list with
        | [] -> ([], [])
        | f::rest ->
                let (descs, prices) = getItemDescriptionsAndPrices rest
                match f with
                | ItemDesc -> (f::descs, prices)
                | Price -> (descs, f::prices)

let rec matchAnnotationsToLine (lineText:string) annos =
        match annos with
        | [] -> ([], [])
        | next::tail -> 
            match lineText.Contains(next.Description) with
            | true -> let (ms, leftOver) = matchAnnotationsToLine lineText tail
                      (next::ms, leftOver)
            | false -> ([], tail)

let rec matchAnnotationsToLines lines annos =
        match lines with
            | [] -> []
            | next::tail -> let (matchingAnnos, annosLeft) = matchAnnotationsToLine next annos
                            { Text = next; Annotations = matchingAnnos; Price = None}::matchAnnotationsToLines tail annosLeft

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

[<EntryPoint>]
let main argv = 
//    let fileName = "docket3"
//    let client = ImageAnnotatorClient.Create();
//    let image = Image.FromFile(sprintf "%s.jpg" fileName);
//    let response = client.DetectText(image);
//
//    let document = [for annotation in response do yield annotation]
//    File.WriteAllLines(sprintf @"e:\%s.txt" fileName, [|for a in document do yield sprintf "{Description = \"%s\"; Verticies = %s};" a.Description (printVerticies a)|]);

    //let result = processAnnotation document []

    let compiledList::annos = getDocket3

    let list = [for a in compiledList.Description.Split('\n') do yield a];
    let (descs, _) = getItemDescriptionsAndPrices list
    let (dannos, pannos) = seperatePricesAndDesc annos 
    let lines = matchAnnotationsToLines descs dannos |> matchPrices pannos


    //let result = processAnnotation annos []
    
    
        
    for line in lines do printfn "%s %A" line.Text (if line.Price.IsSome then line.Price.Value.Description else "")   // for item in line do printfn "%s" (item.Description)
    Console.Read()
    0 // return an integer exit code

