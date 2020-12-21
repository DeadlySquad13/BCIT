using System;

namespace CustomCollections
{
  /// <summary> 
  /// Элемент списка 
  /// </summary> 
  public class SimpleListItem<T>
  {
    /// <summary> 
    /// Данные 
    /// </summary> 
    public T Data { get; set; }

    /// <summary> 
    /// Следующий элемент 
    /// </summary> 
    public SimpleListItem<T> Next { get; set; }

    ///конструктор 
    public SimpleListItem(T param)
    {
      this.Data = param;
    }
  }
}
