open System
open System.Drawing
open System.IO
open System.Windows.Forms
[<EntryPoint>]
let main argv =
    Application.EnableVisualStyles()
    Application.SetCompatibleTextRenderingDefault(false)


    let form = new Form(Text = "Работа с массивами" ,Width = 815, Height = 452)
    let button1 = new Button(Text = "Получить массив", Top = 290, Left = 300, Width = 242, Height = 71,
    BackColor = System.Drawing.Color.DarkGray,
    Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))))
    let text = new Label(Font = new Font(familyName = "Segoe UI",emSize = 15.0f),Width = 700, Top = 5, Height = 50, Left = 10,Text="Добавление последнего элемента из массива B в массив A")
    let text1 = new Label(Font = new Font(familyName = "Segoe UI",emSize = 15.0f),Width = 200, Top = 50, Height = 70, Left = 0,Text="Массив А")
    let text2 = new Label(Font = new Font(familyName = "Segoe UI",emSize = 15.0f),Width = 200, Top = 120, Height = 70, Left = 0, Text="Массив Б")
    let text3 = new Label(Font = new Font(familyName = "Segoe UI",emSize = 15.0f),Width = 200, Top = 190, Height = 70, Left = 0, Text="Результирующий массив")
    let richTextBox2 = new RichTextBox(Font = new Font(familyName = "Segoe UI",emSize = 22.0f),Width = 500, Top = 50, Height = 70, Left = 200,Text="1,2,3")
    let richTextBox3 = new RichTextBox(Font = new Font(familyName = "Segoe UI",emSize = 22.0f),Width = 500, Top = 120,Height = 70, Left = 200,Text="4,5,7")
    let richTextBox4 = new RichTextBox(Font = new Font(familyName = "Segoe UI",emSize = 22.0f),Width = 500, Top = 190,Height = 70, Left = 200,Text="")
    
    let _ = button1.Click.Add((fun (e:EventArgs) -> 
        try 
            let a = (richTextBox2.Text).Split( [|','|])
            let b = (richTextBox3.Text).Split( [|','|])
            let c = Array.append b ([|a.[a.Length-1]|])
            let rec ArrayToString (arr:string []) i acc:string =
                if (i = arr.Length) then acc
                else ArrayToString arr (i+1) (acc + "," + arr.[i])
            let output = (ArrayToString c 0 "")
            richTextBox4.Text <- output.[1..]
        with
        | _ ->
            richTextBox4.Text <- "Ошибка ввода!"
            ))
    form.Controls.Add(text)
    form.Controls.Add(text1)
    form.Controls.Add(text2)
    form.Controls.Add(text3)
    form.Controls.Add(richTextBox2)
    form.Controls.Add(richTextBox3)
    form.Controls.Add(richTextBox4)
    form.Controls.Add(button1)
    Application.Run(form)    
    0 
