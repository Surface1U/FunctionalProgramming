//---LOL---
//14

open System

let PDON n func intinial = 
    let rec SPDON n func intinial div = 
        if div = 0 then intinial 
        else 
            let nintinial = 
                if n%div = 0 then func intinial div 
                else intinial 
            let ndiv = div - 1
            SPDON n func nintinial ndiv 
    SPDON n func intinial n




[<EntryPoint>]
let main argv =
    printf "MOD: %A" (PDON 78 (fun x y -> x+y)0) 
    0 // return an integer exit code
