using System;

namespace GeometricFigures
{
  public abstract class GeometricFigure : IPrint, IComparable
  {
    public string FigureType { get; protected set; }
    public abstract double Area();

    public int CompareTo(object obj)
    {
      // Приведение параметра к типу "фигура".
      GeometricFigure p = (GeometricFigure)obj;
      // Сравнение.
      if (this.Area() < p.Area()) return -1;
      else if (this.Area() == p.Area()) return 0;
      else return 1; //(this.Area() > p.Area())
    }
    public override string ToString()
    {
      return this.FigureType.ToString() + " Area = " + Area();
    }
    public void Print()
    {
      Console.WriteLine(this.ToString());
    }
  }
}
