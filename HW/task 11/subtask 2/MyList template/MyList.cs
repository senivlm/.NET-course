using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASDF
{
    public class Comparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return x.CompareTo(y);
        }
    }
    internal class MyList:IEnumerable
    {
        List<int> _list;

        public MyList()
        {
            _list = new();
        }


        public MyList(params int[] items)
        {
            _list = new(items);
        }

        public int this[int index]
        {
            get
            {
                if (index <= _list.Count && index >= 0)
                {
                    return _list[index];
                }
                throw new IndexOutOfRangeException();
            }
            set
            {
                _list[index] = value;
            }
        }

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Sort()
        {
            // _list.Sort(new Comparer());
            _list.Sort(delegate (int x, int y)
            {
                return x.CompareTo(y);
            });
        }

        public void Add(int item)
        {
            _list.Add(item);
        }

        public override string ToString()
        {
            string ans = "";
            foreach (var item in _list)
            {
                ans += item + " ";
            }
            return ans;
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(int item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(int[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = _list.Count - 1; i >= 0; i--)
            {
                yield return _list[i];
            }
        }

        public int IndexOf(int item)
        {
            return _list.IndexOf(item);
        }

        public void Insert(int index, int item)
        {
            _list.Insert(index, item);
        }

        public bool Remove(int item)
        {
            return _list.Remove(item);
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }


    interface IPrint<T>
    {
        public void Print(T obj);
    }

   

    public class MyList<T>:  IList<T>
    {
        List<T> _list;
        public MyList()
        {
            _list = new List<T>();
            
        }
        public MyList(IEnumerable<T> e)
        {
            _list = new List<T>();
            foreach (T item in e)
                _list.Add(item);
        }

        private int FindIndex(int left, int right, T item, IComparer<T> comparer)
        {
            if (item == null)
                return -1;
            if (right - left <= 1)
            {
                if (_list[left].Equals( item))
                    return left;
                if (_list[right].Equals( item))
                    return right;
                else return -1;
                // return _list[left] == item ? left : -1;
            }

            int middle = (left + right) / 2;

            if (_list[middle].Equals(item))
            {
                return middle;
            }

            if (comparer.Compare( item, _list[middle])<0)
            {
                right = middle;
            }
            else
            {
                left = middle;
            }
            return FindIndex(left, right, item, comparer);
        }

        public int FindIndex(T item, IComparer<T> comparer)
        {
            int left = 0;
            int right = _list.Count;

            _list.Sort();

            return FindIndex(left, right, item, comparer);
        }

        public T this[int index] { get => _list[index]; set => _list[index] = value; }

        public int Count => _list.Count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            _list.Add(item);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(T item)
        {
            return  _list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

       

        public int IndexOf(T item)
        {
            return IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _list.Insert(index, item);
        }

        public bool Remove(T item)
        {
            return _list.Remove(item);
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }

        public override string ToString()
        {
            StringBuilder str = new();
            foreach (var item in _list)
            {
                str.Append(item.ToString() + "\n");
            }
            return str.ToString();
        }
        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)_list).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    throw new NotImplementedException();
        //}


        //IEnumerator<T> IEnumerable<T>.GetEnumerator()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
