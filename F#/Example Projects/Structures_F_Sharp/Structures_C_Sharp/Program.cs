using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures_C_Sharp
{
    class Program
    {
        static void loop1()
        {
            for(int i=1;i<=10;i++)
            {
                if(i<=3)
                {
                    Console.WriteLine("{0:d} - (+1) {1:d}", i, i+1);
                }
                else if(i<=6)
                {
                    Console.WriteLine("{0:d} - (^2) {1:d}", i, i * i);
                }
                else 
                {
                    Console.WriteLine("{0:d} - (^3) {1:d}", i, i * i * i);
                }
            }
        }

        static void State1(int x)
        {
            Console.WriteLine("{0:d} - (+1) {1:d}", x, x + 1);
            int x_next = x + 1;
            if (x_next > 3) State2(x_next);
            else State1(x_next);
        }
        static void State2(int x)
        {
            Console.WriteLine("{0:d} - (^2) {1:d}", x, x * x);
            int x_next = x + 1;
            if (x_next > 6) State3(x_next);
            else State2(x_next);
        }
        static void State3(int x)
        {
            Console.WriteLine("{0:d} - (^3) {1:d}", x, x * x * x);
            int x_next = x + 1;
            if (x_next <= 10) State3(x_next);
        }

        static void Main(string[] args)
        {
            short short1 = 123;
            int int1 = 333;
            long long1 = 333;
            byte byte1 = 123;
            sbyte sbyte1 = -123;

            float float1 = 123.123F;
            double double1 = 123.123;
            decimal decimal1 = 123.123m;

            bool bool1 = true;

            char char1 = 'A';
            string string1 = "ABC";

            loop1();

            Console.WriteLine("Вызов автоматных функций с начальным условием");
            State1(1);

            //Пример каррирования
            //Исходная функция принимает 3 аргумента и возвращает их сумму
            Func<int, int, int, int> step0 = (a, b, c) => a + b + c;
            //Первый шаг каррирования
            //функция принимает один аргумент и возвращает функцию
            //которая принимает остальные аргументы и возвращает результат
            //функцию (b, c) => a + b + c
            Func<int, Func<int, int, int>> step1 = a => (b, c) => a + b + c;
            //ОТМЕТИМ что функция (b, c) => a + b + c является выходным результатом step1
            //Второй шаг каррирования
            Func<int, Func<int, Func<int, int>>> step2 = a => b => c => a + b + c;
            //Таким образом исходная функция (a, b, c) => a + b + c;
            //в которой параметры передаются через кортеж преобразована в набор вложенных функций
            //a => b => c => a + b + c или a => (b => (c => a + b + c))

            //При вызове полный набор аргументов можно передавать в виде набора скобочек 
            int res1 = step2(1)(2)(3);
            
            //и можно применять параметры частично
            var res2 = step2(1);
            int res2_1 = res2(2)(3);

            var res3 = step2(1)(2);
            int res3_1 = res3(3);

            //Эффекта частичного применения нельзя добиться
            //используя некаррированные параметры
            Func<int, int, int> uncarry1 = (b, c) => step0(1, b, c);
            int uncarry1_res1 = uncarry1(2,3);
            //var uncarry1_res2 = uncarry1(2); - ОШИБКА

            Console.ReadLine();
        }
    }
}
