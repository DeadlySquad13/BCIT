using System;

namespace GeometricFigures
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Лабораторная работа выполнена Пакало Александром Сергеевичем, студентом РТ5-31Б.");
      // Figure parameters.
      double width,
             length,
             squareWidth,
             radius;

      Console.WriteLine("\tRectangle: ");
      while (true)
      {
        Console.Write("Enter the width: ");
        width = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter the length: ");
        length = Convert.ToDouble(Console.ReadLine());

        try
        {
          Rectangle R = new Rectangle(width, length);
          R.Print();
          break;
        }
        catch (ArgumentException e)
        {
          Console.WriteLine(e.Message);
          Console.WriteLine("Please, enter all parameters once again: ");
        }
      }


      Console.WriteLine("\tSquare: ");
      while (true)
      {
        Console.Write("Enter the width: ");
        squareWidth = Convert.ToDouble(Console.ReadLine());
        try
        {
          Rectangle S = new Square(squareWidth);
          S.Print();
          break;
        }
        catch (ArgumentException e)
        {
          Console.WriteLine(e.Message);
          Console.WriteLine("Please, enter all parameters once again: ");
        }
      }


      Console.WriteLine("\tCircle: ");
      while (true)
      {
        Console.Write("Enter the radius: ");
        radius = Convert.ToDouble(Console.ReadLine());
        try
        {
          Circle C = new Circle(radius);
          C.Print();
          break;
        }
        catch (ArgumentException e)
        {
          Console.WriteLine(e.Message);
          Console.WriteLine("Please, enter all parameters once again: ");
        }
      }
    }
  }
}
