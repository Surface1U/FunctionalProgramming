open System.Text.RegularExpressions

type VehiclePassport(name:string, model:string, category:string, yearOfManufacture:int, enginePower:double) = 
type IPrint = interface
    abstract member Print: unit -> unit
    end

type VehiclePassport(i:int, name:string, model:string, category:string, yearOfManufacture:int, enginePower:double) = 

        member this.ID
            with get() = i
            and set(value:int) = 
                if Regex.IsMatch (System.Convert.ToString(value), @"[0-9]")
                then this.ID <- value
                else System.Console.WriteLine("Invalid input") 

        member this.Name
            with get() = name
            and set(value:string) =
@@ -37,3 +48,18 @@ type VehiclePassport(name:string, model:string, category:string, yearOfManufactu
                if Regex.IsMatch (System.Convert.ToString(value), @"[0-9]+.[0-9]+")
                then this.EnginePower <- value
                else System.Console.WriteLine("Invalid input")

        override this.ToString() =            
            sprintf "ID = %i\nName = %s\nModel = %s\nCategory = %s\nYearOfManufacture = %i\nEnginePower = %f\n"
                this.ID this.Name this.Model this.Category this.YearOfManufacture this.EnginePower

        interface IPrint with
            member this.Print() =
                this.ToString()
                |> printfn "%s\n"
        member this.Print() = (this :> IPrint).Print()

let ForDemo =
    let rand = System.Random()
    let vehicles = List.init(10) (fun v -> VehiclePassport((rand.Next(100, 1000)), "unnamed", "unknown", "undefined", (rand.Next(2000, 2022)), 0.0001))
    vehicles |> List.iter (fun v -> v.Print())  
