using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab_1.Roots
{
  class OneRoot : RootsResult
  {
    public double Root { get; private set; }
    public OneRoot(double root)
    {
      Root = root;
    }
    public OneRoot(List<double> roots) : this(roots[0])
    {
    }
  }
}
