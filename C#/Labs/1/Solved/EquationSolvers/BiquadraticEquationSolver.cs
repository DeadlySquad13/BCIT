using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;

using Lab_1.Roots;

namespace Lab_1.EquationSolvers
{
  class BiquadraticEquationSolver : QuadraticEquationSolver
  {
    override protected Type[] PossibleRoots
    {
      get
      {
        Type[] possibleRoots =
        {
           typeof(NoRoots),
           typeof(OneRoot),
           typeof(TwoRoots),
           typeof(ThreeRoots),
           typeof(FourRoots)
        };
        return possibleRoots;
      }
    }

    override public RootsResult CalculateRoots(int a, int b, int c)
    {
      // Подсчитываем корни уравнения, как если бы оно было квадратным.

      RootsResult quadResult = base.CalculateRoots(a, b, c);

      PropertyInfo[] rootProperties = quadResult.GetRootProperties(); // Список свойств, обеспечивающих доступ к корням уравнения.

      // Перебираем корни.
      List<double> roots = new List<double>(); // Список, необходимый для хранения новых корней.

      foreach (PropertyInfo rootProperty in rootProperties)
      {
        if (rootProperty.Name.ToString() == "NumOfRoots") continue; // Количество корней нам сейчас не нужно обрабатывать.
        double root = (double)rootProperty.GetValue(quadResult, null); // Получаем значение текущего свойства.
        if (root < 0) continue;
        if (root == 0)
        {
          roots.Add(0);
          continue;
        }

        roots.Add(Math.Sqrt(root));
        roots.Add(-Math.Sqrt(root));
      }
      if (roots.Count == 0)
      {
        return new NoRoots();
      }
      RootsResult result = (RootsResult)Activator.CreateInstance(PossibleRoots[roots.Count], roots);
      return result;
    }
  }
}
