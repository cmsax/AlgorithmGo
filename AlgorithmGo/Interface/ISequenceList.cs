using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmGo.Interface
{

    /// <summary>
    /// 泛型线性表接口
    /// </summary>
    /// <typeparam name="T">泛型</typeparam>
    public interface ISequenceList<T>
    {
        int GetLength();
        void Clear();
        bool IsEmpty();
        void Append(T item);
        void Insert(T item, int index);
        void Delete(int index);
        T GetElememt(int index);
        int Locate(T value);
        void Reverse();
        void Merge();
        void Purge();
        void Duplicate();
        
    }
}
