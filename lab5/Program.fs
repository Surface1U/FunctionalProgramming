//---LOL---

open System

let rec mult a = 
    match a with 
    |0->1
    |a->(a%10)*mult(a/10)

let rec max a n = 
    match a with 
    |a when a = 0 ->n
    |a when a%10>n -> max (a/10) (a%10)
    |a when a%10<n ->max (a/10) n

let rec min a n =
    match a with 
    | a when a =0 ->n
    | a when a%10<n -> min (a/10) (a%10)
    | a when a%10>n -> min (a/10) n

let rec multc x a = 
    match x with 
    |x when x =0-> a
    |x->multc (x/10) (a*x%10)

let rec multdown x = multc x 1

[<EntryPoint>]
let main argv =
    let x = 123
    printf "Rec up: "
    printf "%d" (mult x) 
    printf ","
    printf "%d" (max x 0)
    printf ","
    printf "%d" (min x 9)
    printf ","
    printf "Rec down: "
    printf "%d" (multdown x)



    0 // return an integer exit code
