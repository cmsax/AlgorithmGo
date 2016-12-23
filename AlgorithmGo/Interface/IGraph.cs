using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmGo.Interface
{
    /// <summary>
    /// 图 接口
    /// </summary>
    public interface IGraph
    {
        void AddEdge();             // 添加边
        void RemoveEdge();          // 删除边
        void AddNode();             // 添加结点
        void RemoveNode();          // 删除结点
        void BFS();                 // 广度优先遍历
        void DFS();                 // 深度优先遍历
        void GetMinTree();          // 最小生成树

    }
}
