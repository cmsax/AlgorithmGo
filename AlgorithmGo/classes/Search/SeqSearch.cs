using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmGo.classes.Search
{

    /// <summary>
    /// 顺序查找
    /// 从一段开始，将给定的关键码
    /// </summary>
    class SeqSearch
    {
        /// <summary>
        /// 顺序查找,返回该值对应的键key
        /// </summary>
        /// <param name="seqList">顺序表</param>
        /// <param name="value">查找的值</param>
        /// <returns></returns>
        public int Search(SequenceList<int> seqList, int value)
        {
            for(int i = 0; i < seqList.GetLength(); i++)
            {
                if (seqList[i] == value) return i;
                else continue;
            }
            return -1;
        }


    }
}
