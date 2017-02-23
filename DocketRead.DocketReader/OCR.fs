module OCR

open Types
open Google.Cloud.Vision.V1

let processImage image = 
    let client = ImageAnnotatorClient.Create()
    let response = client.DetectText(image)
    [for anno in response do yield  { Description = anno.Description; Verticies = [for v in anno.BoundingPoly.Vertices do yield { X = v.X; Y = v.Y }]}]