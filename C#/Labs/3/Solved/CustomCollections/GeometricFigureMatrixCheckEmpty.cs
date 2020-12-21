using GeometricFigures;
using CustomCollections;

class GeometricFigureMatrixCheckEmpty : IMatrixCheckEmpty<GeometricFigure>
  {
    /// <summary> 
    /// В качестве пустого элемента возвращается null 
    /// </summary> 
    public GeometricFigure GetEmptyElement()
    {
      return null;
    }

    /// <summary> 
    /// Проверка что переданный параметр равен null 
    /// </summary> 
    public bool CheckEmptyElement(GeometricFigure element)
    {
      bool Result = false;
      if (element == null)
      {
        Result = true;
      }
      return Result;
    }
  }
