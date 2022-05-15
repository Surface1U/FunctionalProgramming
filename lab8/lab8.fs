abstract member Print: unit -> unit
    end


type VehiclePassport(i:int, name:string, model:string, category:string, yearOfManufacture:int, enginePower:double) = 

        member this.ID
@@ -59,7 +60,33 @@ type VehiclePassport(i:int, name:string, model:string, category:string, yearOfMa
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

let ForDemo =
    let rand = System.Random()
    let vehicles = List.init(10) (fun v -> VehiclePassport((rand.Next(100, 1000)), "unnamed", "unknown", "undefined", (rand.Next(2000, 2022)), 0.0001))
    vehicles |> List.iter (fun v -> v.Print())  
    //vehicles |> List.iter (fun v -> v.Print())  
    //Equation by ID and YearOfManufacture
    //Comparison by ID
    printfn "%A" ((new VehiclePassport(1, "", "", "", 10, 0.0)).Equals(new VehiclePassport(2, "", "", "", 10, 0.4))) // false
    printfn "%A" ((new VehiclePassport(1, "", "", "", 10, 0.0)).Equals(new VehiclePassport(1, "", "", "", 10, 0.4))) // true
    printfn "%A" (compare (new VehiclePassport(10, "", "", "", 20, 0.0)) (new VehiclePassport(4, "", "", "", 40, 0.4)))// 1
