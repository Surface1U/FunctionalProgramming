open System
open System.Drawing
open System.IO
open System.Windows.Forms
[<EntryPoint>]
let main argv =
    Application.EnableVisualStyles()
    Application.SetCompatibleTextRenderingDefault(false)


    let form = new Form(Text = "Решение уравнения" ,Width = 815, Height = 452)
    let button1 = new Button(Text = "Решить уравнение", Top = 300, Left = 336, Width = 242, Height = 71,
    BackColor = System.Drawing.Color.DarkGray,
    Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))))
    let label1 = new Label(Text = "Введите a", AutoSize = true, Location = new System.Drawing.Point(69, 61),
    Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))))
    let label2 = new Label(Text = "Введите квадратное уравнение вида ax^2+bx+c", AutoSize = true, Location = new System.Drawing.Point(230, 26),
    Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))))
    let label3 = new Label(Text = "Введите c", AutoSize = true, Location = new System.Drawing.Point(575, 61),
    Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))))
    let label4 = new Label(Text = "Введите b", AutoSize = true, Location = new System.Drawing.Point(328, 61),
    Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))))
    let label5 = new Label(Text = "Решение уравнения", AutoSize = true, Location = new System.Drawing.Point(338, 175),
    Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))))

    let richTextBoxA = new RichTextBox(Text = "", Width = 113, Height = 27, Location = new System.Drawing.Point(65, 90),
    Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))))

    let richTextBoxB = new RichTextBox(Text = "", Width = 113, Height = 27, Location = new System.Drawing.Point(320, 90),
    Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))))

    let richTextBoxC = new RichTextBox(Text = "", Width = 113, Height = 27, Location = new System.Drawing.Point(567, 90),
       Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))))

    let richTextBox1 = new RichTextBox(Text = "", Width = 200, Height = 50, Location = new System.Drawing.Point(342, 211),
       Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))))

    
    let _ = button1.Click.Add((fun (e:EventArgs) -> 
        try 
            let a = double(richTextBoxA.Text)
            let b = double(richTextBoxB.Text)
            let c = double(richTextBoxC.Text)   
            let d = b*b - 4.0*a*c
            let output = 
                if (d > 0.0)
                then "X1 = " + Convert.ToString((-b+Math.Sqrt(d))/(2.0*a)) + " X2 = " + Convert.ToString((-b-Math.Sqrt(d))/(2.0*a))
                elif (d = 0.0)
                then "X = " + Convert.ToString((-b)/(2.0*a))
                else 
                    let sign,supsign = if (a > 0.0) then '+','-' else '-','+'
                    "X1 = " + Convert.ToString((-b)/(2.0*a)) + Convert.ToString(sign) + "sqrt(" + Convert.ToString((d/4.0)/(a*a)) + ") X2 = " + Convert.ToString((-b)/(2.0*a)) + Convert.ToString(supsign) + "sqrt(" + Convert.ToString((d/4.0)/(a*a)) + ")"
            richTextBox1.Text <- output
        with
        | _ ->
            richTextBox1.Text <- "Ошибка ввода!"
            ))
    form.Controls.Add(label1)
    form.Controls.Add(label2)
    form.Controls.Add(label3)
    form.Controls.Add(label4)
    form.Controls.Add(label5)
    form.Controls.Add(richTextBoxA)
    form.Controls.Add(richTextBoxB)
    form.Controls.Add(richTextBoxC)
    form.Controls.Add(richTextBox1)
    form.Controls.Add(button1)
    Application.Run(form)    
    0 
    
             
