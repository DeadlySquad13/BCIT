// Дополнительные сведения о F# см. на http://fsharp.org
// Дополнительную справку см. в проекте "Учебник по F#".

open System

module Example =

    [<EntryPoint>]
    let main argv = 

        Console.WriteLine("{0:d}", 123);
        let str = Console.ReadLine();


        let short1 = 123s
        let short2:int16 = 123s
    
        let int1 = 333
        let int2:int = 333

        let long1 = 333L
        let long2:int64 = 333L

        let sbyte1 = -123y
        let sbyte2:sbyte = -123y

        let byte1 = 123uy
        let byte2:byte = 123uy
        //Двоичный код
        let byte3 = 0b11110000uy

        let float1 = 123.123F
        let float2:float32 = 123.123F

        let double1 = 123.123
        let double2:double = 123.123
    
        let decimal1 = 123.123m
        let decimal2:decimal = 123.123m
            
        let bool1 = true
        let bool2:bool = true

        let char1 = 'A'
        let char2:char = 'A'
            
        let string1 = "ABC"
        let string2:string = "ABC"

        //строчный комментарий    

        (*
        блочный комментарий
        *)

        ///Аналог XML-комментария перед объявлениями типов, переменных, функций

        let p1 = 1
        //ошибка, невозможно изменить значение переменной
        //p1 = p1 +1 
    
        //Объявление изменяемой переменной 
        //и присвоение ей начального значения
        let mutable p2 = 1
        //Изменение значения переменной
        p2 <- p2 + 1

        //Кортеж
        let tuple1 = (123, 123.123, "string1")
        //Кортеж с явным указанием типов данных
        let tuple2:int*double*string = (123, 123.123, "string1")

        //Кортеж кортежей
        let tuple3 = ((123, 123.123, "string1"),(124, 124.123, "string2"))
        //Кортеж кортежей с явным указанием типов данных
        let tuple4:((int*double*string)*(int*double*string)) = ((123, 123.123, "string1"),(124, 124.123, "string2"))

        //Получение значения кортежей
        let (i1, d1, str1) = tuple1
        printfn "%A" i1
        printfn "%A" d1
        printfn "%A" str1

        let first(a,_) = a
        let second(_,b) = b
    
        //Передача аргументов с помощью скобок
        let c = first((1,2))
        //Передача аргументов с помощью пробела
        let d = second (1,2)
    
        //Функция принимает 2 параметра int
        //и возвращает int
        //= отделяет объявление функции от реализации
        let sum1(a:int, b:int):int =
            //создание временной переменной
            let result = a + b
            //возвращение результата
            //результат указывается в виде выражения
            //ключевое слово return не используется
            result

        ///Вариант функции, записанный в одну строку
        let sum2(a,b) = a + b
        //Пример вызова функции
        let q = sum2(1,2)

        ///Функция возвращает число, его квадрат и куб
        let Powers(x) = 
            let x2 = x*x
            let x3 = x*x*x
            (x, x2, x3)

        ///Вариант функции Powers записанный в одну строку
        let PowersInline(x) = (x, x*x, x*x*x)

        ///Рекурсивная функция для вычисления факториала
        //данная функция может быть записана в одну строку
        let rec factorial(n:int):int = 
            if n<=1 then 1
            else n*factorial(n-1)
        //пример вызова
        let q3 = factorial(5)

        //Определение рекурсивной функции
        let rec State1(x:int) = 
            printfn "%i - (+1) %i" x (x+1)
            let x_next = x+1
            if x_next>3 then State2(x_next)
            else State1(x_next)
        //ключевое слово and объявляет функцию 
        //как взаимно-рекурсивную к предыдущей
        //это необходимо так как функция 
        //State1 ссылается на State2 и F#
        //не допускает опережающего описания
        and State2(x:int) = 
            printfn "%i - (^2) %i" x (x*x)
            let x_next = x+1
            if x_next>6 then State3(x_next)
            else State2(x_next)
        and State3(x:int) = 
            printfn "%i - (^3) %i" x (x*x*x)
            let x_next = x+1
            if x_next<=10 then State3(x_next)
        //Вызов с начальным условием
        State1(1)


        ///Рекурсивная (не хвостовая) функция для вычисления факториала
        //аккумулятор отсутствует
        let rec factorial1 n = if n<=1 then 1 else n*factorial(n-1)
        //пример вызова
        let q4 = factorial1(5)

        ///Функция для вычисления факториала на основе хвостовой рекурсии
        let rec fact_tr(n:int, acc:int):int = 
            if n=1 then acc
            else fact_tr(n-1, n*acc)
        ///Обертка для сокрытия хвостовой рекурсии
        let rec factorial2 n = fact_tr(n,1)
        //пример вызова
        let q5 = factorial2(3)

        ///Пример "ручного" каррирования
        let curry_example = 
            let step0:(int*int*int->int) = fun (a,b,c) -> a + b + c
            let step1:(int->(int*int->int)) = fun a -> fun (b,c) -> a + b + c
            let step2:(int->(int->(int->int))) = fun a -> fun b -> fun c -> a + b + c
            let res1:int = step2(1)(2)(3)
            let res2 = step2(1)


            let res2_1:int = res2(2)(3)
            let res3 = step2(1)(2)
            let res3_1:int = res3(3)
            ()

        ///пример некаррированной функции
        let uncarry1(a: int, b: int, c:int) = a + b + c
        let q6 = uncarry1(1,2,3)

        ///пример каррированной функции 1
        let carry1(a: int)(b: int)(c:int) = a + b + c
        let q71 = carry1(1)(2)(3)
        let q72 = carry1 1 2 3

        ///пример каррированной функции 2
        let carry2 a b c = a + b + c
        let q81 = carry2(1)(2)(3)
        let q82 = carry2 1 2 3 


        let carry1withFixedParams(a: int) = carry1 1 2 a
        let q9 = carry1withFixedParams(3)

        let carry1withFixedParams2 = carry1 1 2 

        let Sin1 = Math.Sin
        let Sin1Res = Sin1(0.5)


        //let uncarry1withFixedParams(a: int) = uncarry1 1 2 a

        let lambda1 = fun (a: int, b: int, c:int) -> a + b + c
        let q10 = lambda1(1,2,3)

        let lambda2 = fun (a: int)(b: int)(c:int) -> a + b + c
        let q11 = lambda2 1 2 3

        let lambda3 = fun a b c -> a + b + c
        let q13 = lambda3 1 2 3

        let context1 = 300
        let lambdaWithClosure = fun x -> context1 + x
        let lambda3res = lambdaWithClosure 33 


        let del1(a:int, b:int, func1: int*int->int) = func1(a,b) 
        let del1call = del1(1, 2, fun(a,b)->a+b) // результат - 3

        let del2(a:int, b:int, func1: int->int->int) = func1 a b  
        let del2call = del2(5, 2, fun a b -> a-b) // результат - 3

        let lst1 = new System.Collections.Generic.List<int>()
        lst1.Add(1)
        lst1.Add(2)
        lst1.Add(3)
        for x in lst1 do
            printfn "%i" x

        let dict1 = new System.Collections.Generic.Dictionary<string, int>()
        dict1.Add("str1", 1)
        dict1.Add("str2", 2)
        dict1.Add("str3", 3)
        for x in dict1 do
            printfn "%s - %i" x.Key x.Value

        //Перечисление элементов списка
        let list1 = [1;2;3]
        //Явное указание типа
        let list2:int list = [1;2;3]
        //Диапазон значений
        let list3 = [1..10]
        //Использование оператора :: (cons)
        let list4 = 1::2::3::[]
        let list4_1 = 4::[1;2;3]
        let list4_2 = [1;2;3] @ [4]
        //Использование генератора списка (list comprehension)
        let list5 = [for x in [1..5] do yield x*x]
        //Список кортежей
        let list6 = [for x in [1..5] do yield (x, x*x)]
        
        //Использование условий
        let list6_1 = [for x in [1..10] do if x % 2 = 0 then yield (x, x*x) else yield (x, 0)]


        //Конкатенация списков
        let list12 = list1 @ list2

        ///Рекурсивная обработка списка
        let rec PlusOne(lst:int list):int list = 
            //Если входной список пуст, то возвращается пустой список
            if lst.IsEmpty then []
            //иначе к первому элементу прибавляется 1
            //и функция рекурсивно вызывается для 
            //оставшейся части списка
            else (lst.Head+1)::PlusOne(lst.Tail)
        //Вызов функции
        let PlusOneRes = PlusOne([1..3])

        ///Рекурсивная обработка списка (сопоставление с образцом)
        let rec PlusOne1 = function 
            | [] -> []
            | x::xs -> x+1::PlusOne1(xs)
        //Вызов функции
        let PlusOne1Res = PlusOne1([1..3])


        //Массивы
        //Перечисление элементов
        let arr1 = [|1;2;3|]
        //Явное указание типа
        let arr2:int array = [|1;2;3|]
        //Диапазон значений
        let arr3 = [|1..10|]
        //Использование генератора массива (array comprehension)
        let arr4 = [|for x in [1..5] do yield x*x|]
        //Массив кортежей
        let arr5 = [|for x in [1..5] do yield (x, x*x)|]
        //Обращение к элементам массива по индексу осуществляется через точку
        let item0 = arr1.[0]
        //Возможно использование срезов по индексам
        let items1 = arr4.[1..]
        let items2 = arr4.[..3]
        let items3 = arr4.[1..3]
        for x in arr1 do
            printfn "%i" x


        let len1 = list1.Length

        let res1 = List.exists(fun x-> x>2)(list1)
        let res2 = List.forall(fun x-> x<5) list1
        let res3 = List.find(fun x->x % 2 = 0) list1
        let res4 = List.filter(fun x->x % 2 = 0) list3
        let res51 = List.map(fun x->(x, x*x)) list1
        let res6 = List.fold(fun acc x -> acc + x) 0 list1
        let res7 = List.append list1 list2
        let res5 = List.map(fun x->x*x) list1
        let res8 = List.zip list1 res5
        let res9 = List.rev list1
        let res10 = List.sort [1;3;5;4;2]
        let res11 = List.rev (List.sort [1;3;5;4;2])
        let res12 = List.max (List.sort [1;3;5;4;2])
        let listTrue, listFalse = List.partition (fun x -> x>= 3) [1;3;5;4;2]
    
    
        let res13 = [1;3;5;4;2] |> List.map(fun x->x+1) |> List.sort
        let res14 = List.sort <| [1;3;5;4;2]  
        let res15 = ([1;2;3] |> List.map(fun x->x+1), [1;2;3] |> List.rev) ||> List.zip

        let FuncMapSort = List.map(fun x->x+1) >> List.sort
        let res16 = FuncMapSort [1;3;5;4;2]

        let res17 = [1;3;5;4;2] |> FuncMapSort 

        let rec quickSort (lst: int list) = 
            match lst with
            //Если список пустой или состоит из 1 элемента, 
            //то возвращается список
            | [] | [_] -> lst
            //иначе список представляется в виде шаблона голова::хвост
            //x - первый элемент списка (один элемент)
            //xs - все оставшиеся элементы списка (список)
            | x::xs -> 
                //с использованием функции partition получаем два списка
                //listLessX - элементы меньшие x
                //listGreaterX - элементы большие или равные x
                let listLessX, listGreaterX = xs |> List.partition ((>=) x)
                //возвращаем список содержащий конкатенацию 3 списков
                //quickSort(listLessX) - рекурсивно сортируем элементы меньшие х
                //[x] - список, содержащий сам элемент
                //quickSort(listLessX) - рекурсивно сортируем элементы большие х
                quickSort(listLessX) @ [x] @ quickSort(listGreaterX)

        let quickSortRes = quickSort [1;3;5;4;2]

        //Обобщенные функции

        let generic1(a,b) = (a,b)
        let generic1_1 = generic1(123,123.123)
        let generic1_2 = generic1("123",123.123)

        let generic2(a:'T,b:'T) = (a,b)
        let generic2_1 = generic2(123,45)
        let generic2_2 = generic2("123","123.123")
        //Ошибка - типы параметров различаются
        //let generic2_3 = generic2("123",123.123)

        let generic3(a,b) = (a,b+100.0)
        let sum_int(a,b) = a + b
        let sum_float(a:float,b) = a + b


        let sum_generic(a,b,sum_func) = sum_func(a,b)
        let sum_int(a,b) = sum_generic(a,b,fun(a,b)->a+b)
        let sum_float(a,b) = sum_generic(a,b,fun(a,b)->a+b+0.0)
        let sum_string(a,b) = sum_generic(a,b,fun(a,b)->a+b+"")
        let sum_int_res = sum_int(1,2)
        let sum_float_res = sum_float(1.0, 2.0)
        let sum_string_res = sum_string("str1", "str2")

        //Первое определение функции sum_num
        let sum_num(a:int,b) = a + b
        //Второе определение не приводит к ошибке, 
        //но перекрывает первое
        let sum_num(a:float,b) = a + b
        //Нет ошибки - параметры типа float
        let sum_num1 = sum_num(1.0,2.0)
        //Ошибка - параметры типа int
        //let sum_num2 = sum_num(1,2)

        printfn "%i - %f - %s" 333 123.123 "string1"


        printfn "%A" argv
        let str2 = Console.ReadLine()

        0 // возвращение целочисленного кода выхода
