using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;

namespace Lab_1.EquationSolvers
{
  abstract class EquationSolver
  {
    abstract protected Type[] PossibleRoots { get; }
    abstract public RootsResult CalculateRoots(int a, int b, int c);
    public void OutputRoots(RootsResult result)
    {
      Type resultType = result.GetType();
      if (resultType.Name.ToString() == "NoRoots")
      {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Корней нет!");
        Console.ResetColor();
        return;
      }

      PropertyInfo[] rootProperties = result.GetRootProperties();

      Console.ForegroundColor = ConsoleColor.Green;
      foreach (PropertyInfo rootProperty in rootProperties)
      {
        var root = rootProperty.GetValue(result, null);
        Console.WriteLine(root);
      }
      Console.ResetColor();
    }
  }
}
