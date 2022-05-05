//задача 2

let ordered str=
    let new_string=String.filter(fun ch->Char.IsLower(ch)) str      //переводим символы сьроки на нижний регистр
    let make_list=Seq.toList(new_string)
    let check=List.map2(fun ch1 ch2-> ch1<=ch2) make_list.[0..make_list.Length-2] make_list.[1..make_list.Length-1]   //проверка на упорядоченность двух элементов
    if (List.fold (fun s x-> if x=false then s+1 else s) 0 check) = 0 then Console.WriteLine("Символы строки упорядочены")   
    else Console.WriteLine("Символы строки  не упорядочены")
