using AlgorithmGo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmGo.classes
{
    public class SequenceList<T> : ISequenceList<T>
    {
        #region 字段
        private int maxsize;
        private T[] data;
        private int last;
        #endregion

        #region 属性
        public T this[int index]
        {
            get { return data[index]; }
            set { data[index] = value; }
        }

        public int Last
        {
            get { return last; }
        }

        public int Maxsize
        {
            get { return maxsize; }
            set { maxsize = value; }
        }
        #endregion

        #region 构造器
        public SequenceList(int size)
        {
            data = new T[size];
            maxsize = size;
            last = -1; //初始化为-1
        }
        #endregion

        #region 方法
        // 获取长度
        public int GetLength()
        {
            return last + 1;
            
        }

        // 清空
        public void Clear()
        {
            last = -1; //假装清空
        }

        // 判断是否为空
        public  bool IsEmpty()
        {
            return last==-1 ? true : false;
        }

        // 判断是否已满
        public bool IsFull()
        {
            return maxsize == last + 1 ? true : false;
        }

        // 在末尾添加元素
        public void Append(T item)
        {
            if (IsFull())
            {
                Console.WriteLine("Full List!");
                throw new Exception("Full List Exception");
            }
            else
                data[++last] = item; // 已经++last 修改表长了
        }

        // 在指定位置插入元素
        public void Insert(T item, int index)
        {
            if (IsFull())
            {
                Console.WriteLine("Full List!");
                throw new Exception("Full List Exception");
            }
            else if (index < 1 || index > last+2)
            {
                Console.WriteLine("Wrong Insert Position!");
                throw new Exception("Wrong Insert Position Exception");
            }
            else // 先将所有的元素往后移动，然后将元素插入，将last++
            {
                for(int j = last; j >= index - 1; j--)
                {
                    data[j + 1] = data[j];
                }
                data[index - 1] = item;
            }

            ++last;
        }

        // 删除指定位置的元素
        public void Delete(int index)
        {
            // T tmp = default(T);
            if (IsEmpty())
            {
                Console.WriteLine("Empty List!");
                throw new Exception("Empty List Exception");
            }
            else if (index < 1 || index > last + 1)
            {
                Console.WriteLine("Wrong Delete Position!");
                throw new Exception("Wrong Delete Postition Exception");
            }
            else if (index == last + 1)
            {

            }
            else // 使用后面的元素直接代替原来的元素，--last
            {
                for(int j = index; j <= last; j++)
                {
                    data[j] = data[j+1];
                }
                --last;
            }
        }

        // 获取指定位置的元素
        public T GetElememt(int index)
        {
            if (IsEmpty())
            {
                Console.WriteLine("Empty List!");
                throw new Exception("Empty List Exception");
            }
            else if (index < 1 || index > last + 1)
            {
                Console.WriteLine("Wrong Position!");
                throw new Exception("Wrong Postition Exception");
            }
            else
                return data[index - 1];
        }

        // 获取指定元素的位置
        public int Locate(T value)
        {
            if (IsEmpty())
            {
                Console.WriteLine("Empty List!");
                throw new Exception("Empty List Exception");
            }

            // 定义一个索引，从前往后找，找到了就返回索引值，没找到就返回-1
            int index = 0;
            for (index = 0; index <= last; ++index)
            {
                if (value.Equals(data[index]))
                {
                    break;
                }
            }
            return index > last ? -1 : index;
        }

        // 使整个顺序表倒置
        public void Reverse()
        {
            //TODO: 实现整个顺序表的Reverse
            // 时间复杂度为 O(n)
            T tmp = default(T);
            int length = GetLength();
            for(int i = 0; i < length; ++i)
            {
                tmp = data[i];
                data[i] = data[i - 1];
                data[i - 1] = tmp;
            }
        }

        public void Merge()
        {
            //TODO: 按升序将两个顺序表合并
        }

        public void Purge()
        {
            //TODO: 清除两个顺序表中相同的元素
        }

        public void Duplicate()
        {
            //TODO: 顺序表去重
        }


        #endregion
    }
}
