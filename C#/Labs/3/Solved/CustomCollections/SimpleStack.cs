using System;
using System.Collections;
using System.Linq.Expressions;
using System.Text;

namespace CustomCollections
{
  /// <summary> 
  /// Класс стек.
  /// </summary> 
  class SimpleStack<T> : SimpleList<T> where T : IComparable
  {
    public SimpleStack(params T[] elements)
    {
      foreach (T Element in elements)
      {
        Push(Element);
      }
    }

    /// <summary> 
    /// Добавление в стек 
    /// </summary> 
    public void Push(T Element)
    {
      //Добавление в конец списка уже реализовано.
      Add(Element);
    }

    /// <summary> 
    /// Удаление и чтение из стека. 
    /// </summary> 
    public T Pop()
    {
      // default(T) - значение для типа T по умолчанию.
      T Result = default(T);
      // Если стек пуст, возвращается значение по умолчанию для типа.
      if (this.Count == 0) return Result;
      // Если элемент единственный.
      if (this.Count == 1)
      {
        // То из него читаются данные. 
        Result = this.First.Data;
        // Обнуляются указатели начала и конца списка.
        this.First = null;
        this.Last = null;
      }
      // В списке более одного элемента.
      else
      {
        // Поиск предпоследнего элемента.
        SimpleListItem<T> newLast = this.GetItem(this.Count - 2);
        // Чтение значения из последнего элемента.
        Result = newLast.Next.Data;
        // Предпоследний элемент считается последним.
        this.Last = newLast;
        // Последний элемент удаляется из списка. 
        newLast.Next = null;
      }
      // Уменьшение количества элементов в списке.
      this.Count--;
      // Возврат результата.
      return Result;
    }
  }
}