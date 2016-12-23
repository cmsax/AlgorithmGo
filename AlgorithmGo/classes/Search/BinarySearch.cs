using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmGo.classes.Search
{
    /// <summary>
    /// 有序表的折半查找
    /// </summary>
    class BinarySearch
    {
        /// <summary>
        /// 折半查找 非递归
        /// </summary>
        /// <param name="seqList">有序顺序表</param>
        /// <param name="key">要查找的值</param>
        /// <param name="n">High</param>
        /// <returns>键值</returns>
        public int Search(SequenceList<int> seqList, int n, int key)
        {
            int low = 0;
            int high = n - 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (key == seqList[mid])
                {
                    return mid;
                }
                else if (key > seqList[mid])
                {
                    low = mid + 1;
                }
                else if(key < seqList[mid])
                {
                    high = mid - 1;
                }
            }
            
            return -1; // 查找失败
        }

        /// <summary>
        /// 折半查找 递归
        /// </summary>
        /// <param name="seqList"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <param name="value"></param>
        /// <returns>键值</returns>
        public int Search2(SequenceList<int> seqList, int low, int high, int key)
        {
            int mid = (low + high) / 2;
            if (seqList[mid] == key)
                return mid;
            if (seqList[mid] > key)
                Search2(seqList, low, mid - 1, key);
            else
                Search2(seqList, mid + 1, high, key);

            return -1; // 查找失败
        }

    }
}
