using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lab_1.Roots;

namespace Lab_1.EquationSolvers
{
  class QuadraticEquationSolver : EquationSolver
  {
    override protected Type[] PossibleRoots
    {
      get
      {
        Type[] possibleRoots =
        {
          typeof(NoRoots),
          typeof(OneRoot),
          typeof(TwoRoots)
        };
        return possibleRoots;
      }
    }
    override public RootsResult CalculateRoots(int a, int b, int c)
    {
      RootsResult result;
      double discriminant = b * b - 4 * a * c;

      if (discriminant < 0)
      {
        result = new NoRoots();
      }
      else if (discriminant == 0)
      {
        result = new OneRoot(-b / 2 * a);
      }
      else
      {
        result = new TwoRoots(
            (-b - Math.Sqrt(discriminant)) / 2 * a,
            (-b + Math.Sqrt(discriminant)) / 2 * a
          );
      }

      return result;
    }
  }
}
