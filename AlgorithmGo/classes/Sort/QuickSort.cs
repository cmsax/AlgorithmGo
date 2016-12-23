using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmGo.classes
{
    class QuickSort
    {
        /// <summary>
        /// 快速排序
        /// </summary>
        /// <param name="sqList">顺序表</param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        public void Sort(SequenceList<int> sqList,int low, int high)
        {
            int i = low;
            int j = high;
            int tmp = sqList[low];

            while (low < high)
            {
                while (low < high && sqList[high] >= tmp)
                {
                    --high;
                }
                sqList[low] = sqList[high];
                ++low;
                while(low<high && sqList[low] <= tmp)
                {
                    ++low;
                }
                sqList[high] = sqList[low];
                --high;
            }
            sqList[low] = tmp;

            // 递归
            if (i < low - 1)
            {
                Sort(sqList, i, low - 1);
            }
            if (low + 1 < j)
            {
                Sort(sqList, low + 1, j);
            }
            
        }


    }
}
