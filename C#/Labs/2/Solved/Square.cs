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

    public override string ToString()
    {
      return String.Format("\t{0}: ", this.FigureType) + "\n" +
        "Area = " + Area() + "\n" +
       "Width = " + Width;
    }
  }
}