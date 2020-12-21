using System;

namespace GeometricFigures
{
  public class Square : Rectangle
  {
    public Square()
    {
      FigureType = "Square";
    }
    public Square(double width) : base(width, width)
    {
      FigureType = "Square";
    }
  }
}