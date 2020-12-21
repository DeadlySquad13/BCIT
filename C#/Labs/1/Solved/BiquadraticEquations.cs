using System;
using System.Collections.Generic;

using System.Reflection;

using Lab_1;
using Lab_1.Roots;
using Lab_1.EquationSolvers;

namespace Equations
{
  class Lab_1
  {
    static public int InitCoef(string defaultArg, string coefName)
    {
      try
      {
        return Convert.ToInt32(defaultArg);
      }
      catch (System.IndexOutOfRangeException) // В параметрах консоли нет такого элемента.
      {
        return InputCoef(coefName);
      }
      catch (System.FormatException) // Элемент был неправильно введён в параметрах консоли.
      {
        return InputCoef(coefName);
      }
    }
    static public int InputCoef(string coefName)
    {
      try
      {
        Console.Write($"Введите {coefName}: ");
        return Convert.ToInt32(Console.ReadLine()); // Если исключений нет, выходим из рекурсивного цикла.
      }
      catch (System.FormatException e)
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(e.Message);

        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("Введите коэффициент ещё раз.");
        Console.ResetColor();

        return InputCoef(coefName); // Рекурсивно вызываем функцию, пока пользователь не введёт правильно коэффициент.
      }
    }
    static public void Main(string[] args)
    {
      Console.WriteLine("Автор программы:\nПакало Александр Сергеевич РТ5-31Б");

      int a, b, c; // Коэффициенты уравнения.

      Console.WriteLine("Введите коэффициенты уравнений вида ax^2 + bx + c, ax^4 + bx^2 + c.");

      a = InitCoef(args[0], "a");   
      b = InitCoef(args[1], "b");
      c = InitCoef(args[2], "c");

      Console.WriteLine("Корни квадратного уравнения:");
      QuadraticEquationSolver quadEq = new QuadraticEquationSolver();
      RootsResult quadRoots = quadEq.CalculateRoots(a, b, c);
      quadEq.OutputRoots(quadRoots);

      Console.WriteLine("Корни биквадратного уравнения:");
      BiquadraticEquationSolver biquadEq = new BiquadraticEquationSolver();
      RootsResult biquadRoots = biquadEq.CalculateRoots(a, b, c);
      biquadEq.OutputRoots(biquadRoots);
    }
  }
}
