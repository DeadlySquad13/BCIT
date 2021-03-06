﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab_1.Roots
{
  class ThreeRoots : RootsResult
  {
    public double Root1 { get; private set; }
    public double Root2 { get; private set; }
    public double Root3 { get; private set; }
    public ThreeRoots(double root1, double root2, double root3)
    {
      Root1 = root1;
      Root2 = root2;
      Root3 = root3;
    }
    public ThreeRoots(List<double> roots) : this(roots[0], roots[1], roots[2])
    {
    }
  }
}
