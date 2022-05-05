open System

[<EntryPoint>]
let main argv =
    let arrayA=[|1;2;3|]
    let arrayB=[|4;5;7|]
    let copy = Array.append arrayA [|Array.item(arrayB.Length-1)arrayB|]
    Console.WriteLine("arrayA=[|1;2;3|] arrayB[|4;5;7|]
    NewArr=")
    printf"%A"copy
    0 // return an integer exit code
