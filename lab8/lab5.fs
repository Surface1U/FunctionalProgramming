
open System

type MyOption<'T> =
    |None
    |Some of 'T


let mapMyOption func value = 
    match value with 
    |Some T -> Some (func T)

let (<*>) func value = 
    match func,value with 
    |Some f, Some v -> Some (f v)
    |_-> None 

let applyMyoption2 value func=
    match func, value with 
    |Some f,Some v -> Some(f v)
    |_-> None 

let monadMyOption func opt =
    match opt with 
    |Some x -> func x
    |None -> None 

let (>>=) x func = monadMyOption func x


let isPositive num=
    match num with 
    |0->None 
    |x-> Some (x>0)

let ForDemo =

    let id x =x 
    printfn "1. \n Lifted %A = NOT Lifted %A \n" (mapMyOption id (Some 5)) (id (Some 5))
    printfn "2. Functor law: "

    let func_f x = x+1
    let func_g x = x*2
    let some_1 = mapMyOption func_f (Some 2)
    let some_2 = mapMyOption func_g (some_1)

    printf "Composition of lifted f & g func's =%A" (some_2)
    let some_1_2 = mapMyOption (func_f>>func_g) (Some 2)
    printf "Поднятая композиция лол = %A \n\n" (some_1_2)

    printfn "Апликативные laws:"
    printf "1."
    let law11 = id 1
    let law12 = (Some id) <*> (Some 1)
    printf "Оба не лифтед = %A \nОба Лифтед лол = %A" (law11) (law12)

    printf "\n2."

    let law2_f = fun x -> x+1
    let law2_x = 9
    let law2_y =  (Some (law2_f law2_x))
    let law2_y2 = (Some law2_f) <*> (Some law2_x)
    printf "Поднятый игорь(y) = %A\nLifted y & x then applied = %A" (law2_y) (law2_y2)
    

    printf "\n3."

    let law31 =  (Some (fun x -> x*2)) <*> (Some 4)
    let law32 = applyMyoption2 (Some 4) (Some (fun x -> x*2))
    printf "Не поменялось = %A\nSwapped = %A" (law31) (law32)
    printf "Поскольку мы были вынуждены создать новую функцию, чтобы она соответствовала третьему закону,\закон на самом деле не выполняется!"

    printfn "\n4."

    printfn "The fourth law cannot be fulfilled because the \"<*>\" operator doesn't support associative laws"
    printfn "\nJust for demonstration of monad (Some 5 >>= isPositive): %A" (Some 5 >>= isPositive)


