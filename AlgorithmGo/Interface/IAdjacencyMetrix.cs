using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmGo.Interface
{
    /// <summary>
    /// 邻接矩阵 接口
    /// </summary>
    public interface IAdjacencyMetrix
    {
        int[,] GenerateMetix();           // 生成邻接矩阵


    }
}
