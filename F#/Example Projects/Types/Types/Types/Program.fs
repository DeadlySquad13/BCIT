// Дополнительные сведения о F# см. на http://fsharp.org
// Дополнительную справку см. в проекте "Учебник по F#".

open System

//на уровне модуля
exception Exception1 of int * int

type Person = { 
    Name : string
    DateOfBirth : DateTime }
and Persons = 
    | Head of Person
    | Department of Person list

type Class1(ap: int, bp: string) =
    //свойство (property) поле данных
    let mutable PropertyValue = 0
    //приватные поле и метод
    let private_int = 123
    let private_func() = private_int * 2
    //поля инициализируются параметрами конструктора
    member this.a: int = ap
    member this.b: string = bp
    //методы
    member this.Print() = printfn "%i %s" this.a this.b
    member this.Multiply(mult : int) = printfn "%i" (this.a * mult)
    //статический метод
    static member Static1() = printfn "Static1"
    //метод использующий приватные поля
    member this.Print2() = 
        let temp = private_func()
        printfn "%i" temp
    //свойство (property)
    member this.ReadWriteProperty
        with get () = PropertyValue
        and set (value) = PropertyValue <- value
    //альтернативные конструкторы
    new() = Class1(2, "str2")
    new(i:int) = Class1(i, "str3")
    //виртуальный метод
    abstract VirtPrint: unit -> unit
    default this.VirtPrint() = printfn "%i %s" this.a this.b

    type Class11() = class
        member this.a: int = 0
        member this.b: string = ""
        end


    type Class2(ap: int, bp: string, cp: float) =
        //наследование от класса 1
        inherit Class1(ap, bp)
        member this.c: float = cp
        //перегрузка виртуального метода
        override this.VirtPrint() = printfn "%i %s %f" this.a this.b this.c
        //перегрузка метода ToString для класса Object
        override this.ToString() = "!!!"

    [<AbstractClass>]
    type Abstract1() =
       //абстрактный метод
       abstract member Add: int -> int -> int
       //абстрактное неизменяемое свойство
       abstract member Pi : float
       //default this.Pi = 3.14 
       //абстрактное изменяемое свойство
       abstract member Prop1 : float with get,set

    type Concrete1() = 
        inherit Abstract1()
        let mutable Prop1Value = 0.0
        override this.Add a b = a+b
        override this.Pi = 3.14
        override this.Prop1
            with get () = Prop1Value
            and set (value) = Prop1Value <- value

    type Interface1 = interface
       //абстрактный метод
       abstract member Add: int -> int -> int
       //абстрактное неизменяемое свойство
       abstract member Pi : float
       end

    type Interface2 = interface
       inherit Interface1
       //абстрактное изменяемое свойство
       abstract member Prop1 : float with get,set
       end

    type Interface2Implement1() = 
        //изменяемая переменная для свойства Prop1
        let mutable Prop1Value = 0.0
        //реализация интерфейса
        interface Interface2 with
            member this.Add a b = a+b
            member this.Pi = 3.14
            member this.Prop1
                with get () = Prop1Value
                and set (value) = Prop1Value <- value


    //Активные шаблоны
    type Complex(r : float, i : float) =
        static member Polar(mag, phase) = Complex(mag * cos phase, mag * sin phase)
        member x.Magnitude = sqrt(r * r + i * i)
        member x.Phase = atan2 i r
        member x.RealPart = r
        member x.ImaginaryPart = i


