using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab_1.Roots
{
  class TwoRoots : RootsResult
  {
    public double Root1 { get; private set; }
    public double Root2 { get; private set; }
    public TwoRoots(double root1, double root2)
    {
      Root1 = root1;
      Root2 = root2;
    }
    public TwoRoots(List<double> roots) : this(roots[0], roots[1])
    {
    }
  }
}
