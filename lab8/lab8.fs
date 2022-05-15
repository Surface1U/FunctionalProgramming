open System.Text.RegularExpressions
open System.Diagnostics

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

        override this.ToString() =            
            sprintf "ID = %i\nName = %s\nModel = %s\nCategory = %s\nYearOfManufacture = %i\nEnginePower = %f\n"
                this.ID this.Name this.Model this.Category this.YearOfManufacture this.EnginePower
                                      
        interface IPrint with
            member this.Print() =
                this.ToString()
                |> printfn "%s\n"
        member this.Print() = (this :> IPrint).Print()

        interface System.IComparable<VehiclePassport> with
            member this.CompareTo other =
                compare this.ID other.ID
                
        interface System.IComparable with
            member this.CompareTo object = 
                match object with
                |null -> 1
                |   :? VehiclePassport as other -> (this :> System.IComparable<_>).CompareTo other
                |_ -> invalidArg "object" "not a VehiclePassport"

        interface System.IEquatable<VehiclePassport> with
            member this.Equals other =
                (this.ID = other.ID && this.YearOfManufacture = other.YearOfManufacture)

        override this.Equals object = 
            match object with
            | :? VehiclePassport as other -> (this :> System.IEquatable<_>).Equals other
            |_ -> false
        override this.GetHashCode () = hash this.ID
