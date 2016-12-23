using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmGo.classes
{
    class DijkstraAlgorithm
    {
        //数据结构：
        //集合S，存放找到了最短路径的顶点
        //集合U，存放没有确定最短路径的顶点
        //数组distance，表示起点到该点在此刻的最短距离
        //数组prev，表示该点取到当前路径时的上一个参考点，初始参考点下标都为0
        //数组Isfor，表示是否确定已经为最短路径了

        //2.先把起点V0的下标0加到集合S，然后标记Isfor[0]=true;把起点的下标标记为0,把V1,V2,V3,V4,V5，V6的下标123456放到U中，
        //遍历集合U，把V0到各个顶点的距离添加到distance中（没有直接相连的边，就用2048这个大数表示）；

        //3.遍历distance，找到最小的距离，把顶点的下标添加到S中，然后设置该下标对应的Isfor的值为true，找到该下标为起点到各边的距离，
        //如果这个新起点到其余在U集合的顶点的距离和上一个起点到新起点的距离之和<distance数据的距离，就把该位置的distance值设为
        //（这个新起点到其余在U集合的顶点的距离和上一个起点到新起点的距离之和）；然后更改该顶点的对应pre的参考下标，为上一个起点的下标；
        //然后重复3；


        //构建V1到V7的邻接矩阵
        //static int Max = 2048;
        static int[,] Metrix = new int[7, 7]
        {
            {0,9,3,7,2048,2048,2048},
            {9,0,5,2048,2048,12,2048 },
            {3,5,0,8,19,4,2048},
            {7,2048,8,0,20,2048,2048 },
            {2048,2048,19,20,0,6,7 },
            {2048,12,4,2048,6,0,4 },
            {2048,2048,2048,2048,7,4,0 }
        };


        static int row = Metrix.GetLength(1); //都可用
        ArrayList S = new ArrayList(row);
        ArrayList U = new ArrayList(row);
        int[] distance = new int[row];//用以每次查询存放数据
        int[] prev = new int[row];//用以存储前一个最近顶点的下标
        bool[] Isfor = new bool[] { false, false, false, false, false, false, false };

        /// <summary>
        /// dijkstra算法核心
        /// </summary>
        /// <param name="Start">开始结点</param>
        public void Dijkstra(int Start)
        {
            S.Add(Start);
            Isfor[Start] = true;
            //把美没有找到最短路径的点放在集合U中
            for (int i = 0; i < row; i++)
            {
                if (i != Start)
                    U.Add(i);
            }
            //
            for (int i = 0; i < row; i++)
            {
                //开始结点到其它结点的距离
                distance[i] = Metrix[Start, i];
                prev[i] = 0;
            }
            int Count = U.Count;
            while (Count > 0)
            {
                int min_index = (int)U[0];//假设U中第一个数存储的是最小的数的下标
                foreach (int r in U)
                {
                    if (distance[r] < distance[min_index] && !Isfor[r])
                        min_index = r;
                }
                S.Add(min_index);//S加入这个最近的点
                Isfor[min_index] = true;
                U.Remove(min_index);//U中移除这个点；
                foreach (int r in U)
                {
                    //查找下一行邻接矩阵，如果距离和上一个起点的距离和与数组存储的相比比较小，就更改新的距离和起始点,再比对新的起点到各边的距离
                    if (distance[r] > distance[min_index] + Metrix[min_index, r])
                    {
                        distance[r] = distance[min_index] + Metrix[min_index, r];
                        prev[r] = min_index;
                    }
                    else
                    {
                        distance[r] = distance[r];
                    }
                }
                Count = U.Count;
            }
        }

        /// <summary>
        /// 显示邻接矩阵
        /// </summary>
        public StringBuilder displayMetrix()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("邻接矩阵：");
            for (int i = 0; i < row; i++)
            {
                sb.Append("{\t");
                for (int j = 0; j < row; j++)
                {
                    sb.Append(Metrix[i, j] + ",\t");
                }
                sb.Append("}\n");
                
            }
            return sb;
        }

        /// <summary>
        /// 把生成数据显示出来
        /// </summary>
        public StringBuilder displayResult()
        {
            StringBuilder sb2 = new StringBuilder();

            for (int i = 0; i < row; i++)
            {
                sb2.Append("V1到V{" + i + "}的最短路径为: V1");
                int prePoint = prev[i];
                string s = "";
                StringBuilder sb = new StringBuilder(10);
                while (prePoint > 0)
                {
                    s = (prePoint + 1) + s;
                    prePoint = prev[prePoint];
                }
                for (int j = 0; j < s.Length; j++)
                {
                    sb.Append("→V").Append(s[j]);
                }
                sb2.Append(sb.ToString());
                sb2.Append("→V{" + i + "}");
                sb2.Append(":{" + distance[i] + "}");
            }
            return sb2;

        }
    }
}