[<EntryPoint>]
let main argv = 

    //объявление записи
    let person1 = { Name = "Иван"; DateOfBirth = DateTime(1980, 09, 02) }
    //объявление записи на основе существующей
    let person2 = { person1 with Name = "Петр" }

    let head1 = Head({ Name = "Сергей"; DateOfBirth = DateTime(1980, 09, 02) })

    let class11 = Class11()

    let cl1 = Class1(1, "str")
    cl1.Print()
    cl1.VirtPrint()
    cl1.Print2()
    cl1.Multiply(333)
    Class1.Static1()
    cl1.ReadWriteProperty <- 333
    let ReadWritePropertyVal = cl1.ReadWriteProperty
    let cl11 = Class1()
    let cl12 = Class1(1)

    printfn "%A" person1
    printfn "%A" person2

    let cl2 = Class2(1, "str1", 3.14)
    cl2.VirtPrint()
    let cl2str = cl2.ToString()

    let concr1 = Concrete1()
    let sum = concr1.Add 1 2

    let ii2 = Interface2Implement1()
    let ii2Int = ii2 :> Interface2
    let sum = ii2Int.Add 1 2

    //Реализация интерфейса с использованием Object Expressions
    let Interface1Implement = 
        { new Interface1 with
            member this.Add a b = a+b
            member this.Pi = 3.14 }

    let sum1 = Interface1Implement.Add 1 2 

    //Активные шаблоны
    let (|Rect|) (x : Complex) = (x.RealPart, x.ImaginaryPart)
    let (|Polar|) (x : Complex) = (x.Magnitude, x.Phase)

    let mulViaRect a b =
        match a, b with
        | Rect (ar, ai), Rect (br, bi) -> Complex (ar * br - ai * bi, ai * br + bi * ar)

    let mulViaPolar a b =
        match a, b with
        | Polar (m, p), Polar (n, q) -> Complex.Polar (m * n, p + q)


    //Цикл For
    for i=1 to 5 do
        printfn "%A" i

    for i=5 downto 1 do
        printfn "%A" i

    for i in [1..5] do
        printfn "%A" i

    let list1 = [1..5]
    for i in list1 do
        printfn "%A" i

    //Цикл While
    let mutable iw = 1
    while iw <= 5 do
        printfn "%A" iw
        iw <- iw + 1

    //Оператор if
    let x = 0
    if x=0 then printfn "zero"
    elif x>0 then printfn "pos"
    else printfn "neg"
    
    let x_res = if x=0 then "zero" elif x>0 then "pos" else "neg"
    printfn "%A" x_res

    //проверка условий
    if (x<0) && not(x<10) || (x>10) then printfn "result1"
    else printfn "result2"

    //Оператор match
    
    //Реализация с помощью if
    let c1 = 
        if x=0 then "zero"
        else "nonzero"

    //Не совсем корректная реализация с помощью match
    let c2 = 
        match x=0 with
        | true -> "zero"
        | false -> "nonzero"

    //Корректная реализация с помощью match
    let c3 = 
        match x with
        | 0 -> "zero"
        | _ -> "nonzero"

    let c4 = 
        match x with
        | 1 -> "1"
        | 2 -> "2"
        | _ -> "unknown"

    let y1 = 1
    let y2 = 2
    let c5 = 
        match y1 with
        | 1 when y2>0 -> "result1"
        | 1 when y2<=0 -> "result2"
        | _ -> "result3"

    let y3 = 1
    let c6 = 
        match y3 with
        | _ when y3>0 -> "result1"
        | _ when y3<=0 -> "result2"
        | _ -> "result3"

    //Проверка типа
    let checkType (x : obj) =
        match x with
        | :? string -> "строка"
        | :? int -> "целое число"
        | _ -> "другой тип"

    printfn "%A" (checkType(1))
    printfn "%A" (checkType("1"))
    printfn "%A" (checkType(1.0))


    //Исключения
    try
        try
            let a = 3 / 0 
            printfn "%d" a
        with
            | :? DivideByZeroException -> printfn "divided by zero"
    finally
        printfn "finally"

    try
        failwithf "дата-время %A" DateTime.Now
    with _ as e -> printfn "Информация об исключении: %s" e.Message

    //в функции
    try
        raise (Exception1(1, 2))
    with _ as e -> printfn "%A" e



    let quit = Console.ReadLine()
    printfn "%A" argv
    0 // возвращение целочисленного кода выхода


