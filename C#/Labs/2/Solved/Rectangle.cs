using System;

namespace GeometricFigures
{
  public class Rectangle : GeometricFigure
  {
    private double _width;
    public double Width
    {
      get
      {
        return _width;
      }
      private set
      {
        if (value < 0) throw new ArgumentException(String.Format("Argument Exception: all dimensions of a geometric figure should be >= 0. {0} < 0!", value), "Width");

        _width = value;
      }
    }
    private double _length;
    public double Length
    {
      get
      {
        return _length;
      }
      private set
      {

        if (value < 0) throw new ArgumentException(String.Format("Argument Exception: all dimensions of a geometric figure should be >= 0. {0} < 0!", value), "Length");

        _length = value;
      }
    }
    public Rectangle()
    {
      FigureType = "Rectangle";
    }
    public Rectangle(double width, double length) : this()
    {
      Width = width;
      Length = length;
    }

    public override double Area()
    {
      return Width * Length;
    }

    public override string ToString()
    {
      return base.ToString() + "\n" +
         "Width = " + Width + "\n" +
        "Length = " + Length;
    }
  }
}
