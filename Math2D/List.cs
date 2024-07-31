using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Csharp核心实践.Math2D
{

    public class TDKList<T> where T : class
    {
        T[] array;
        public int lenth;
        public int capacity;
        public TDKList()
        {
            array = new T[12];
            lenth = 0;
            capacity = 12;
        }
        public T[] ToArray()
        {
            T[] relis = new T[lenth];
            for (int i = 0; i < lenth; i++)
            {
                relis[i] = array[i];
            }
            return relis;
        }
        public void Append(T value)
        {
            if (lenth >= capacity)
            {

                T[] newArry = new T[capacity *= 2];
                for (int i = 0; i < lenth; i++)
                {
                    newArry[i] = array[i];

                }
                array = newArry;

            }
            array[lenth++] = value;

        }
        public T this[int i]
        {
            get
            {
                return array[i];
            }
            set
            {
                array[i] = value;
            }
        }

        public T GetTail()
        {
            if (lenth == 0)
            {
                return null;
            }
            else
            {
                return array[lenth - 1];
            }
        }
        public void Remove(T target)
        {
            for (int i = 0; i < lenth; i++)
            {
                if (target == array[i])
                {
                    RemoveAt(i);
                    return;
                }
            }
        }
        public void RemoveAt(int intdex)
        {
            if (intdex >= lenth) { return; }
            for (int i = intdex; i < lenth - 1; i++)
            {
                array[i] = array[i + 1];
            }
            lenth--;
        }



    }


}
