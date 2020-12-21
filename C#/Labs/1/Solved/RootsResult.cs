using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;
using System.Text.RegularExpressions;

namespace Lab_1
{
  class RootsResult
  {
    public int NumOfRoots
    {
      get
      {
        Type resultType = this.GetType(); // Тип класса, в котором вызывается геттер.

        PropertyInfo[] rootProperties = resultType.GetProperties();
        return rootProperties.Length;
      }
    }
    /// <summary>
    /// Метод отбирает из свойств данного класса свойства, обеспечивающих доступ к корням уравнения.
    /// </summary>
    /// <returns>Массив со свойствами, обеспечивающими доступ к корням уравнения.</returns>
    public PropertyInfo[] GetRootProperties()
    {
      Type T = this.GetType(); // Тип класса, в котором вызывается метод GetRootProperties.

      PropertyInfo[] properties = T.GetProperties(); // Массив всех свойств данного класса.

      string pattern = @"^Root\d*$";
      Regex rgx = new Regex(pattern);

      IEnumerable<PropertyInfo> rootProperties = properties.Where(property => rgx.IsMatch(property.Name)); // Отфильтровали массив, получив необходимый набор свойств.

      return rootProperties.ToArray();
    }
  }
}
