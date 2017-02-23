module SaveData

open Google.Cloud.Vision.V1;

let printVerticies (a: EntityAnnotation) =
    let v1 = a.BoundingPoly.Vertices.[0]
    let v2 = a.BoundingPoly.Vertices.[1]
    let v3 = a.BoundingPoly.Vertices.[2]
    let v4 = a.BoundingPoly.Vertices.[3]
    sprintf "[{X = %i; Y = %i};{X = %i; Y = %i};{X = %i; Y = %i};{X = %i; Y = %i}]" v1.X v1.Y v2.X v2.Y v3.X v3.Y v4.X v4.Y