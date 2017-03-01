namespace DocketRead.DocketReader

open OCR
open ProcessDocket

type Vision() =
    member this.GetFromBytes file = 
                let result = getFromBytes file
                match result with 
                | [] -> []
                | compiledList::tail ->
                    processDocketData compiledList tail