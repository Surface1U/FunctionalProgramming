open System
(*Абстрактный класс «Геометрическая фигура» содержит виртуальный метод для вычисления площади фигуры.
Разработайте для данного класса функцию вычисления площади.
Функция должна принимать параметр типа «геометрическая фигура»
и вычислять различные варианты площади в зависимости от
дискриминатора. Необходимо использовать механизм сопоставления
с образцом. (Используйте пример вычисления корней квадратного
уравнения*)


[<AbstractClass>]
type GeometryFigure()=
    abstract member Square:unit->double 
    abstract member Pi:double
    default this.Pi = 3.14

type IPrint = interface
    abstract member Print:unit->unit
    end

type Rectangle(h:double, w:double) =  //прямоугольник
    inherit GeometryFigure()
    let mutable heigth = h
    let mutable width = w
    member this.Heigth
        with get() = heigth
        and set(value) = heigth <- value
    member this.Width
        with get() = width
        and set(value) = width <- value
    override this.Square() = (width*heigth)  //перегрузка метода
    override this.ToString() = "Прямоугольник со сторонами " + Convert.ToString(heigth) + " и " + Convert.ToString(width) + " с площадью равной " + Convert.ToString(this.Square())
    interface IPrint with                    //вывод
        member this.Print() = Console.WriteLine(this.ToString())
        end

type Box(a:double, b:double) =
    inherit Rectangle(a,a)
    let mutable side = a
    new(a:double) = Box(a,a)
    override this.ToString() = "Квадрат со стороной " + Convert.ToString(a) + " с площадью равной " + Convert.ToString(this.Square())
    interface IPrint with
        member this.Print() = Console.WriteLine(this.ToString())
        end
                            
type Round(r:double) =
    inherit GeometryFigure()
    let mutable radius = r
    member this.Radius
        with get() = radius
        and set(value) = radius <- value
    override this.Square() = this.Pi*radius*radius
    override this.ToString() = "Круг с радиусом " + Convert.ToString(radius) + " с площадью равной " + Convert.ToString(this.Square())
    interface IPrint with
        member this.Print() = Console.WriteLine(this.ToString())
        end

type Figuries =
 | Rectangle of double * double
 | Box of double
 | Round of double
 
let GetSquare (a: Figuries) =
    match a with
    Rectangle(a,b) -> a*b
    | Box(a) -> a*a
    | Round(r) -> r*r*Math.PI

        

[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите сторону квадрата")
    let k=System.Convert.ToDouble(System.Console.ReadLine())
    let rect = new Box(k)
    Console.WriteLine("Площадь равна:")
    Console.WriteLine(rect.Square())
    Console.WriteLine("Введите стороны прямоугольника")
    let a=System.Convert.ToDouble(System.Console.ReadLine())
    let b=System.Convert.ToDouble(System.Console.ReadLine())
    let rect2 = Rectangle(a,b)
    Console.WriteLine("Площадь равна:")
    Console.WriteLine(GetSquare(rect2))
    Console.WriteLine("Введите радиус круга")
    let r=System.Convert.ToDouble(System.Console.ReadLine())
    let rect3 =  new Round(r)
    Console.WriteLine(rect3.ToString())
    0
