using System;
using System.Collections.Generic;
using System.Collections;

using GeometricFigures;
using CustomCollections;

namespace Lab_3
{
  /*  class FigureMatrixCheckEmpty : IMatrixCheckEmpty<GeometryFigure>
    {
      /// <summary> 
      /// В качестве пустого элемента возвращается null 
      /// </summary> 
      public GeometryFigure getEmptyElement()
      {
        return null;
      }

      /// <summary> 
      /// Проверка что переданный параметр равен null 
      /// </summary> 
      public bool checkEmptyElement(GeometryFigure element)
      {
        bool Result = false;
        if (element == null)
        {
          Result = true;
        }
        return Result;
      }
    }*/

  class Program
  {
    static void Main()
    {
      Console.SetWindowSize(120, 38); // Изменяем размер консоли для правлиьного отображения разреженной матрицы.
      Console.WriteLine(Console.WindowWidth);
      Console.WriteLine(Console.WindowHeight);
      Rectangle R1 = new Rectangle(10, 2);
      Circle C1 = new Circle(1);
      Square S1 = new Square(2);
      Rectangle R2 = new Rectangle(15, 2);
      Circle C2 = new Circle(2);
      Square S2 = new Square(4);

      ArrayList figuresArrList = new ArrayList { R1, C1, S1, R2, C2, S2 };
      Console.WriteLine("ArrayList of Figures before sorting.");
      foreach (GeometricFigure Figure in figuresArrList)
      {
        Figure.Print();
      }

      figuresArrList.Sort();
      Console.WriteLine("\nArrayList of Figures after sorting.");
      foreach (GeometricFigure Figure in figuresArrList)
      {
        Figure.Print();
      }

      List < GeometricFigure > figuresList = new List < GeometricFigure > { R1, C1, S1, R2, C2, S2 };
      Console.WriteLine("\n\nList of Figures before sorting.");
      foreach (GeometricFigure Figure in figuresList)
      {
        Figure.Print();
      }

      figuresList.Sort();
      Console.WriteLine("\nList of Figures after sorting.");
      foreach (GeometricFigure Figure in figuresList)
      {
        Figure.Print();
      }

      Console.WriteLine("\n\nSparse Matrix of Figures.");
      SparseMatrix < GeometricFigure > figuresSpMatr = new SparseMatrix < GeometricFigure > (
        3, 3, 3, new GeometricFigureMatrixCheckEmpty()
      );
      figuresSpMatr[0, 0, 0] = R1;
      figuresSpMatr[0, 0, 1] = C1;
      figuresSpMatr[0, 1, 0] = S1;
      figuresSpMatr[0, 1, 1] = R1;
      figuresSpMatr[1, 0, 0] = C1;
      figuresSpMatr[1, 0, 1] = S1;
      Console.WriteLine(figuresSpMatr.ToString());

      Console.WriteLine("\nSimple Stack of Figures before sorting.");
      SimpleStack<GeometricFigure> figuresSmplStack = new SimpleStack<GeometricFigure>(
        R1, C1, S1, R2, C2, S2
      );
      foreach (GeometricFigure Figure in figuresSmplStack)
      {
        Console.WriteLine(Figure);
      }

      Console.WriteLine("\nSimple Stack of Figures after sorting.");
      figuresSmplStack.Sort();
      foreach (GeometricFigure Figure in figuresSmplStack)
      {
        Console.WriteLine(Figure);
      }
    }
  }
}
