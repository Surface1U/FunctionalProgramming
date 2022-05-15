open System.Text.RegularExpressions

type VehiclePassport(name:string, model:string, category:string, yearOfManufacture:int, enginePower:double) = 

        member this.Name
            with get() = name
            and set(value:string) =
                if Regex.IsMatch (value, @"[a-z]")
                then this.Name <- value
                else System.Console.WriteLine("Invalid input")

        member this.Model
            with get() = model
            and set(value:string) = 
                if Regex.IsMatch (value, @"[a-z]")
                then  this.Model <- value
                else System.Console.WriteLine("Invalid input") 

        member this.Category
            with get() = category
            and set(value:string) = 
                if Regex.IsMatch (System.Convert.ToString(value), @"[a-z]")
                then this.Category <- value
                else System.Console.WriteLine("Invalid input") 

        member this.YearOfManufacture
            with get() = yearOfManufacture
            and set(value:int) =
                if Regex.IsMatch (System.Convert.ToString(value), @"[0-9]")
                then this.YearOfManufacture <- value
                else System.Console.WriteLine("Invalid input") 

        member this.EnginePower
            with get() = enginePower
            and set(value:float) = 
                if Regex.IsMatch (System.Convert.ToString(value), @"[0-9]+.[0-9]+")
                then this.EnginePower <- value
                else System.Console.WriteLine("Invalid input")
