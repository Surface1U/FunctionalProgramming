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


[<AbstractClass>]
type Document() =    
    abstract member SearchDoc: VehiclePassport -> bool

type ListDocument(list: List<VehiclePassport> ) =
    inherit Document()
    member this.list: List<VehiclePassport> = list
    override this.SearchDoc(doc: VehiclePassport) =
        this.list |> List.exists (fun d -> d = doc)
    
type ArrayDocument(arr: array<VehiclePassport> ) =
    inherit Document()
    member this.arr: array<VehiclePassport> = arr
    override this.SearchDoc(doc: VehiclePassport) =
         this.arr |> Array.exists (fun d -> d = doc)

type SetDocument(set: Set<VehiclePassport> ) =
    inherit Document()
    member this.set: Set<VehiclePassport> = set
    override this.SearchDoc(doc: VehiclePassport) =
         this.set |> Set.exists (fun d -> d = doc)


type BinaryDocument(list: List<VehiclePassport> ) =
    inherit Document()
    member this.list = list |> List.sortBy (fun (d:VehiclePassport) -> d.ID)
    override this.SearchDoc(doc) =    
        let rec binaryLoop (l: List<VehiclePassport>) (item:VehiclePassport) = 
            match (List.length l) with
                 |0 -> false
                 |i ->
                    let middle = i / 2
                    match sign <| compare item l.[middle] with
                    |0 -> true
                    |1 -> binaryLoop l.[.. middle - 1] item
                    |_ -> binaryLoop l.[middle + 1..] item
        binaryLoop this.list doc     
                          
  let measureTime (timer: Stopwatch) method doc =
    timer.Reset()
    timer.Start()
    let isFound = method doc
    timer.Stop()
    timer.ElapsedMilliseconds
  
let ForDemo =
    let rand = System.Random()
    let vehicles = List.init(100000) (fun v -> VehiclePassport((rand.Next(100, 100000)), "unnamed", "unknown", "undefined", (rand.Next(2000, 20000)), 0.0001))
    //vehicles |> List.iter (fun v -> v.Print())  
    //Equation by ID and YearOfManufacture
    //Comparison by ID
    //printfn "%A" ((new VehiclePassport(1, "", "", "", 10, 0.0)).Equals(new VehiclePassport(2, "", "", "", 10, 0.4))) // false
    //printfn "%A" ((new VehiclePassport(1, "", "", "", 10, 0.0)).Equals(new VehiclePassport(1, "", "", "", 10, 0.4))) // true
    //printfn "%A" (compare (new VehiclePassport(10, "", "", "", 20, 0.0)) (new VehiclePassport(4, "", "", "", 40, 0.4)))// 1

    let listDoc = ListDocument(vehicles)
    let arrayDoc = ArrayDocument(List.toArray vehicles)
    let binaryDoc = BinaryDocument(vehicles)
    let setDoc = SetDocument(Set.ofList vehicles)

    let timer = new Stopwatch()

    let vehicle = VehiclePassport(500, "unnamed", "unknown", "undefined", 10322, 0.0001)

    printfn "List search time %d ms" (measureTime timer listDoc.SearchDoc vehicle)
    printfn "Array search time %d ms" (measureTime timer arrayDoc.SearchDoc vehicle)
    printfn "Binary search time %d ms" (measureTime timer binaryDoc.SearchDoc vehicle)
    printfn "Set search time %d ms" (measureTime timer setDoc.SearchDoc vehicle)
    timer.Reset()
    0
    
