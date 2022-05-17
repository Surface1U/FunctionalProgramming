open System
open System.Drawing
open System.IO
open System.Windows.Forms
[<EntryPoint>]
let main argv =
    Application.EnableVisualStyles()
    Application.SetCompatibleTextRenderingDefault(false)


    let form = new Form(Text = "Решение уравнения" ,Width = 815, Height = 452)
    let button1 = new Button(Text = "Решить уравнение", Top = 270, Left = 285, Width = 242, Height = 71,
    BackColor = System.Drawing.Color.DarkGray,
    Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))))
    let label1 = new Label(Text = "Введите a", AutoSize = true, Location = new System.Drawing.Point(69, 61),
    Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))))
    //let label2 = new Label(Text = "Введите квадратное уравнение вида ax^2+bx+c", AutoSize = true, Location = new System.Drawing.Point(230, 26),
    //Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))))
    let label3 = new Label(Text = "Введите c", AutoSize = true, Location = new System.Drawing.Point(575, 61),
    Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))))
    let label4 = new Label(Text = "Введите b", AutoSize = true, Location = new System.Drawing.Point(328, 61),
    Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))))
    let label5 = new Label(Text = "Решение уравнения", AutoSize = true, Location = new System.Drawing.Point(313, 175),
    Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))))

    let richTextBoxA = new RichTextBox(Text = "", Width = 113, Height = 27, Location = new System.Drawing.Point(65, 90),
    Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))))

    let richTextBoxB = new RichTextBox(Text = "", Width = 113, Height = 27, Location = new System.Drawing.Point(320, 90),
    Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))))

    let richTextBoxC = new RichTextBox(Text = "", Width = 113, Height = 27, Location = new System.Drawing.Point(567, 90),
       Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))))

    let label6 = new Label(Text = "", AutoSize = true, Location = new System.Drawing.Point(340, 211),
       Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))))
    let label7 = new Label(Text = "Правила ввода", AutoSize = true, Location = new System.Drawing.Point(322, 21),
    Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))))
 
    let contextMenuStrip1 = new ContextMenuStrip()
    let toolStrip1 = new ToolStripMenuItem("Введите квадратное уравнение вида ax^2+bx+c")
    let toolStrip2 = new ToolStripMenuItem("При дискрименанте равном нулю получим один корень")
    let toolStrip3 = new ToolStripMenuItem("При дискрименанте больше нуля получим два корня" )
    let toolStrip4 = new ToolStripMenuItem("При дискрименанте меньше нуля получим два комплексных корня")
    contextMenuStrip1.Items.Add(toolStrip1)
    contextMenuStrip1.Items.Add(toolStrip2)
    contextMenuStrip1.Items.Add(toolStrip3)
    contextMenuStrip1.Items.Add(toolStrip4)
    label7.ContextMenuStrip <- contextMenuStrip1

    let _ = button1.Click.Add((fun (e:EventArgs) -> 
        try 
            let a = double(richTextBoxA.Text)
            let b = double(richTextBoxB.Text)
            let c = double(richTextBoxC.Text)   
            let d = b*b - 4.0*a*c
            let output = 
                if (d > 0.0)
                then 
                     let desisions=(Convert.ToString((-b+Math.Sqrt(d))/(2.0*a)),Convert.ToString((-b-Math.Sqrt(d))/(2.0*a)))
                     "X1 = " + fst(desisions) + " X2 = " + snd(desisions)
                else if (d = 0.0)
                then "X = " + Convert.ToString((-b)/(2.0*a))
                else 
                    let sign,supsign = if (a > 0.0) then '+','-' else '-','+'
                    let values=(Convert.ToString((-b)/(2.0*a)),Convert.ToString((d/4.0)/(a*a)))
                    "X1 = " + fst(values) + Convert.ToString(sign) + "sqrt(" + snd(values) + ") X2 = " + fst(values) + Convert.ToString(supsign) + "sqrt(" + snd(values) + ")"
            label6.Text <- output
        with
        | _ ->
            label6.Text <- "Ошибка ввода!"
            ))
    form.Controls.Add(label1)
    form.Controls.Add(label7)
    form.Controls.Add(label3)
    form.Controls.Add(label4)
    form.Controls.Add(label5)
    form.Controls.Add(richTextBoxA)
    form.Controls.Add(richTextBoxB)
    form.Controls.Add(richTextBoxC)
    form.Controls.Add(label6)
    form.Controls.Add(button1)
    Application.Run(form)    
    0 
