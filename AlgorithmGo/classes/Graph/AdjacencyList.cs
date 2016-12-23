using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmGo.classes.Graph
{
    /// <summary>
    /// 邻接矩阵构建图结构
    /// </summary>
    public class AdjacencyList<T>
    {
        List<Vertex<T>> items;                  //图的顶点集合

        // 构造器
        public AdjacencyList() : this(10) { }   //构造方法
        public AdjacencyList(int capacity)      //指定容量的构造方法
        {
            items = new List<Vertex<T>>(capacity);
        }

        // 添加顶点
        public void AddVertex(T item)
        {   //不允许插入重复值
            if (Contains(item))
            {
                throw new ArgumentException("插入了重复顶点！");
            }
            items.Add(new Vertex<T>(item));
        }
        
        // 添加无向边
        public void AddEdge(T from, T to)
        {
            Vertex<T> fromVer = Find(from);     //找到起始顶点
            if (fromVer == null)
            {
                throw new ArgumentException("头顶点并不存在！");
            }
            Vertex<T> toVer = Find(to);         //找到结束顶点
            if (toVer == null)
            {
                throw new ArgumentException("尾顶点并不存在！");
            }
            //无向边的两个顶点都需记录边信息
            AddDirectedEdge(fromVer, toVer);
            AddDirectedEdge(toVer, fromVer);
        }

        // 查找是否包含某项
        public bool Contains(T item)
        {
            foreach (Vertex<T> v in items)
            {
                if (v.data.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        // 查找指定项并返回
        public Vertex<T> Find(T item)
        {
            foreach (Vertex<T> v in items)
            {
                if (v.data.Equals(item))
                {
                    return v;
                }
            }
            return null;
        }

        // 添加有向边
        private void AddDirectedEdge(Vertex<T> fromVer, Vertex<T> toVer)
        {
            if (fromVer.firstEdge == null)      //无邻接点时
            {
                fromVer.firstEdge = new Node(toVer);
            }
            else
            {
                Node tmp, node = fromVer.firstEdge;
                do
                {   //检查是否添加了重复边
                    if (node.adjvex.data.Equals(toVer.data))
                    {
                        throw new ArgumentException("添加了重复的边！");
                    }
                    tmp = node;
                    node = node.next;
                } while (node != null);
                tmp.next = new Node(toVer);     //添加到链表未尾
            }
        }

        // 用于展示图结点与邻接点 仅用于测试
        public override string ToString()
        {   //打印每个节点和它的邻接点
            string s = string.Empty;
            foreach (Vertex<T> v in items)
            {
                s += v.data.ToString() + ":";
                if (v.firstEdge != null)
                {
                    Node tmp = v.firstEdge;
                    while (tmp != null)
                    {
                        s += tmp.adjvex.data.ToString();
                        tmp = tmp.next;
                    }
                }
                s += "\r\n";
            }
            return s;
        }

        #region 深度优先遍历

        // 深度优先遍历
        public StringBuilder DFSTraverse() 
        {
            InitVisited(); //将visited标志全部置为false
            return  DFS(items[0]); //从第一个顶点开始遍历
        }

        // 使用递归进行深度优先遍历
        private StringBuilder DFS(Vertex<T> v) 
        {
            StringBuilder s = new StringBuilder();

            v.visited = true; //将访问标志设为true
            s.Append(v.data + " "); //访问
            Node node = v.firstEdge;
            while (node != null) //访问此顶点的所有邻接点
            {   //如果邻接点未被访问，则递归访问它的边
                if (!node.adjvex.visited)
                {
                    DFS(node.adjvex); //递归
                }
                node = node.next; //访问下一个邻接点
            }
            return s;
        }

        // 初始化visited标志
        private void InitVisited() 
        {
            foreach (Vertex<T> v in items)
            {
                v.visited = false; //全部置为false
            }
        }

        #endregion

        #region 广度优先遍历
        public StringBuilder BFSTraverse() //广度优先遍历
        {
            InitVisited(); //将visited标志全部置为false
            return BFS(items[0]); //从第一个顶点开始遍历
        }
        private StringBuilder BFS(Vertex<T> v) //使用队列进行广度优先遍历
        {
            StringBuilder sb = new StringBuilder();
            //创建一个队列
            Queue<Vertex<T>> queue = new Queue<Vertex<T>>();
            sb.Append(v.data + " "); //访问
            v.visited = true; //设置访问标志
            queue.Enqueue(v); //进队
            while (queue.Count > 0) //只要队不为空就循环
            {
                Vertex<T> w = queue.Dequeue();
                Node node = w.firstEdge;
                while (node != null) //访问此顶点的所有邻接点
                {   //如果邻接点未被访问，则递归访问它的边
                    if (!node.adjvex.visited)
                    {
                        sb.Append(node.adjvex.data + " "); //访问
                        node.adjvex.visited = true; //设置访问标志
                        queue.Enqueue(node.adjvex); //进队
                    }
                    node = node.next; //访问下一个邻接点
                }
            }

            return sb;
        }
        #endregion



        /// <summary>
        /// 嵌套类，表示链表中的表结点
        /// </summary>
        public class Node
        {
            public Vertex<T> adjvex;    //邻接点域
            public Node next;           //下一个邻接点指针域
            public Node(Vertex<T> value)
            {
                adjvex = value;
            }
        }

        /// <summary>
        /// 嵌套类，表示存放于数组中的表头结点
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        public class Vertex<TValue>
        {
            public TValue data;         //数据
            public Node firstEdge;      //邻接点链表头指针
            public Boolean visited;     //访问标志,遍历时使用
            public Vertex(TValue value) //构造方法
            {
                data = value;
            }

        }
    }

}
