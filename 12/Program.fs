// Learn more about F# at http://fsharp.org

open System

[<EntryPoint>]
//11
let main argv =
    printfn "Какой твой любимый помидор?"
    let answer tomato  = 
        match tomato with 
        |"F#" | "Prolog" -> printfn "Подлиза"
        |"python" -> printfn "Дорога на Арарат"
        |"С++" -> printfn "Не стоит"
        |"С#" -> printfn "мой любимый язык, если что"
        |other -> printfn "хочу кушать."
    //12.1
    (Console.ReadLine>>answer>>Console.WriteLine)()
    //12.2
  
    let pot (tomato:string->unit) y z =  tomato(y (z()))
    pot Console.WriteLine answer Console.ReadLine
    0
