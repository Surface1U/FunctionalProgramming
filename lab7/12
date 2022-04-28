open System

//заполение списка
let rec readList n =
    List.init(n) (fun index->Console.ReadLine()|>Int32.Parse)

let readData = 
    Console.WriteLine("Введите размерность списка:  ")
    let n=System.Convert.ToInt32(System.Console.ReadLine())
    Console.WriteLine("Введите список: ")
    readList n

let rec writeList = function
    [] ->   let z = System.Console.ReadKey()
            0
    | (head : int)::tail -> 
                       System.Console.WriteLine(head)
                       writeList tail  

//переставить в обратном порядке элементы массива, расположенные между его минимальным и максимальным элементами

let min list=List.findIndex(fun x->x=List.min list) list
let max list=List.findIndex(fun x->x=List.max list) list

let resh list= 
    let start=Math.Min(max list,min list)
    let finish=Math.Max(min list,max list)
    let pieces=list.[start+1..finish-1]
    list.[0..start]@ (List.rev pieces) @ list.[finish..list.Length-1]

[<EntryPoint>]
let main argv =
    let l=readData
    Console.WriteLine("Новый список:")
    writeList(resh l)
    0 
