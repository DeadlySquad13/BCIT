using System;

namespace GeometricFigures
{
  public abstract class GeometricFigure : IPrint
  {
    public string FigureType { get; protected set; }
    public abstract double Area();

    public override string ToString()
    {
      return String.Format("\t{0}: ", this.FigureType) + "\n" + "Area = " + Area();
    }
    public void Print()
    {
      Console.WriteLine(this.ToString());
    }
  }
}
