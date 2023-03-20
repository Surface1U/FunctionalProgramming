
open System
open System.Drawing
open System.IO
open System.Windows.Forms
[<EntryPoint>]
let main argv =
    Application.EnableVisualStyles()
    Application.SetCompatibleTextRenderingDefault(false)
    
    //Top-y Left-x

    let form = new Form(Text = "Работа с массивами" ,Width = 815, Height = 452)
    let text = new Label(Font = new Font(familyName = "Segoe UI",emSize = 15.0f), Height = 30, Width= 550,Top = 3, Left = 340, Text="Введите список")
    let text1 = new Label(Font = new Font(familyName = "Segoe UI",emSize = 15.0f),Width = 200, Top = 50, Height = 70, Left = 0,Text="Список для сортировки")
    let text3 = new Label(Font = new Font(familyName = "Segoe UI",emSize = 15.0f),Width = 200, Top = 190, Height = 70, Left = 0, Text="Отсортированный список")
    let richTextBox2 = new RichTextBox(Font = new Font(familyName = "Segoe UI",emSize = 22.0f),Width = 500, Top = 50, Height = 70, Left = 200,Text="1,2,3")
    let richTextBox4 = new RichTextBox(Font = new Font(familyName = "Segoe UI",emSize = 22.0f),Width = 500, Top = 190,Height = 70, Left = 200,Text="")
    let button1 = new Button(Height=80, Width = 300, Top = 300, Left = 250,Text="Отсортировать")
    let _ = button1.Click.Add((fun (e:EventArgs) -> 
        try 
            
            let a = (richTextBox2.Text).Split( [|','|])
            let c = Array.sort a
            let rec ArrayToString (arr:string []) i acc:string =
                if (i = arr.Length) then acc
                else if (arr.[i] <> " " && arr.[i] <> "")
                then ArrayToString arr (i+1) (acc + "," + arr.[i])
                else ArrayToString arr (i+1) (acc)
            let output = (ArrayToString c 0 "")
            richTextBox4.Text <- output.[1..]
        with
        | _ ->
            richTextBox4.Text <- "Ошибка ввода!"
            ))
    form.Controls.Add(text)
    form.Controls.Add(text1)
    form.Controls.Add(text3)
    form.Controls.Add(richTextBox2)
    form.Controls.Add(richTextBox4)
    form.Controls.Add(button1)
    Application.Run(form)    
    0 
