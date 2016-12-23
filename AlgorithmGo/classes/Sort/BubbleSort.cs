using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmGo.classes
{
    class BubbleSort
    {
        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <param name="sqList">顺序表</param>
        /// <param name="asc">是否升序</param>
        public void Sort(SequenceList<int> sqList,bool asc)
        {
            // 时间复杂度为 O(1)
            int tmp;
            
            for (int i= 0; i < sqList.Last; ++i)
            {
                for (int j= sqList.Last - 1; j >= i; --j)
                {
                    if ( asc ? sqList[j + 1] < sqList[j] : sqList[j + 1] > sqList[j] )
                    {
                        tmp = sqList[j + 1];
                        sqList[j + 1] = sqList[j];
                        sqList[j] = tmp;
                    }
                }
            }

        }


    }
}
