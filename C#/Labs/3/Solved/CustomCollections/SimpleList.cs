using System;
using System.Collections.Generic;

namespace CustomCollections
{
  public class SimpleList<T> : IEnumerable<T>
        where T : IComparable
  {
    /// <summary> 
    /// Первый элемент списка.
    /// </summary> 
    protected SimpleListItem<T> First = null;

    /// <summary> 
    /// Последний элемент списка. 
    /// </summary> 
    protected SimpleListItem<T> Last = null;

    /// <summary> 
    /// Количество элементов. 
    /// </summary> 
    public int Count { get; protected set; }

    /// <summary> 
    /// Добавление элемента.
    /// </summary> 
    public void Add(T element)
    {
      SimpleListItem<T> newItem =
                          new SimpleListItem<T>(element);
      this.Count++;

      // Добавление первого элемента.
      if (Last == null) 
      { 
          this.First = newItem; 
          this.Last = newItem; 
      } 
      // Добавление следующих элементов.
      else 
      { 
          //Присоединение элемента к цепочке.
          this.Last.Next = newItem; 
          //Присоединенный элемент считается последним.
          this.Last = newItem; 
      }
    }

      /// <summary> 
      /// Чтение контейнера с заданным номером.
      /// </summary> 
      public SimpleListItem<T> GetItem(int number)
      {
        if ((number < 0) || (number >= this.Count))
        {
          // Можно создать собственный класс исключения.
          throw new ArgumentOutOfRangeException("Выход за границу индекса");
        }
        SimpleListItem<T> Current = this.First;

        for (int i = 0; i < number; i ++)
        {
          Current = Current.Next;
        }
        
        return Current;
      }

      /// <summary> 
      /// Чтение элемента с заданным номером. 
      /// </summary> 
      public T Get(int number)
      {
        return GetItem(number).Data;
      }

      /// <summary> 
      /// Для перебора коллекции 
      /// </summary> 
      public IEnumerator<T> GetEnumerator() 
      {
        SimpleListItem<T> Current = this.First;

        //Перебор элементов 
        while (Current != null)
        {
          //Возврат текущего значения 
          yield return Current.Data;
          //Переход к следующему элементу 
          Current = Current.Next;
        }
      }

      // Реализация обобщенного IEnumerator<T> требует реализации необобщенного интерфейса.
      // Данный метод добавляется автоматически при реализации интерфейса. 
      System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() 
      {
        return GetEnumerator();
      }

      /// <summary> 
      /// Cортировка.
      /// </summary> 
      public void Sort()
      {
        Sort(0, this.Count - 1);
      }

      /// <summary> 
      /// Алгоритм быстрой сортировки.
      /// </summary> 
      private void Sort(int low, int high)
      {
        int i = low;
        int j = high;
        T x = Get((low + high) / 2);
        do
        {
          while (Get(i).CompareTo(x) < 0) ++i;
          while (Get(j).CompareTo(x) > 0) --j;
          if (i <= j)
          {
            Swap(i, j);
            i++; j--;
          }
        } while (i <= j);
        if (low < j) Sort(low, j);
        if (i < high) Sort(i, high);
      }

      /// <summary> 
      /// Вспомогательный метод для обмена элементов при сортировке
      /// </summary> 
      private void Swap(int i, int j)
      {
        SimpleListItem<T> ci = GetItem(i);
        SimpleListItem<T> cj = GetItem(j);
        T Temp = ci.Data;
        ci.Data = cj.Data;
        cj.Data = Temp;
      } 
   } 
} 
