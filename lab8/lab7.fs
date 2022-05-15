let brokenPrinterAgent = MailboxProcessor.Start(fun inbox ->
    let rec messageLoop() = async{
        let! (msg:string) = inbox.Receive()
        let response = match msg with
        |"Hi" -> "Hahahahai!"
        |"How are you now?"->"Stupid question"
        |"So,okay, what about ur health?" -> "Yo, man, im died ten years ago!"
        |"I saying with dead man?" -> "No, you too died"
        |"But when?" -> "Get lost!"
        |_->"Good day!"
        printfn "%s" response
        return! messageLoop()
        }
    messageLoop()
    )

let Solo = brokenPrinterAgent

let rec say () =
    let message = System.Console.ReadLine()
    if not (System.String.IsNullOrEmpty message) then 
        Solo.Post(message)
        say()
    

let ForDemo = 
    printfn "Say <HI>"
    say()
    0
