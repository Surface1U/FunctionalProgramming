let rec readlistdouble n =
    if n = 0 then []
    else
    let Head = Console.ReadLine()|>Convert.ToDouble
    let Tail = readlistdouble (n-1)
    Head::Tail

let readData = 
    Console.WriteLine("Введите размерность списка:  ")
    let n=System.Convert.ToInt32(System.Console.ReadLine())
    Console.WriteLine("Введите список: ")
    readlistdouble n

let check (list:float list)=
    let rec check2 list b=
        match list with
        | []-> true
        | h::t-> 
            if ((h%1.0=0.0 && b%1.0=0.0) ||(h%1.0<>0.0 && b%1.0<>0.0)) then false     //проверяем обратное
            else check2 t h
    check2 list.Tail list.Head

[<EntryPoint>]
let main argv =
    let n = Console.ReadLine()|> Int32.Parse
    let list = readData 
    Console.WriteLine(check list)
    0 // return an integer exit code
