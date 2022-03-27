//---LOL---
//17


open System

let rec nod a b = 
    if(a>0 && b>0)
    then if(a>b)
          then nod (a%b) b
          else nod a (b%a)
    else if (a = 0)
        then b 
        else a 

let rec rf n f init known cond =
    let unnown = known - 1 
    if (known = 0) then init 
    else if ((nod n known) = 1 && cond known)
    then 
        let Ninit = (f init known)
        rf n f Ninit unnown cond
    else rf n f init unnown cond

let ff n f init cond = 
    rf n f init (n-1) cond

//let Eiler n = 
  //  ff n (fun x y -> x+1) 0

let rec rff n f init known cond = 
    if known = 0 then init 
    else if ((n%known) = 0 && cond known)
    then 
        let Ninit = (f init known)
        rff n f Ninit (known-1) cond
    else rff n f init (known - 1) cond
let ffor n (f:int ->int ->int) init cond= 
    rff n f init n cond

[<EntryPoint>]
let main argv =
    let num = 11
    //printfn "%b" (10 = Eiler  num)
    printfn "%b" (1+3+5+7+9 = ff num (fun x y -> x+y) 0 (fun x -> x%2 = 1))
    printfn "%b" (2*4*6*8*10 = ff num (fun x y -> x*y) 1 (fun x -> x%2 = 0))
    0 // return an integer exit code
