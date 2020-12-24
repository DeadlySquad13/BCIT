using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_7
{
  /// <summary>
  /// Работник.
  /// </summary>
  public class Worker
  {
    public int ID;
    public string surname;
    public int departmentID;
    public Worker(int ID, string surname, int departmentID)
    {
      this.ID = ID;
      this.surname = surname;
      this.departmentID = departmentID;
    }
    public override string ToString()
    {
      return $"Работник с ID: {ID}, фамилией: {surname}, работает в отделе с ID: {departmentID}";
    }
  }
}
