using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_7
{
  /// <summary>
  /// Устанавливает одиночную связь между Worker и Department.
  /// </summary>
  class DataLink
  {
    public int DepartmentID;
    public int WorkerID;
    public DataLink(int DepartmentID, int WorkerID)
    {
      this.DepartmentID = DepartmentID;
      this.WorkerID = WorkerID;
    }
  }
}
