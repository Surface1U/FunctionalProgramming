//---LOL---
//15


open System

let rec nod a b = 
    if(a>0 && b>0)
    then if(a>b)
          then nod (a%b) b
          else nod a (b%a)
    else if (a = 0)
        then b 
        else a 

let rec rf n f init known =
    let unnown = known - 1 
    if (known = 0) then init 
    else if ((nod n known) = 1)
    then 
        let Ninit = (f init known)
        rf n f Ninit unnown 
    else rf n f init unnown

let ff n f init = 
    rf n f init (n-1)





[<EntryPoint>]
let main argv =
    let n = 17
    printfn "%i" (ff n (fun x y -> x+y) 0)
    0 // return an integer exit code
