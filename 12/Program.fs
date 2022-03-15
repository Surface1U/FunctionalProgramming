// Learn more about F# at http://fsharp.org

open System

[<EntryPoint>]
//11
let main argv =
    printfn "Какой твой любимый помидор?"
    let answer tomato  = 
        match tomato with 
        | "F#"|"Prolog"->"Я спросил про помидор"
        |"Pascal"->"Я СПРОСИЛ ПРО ПОМИДОР. Ладноо, забей"
        |"C++" -> "Я СПРОСИЛ ПРО ПОМИДОРЫ АЛЛО. Забей, чел, для тебя это слишком сложно"
        |"Чили"|"Кубанские"|"Ставропольские"|"Забугорные"|"Красные"|"Спелые" -> "Понятно." 
    //12.1
    (Console.ReadLine>>answer>>Console.WriteLine)()
    //12.2
  
    let pot (tomato:string->unit) y z =  tomato(y (z()))
    pot Console.WriteLine answer Console.ReadLine
    0