using System;

namespace GeometricFigures
{
  public class Circle : GeometricFigure
  {
    private double _radius;
    public double Radius
    {
      get
      {
        return _radius;
      }
      private set
      {
        if (value < 0) throw new ArgumentException(String.Format("Argument Exception: all dimensions of a geometric figure should be >= 0. {0} < 0!", value), "Radius");

        _radius = value;
      }
    }

    public Circle()
    {
      FigureType = "Circle";
    }
    public Circle(double radius) : this()
    {
      Radius = radius;
    }

    public override double Area()
    {
      return Math.PI * Radius * Radius;
    }

    public override string ToString()
    {
      return base.ToString() + "\n" +
        "Radius = " + Radius;
    }
  }
}
