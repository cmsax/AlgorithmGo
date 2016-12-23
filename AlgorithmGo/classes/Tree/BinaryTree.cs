using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmGo.classes.Tree
{
    /// <summary>
    /// 二叉树
    /// </summary>
    public class BinaryTree
    {
        private Node _head;
        private string cStr;
        public Node Head
        {
            get { return _head; }
            set { _head = value; }
        }

        private StringBuilder sb = new StringBuilder();
        public StringBuilder Sb
        {
            get { return sb; }
            set { sb = value; }
        }

        // 构造器
        public BinaryTree()
        {
            _head = null;
        }

        public BinaryTree(string constructStr)      //默认的是以层序序列构造二叉树的
        {
            cStr = constructStr;
            if (cStr[0] == '#')
            {
                _head = null;
                return;                             //根节点为空，则树无法建立
            }
            _head = new Node(cStr[0]);
            Add(_head, 0);
        }

        // 按照给定层序序列给二叉树添加节点
        private void Add(Node parent, int index)
        {
            int leftIndex = 2 * index + 1;
            if (leftIndex < cStr.Length)
            {
                if (cStr[leftIndex] != '#')
                {
                    parent.Left = new Node(cStr[leftIndex]);
                    Add(parent.Left, leftIndex);
                }
            }
            int rightIndex = 2 * index + 2;
            if (rightIndex < cStr.Length)
            {
                if (cStr[rightIndex] != '#')
                {
                    parent.Right = new Node(cStr[rightIndex]);
                    Add(parent.Right, rightIndex);
                }
            }
        }

        //递归先序遍历
        public void PreOrder(Node node)
        {
            sb.Clear();
            if (node != null)
            {
                //Console.Write(node);
                sb.Append(node+",");
                PreOrder(node.Left);
                PreOrder(node.Right);
            }
        }

        //递归中序遍历
        public void InOrder(Node node)
        {
            if (node != null)
            {
                InOrder(node.Left);
                Console.Write(node);
                InOrder(node.Right);
            }
        }

        //递归后序遍历
        public void AfterOrder(Node node)
        {
            if (node != null)
            {
                AfterOrder(node.Left);
                AfterOrder(node.Right);
                Console.Write(node);
            }
        }

        /*先序非递归遍历树的原则：
         * 1、先访问当前节点的(node)所有左孩子
         *  在访问某个节点操作完成后立即将该节点入栈。
         * 2、当前访问完一个节点的所有左孩子后，进行出栈操作，
         *  如果出栈节点没有右孩子，则继续出栈，操作。否则按第
         *  1步访问该出栈节点的右孩子节点。
         */

        //先序遍历的非递归实现
        public void PreStackOrder()
        {
            sb.Clear();

            Node node = _head;
            Stack<Node> stack = new Stack<Node>();
            while (node != null || stack.Count > 0)
            {
                while (node != null)//第1步
                {
                    //Console.Write(node);//先序的本质就是第一次遇到节点时候访问它
                    sb.Append(node+" -> ");
                    stack.Push(node);
                    node = node.Left;
                }
                if (stack.Count > 0)//第2步
                {
                    node = stack.Pop();
                    node = node.Right;//如果出栈节点没有右孩子的话则继续出栈操作

                }
            }

        }

        //中序遍历的非递归实现
        public void InStackOrder()
        {
            sb.Clear();

            Node node = _head;
            Stack<Node> stack = new Stack<Node>();
            while (node != null || stack.Count > 0)
            {
                while (node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }
                if (stack.Count > 0)
                {
                    node = stack.Pop();
                    sb.Append(node + " -> ");
                    //Console.Write(node);//中序遍历的本质就是在第二次遇到节点时候访问它
                    node = node.Right;
                }
            }

        }

        /*后序遍历的非递归实现(比较复杂)。后序遍历的本质就是在第三次遇到节点的时候访问它，
         * 但是向上面那种方式只能在进栈的时候遇到一次和出栈的时候遇到一次
         */
        /*方法一：利用两个栈。
         * 1、按照左节孩子的方向将节点和当前节点的右孩子同时入栈，直到没有左孩子为止
         * 2、两个栈同时出栈，若右栈出栈的是null则访问左栈出栈的节点
         *  如果不为null，则左边出栈的退回左栈，右栈入栈个null
         * 3、对右出栈的右孩子节点重复第1和第2步操作知道两个栈都为空
         *  
         */
        public void AfterStackOrder()
        {
            sb.Clear();

            Stack<Node> lstack = new Stack<Node>();//用于存放父节点
            Stack<Node> rstack = new Stack<Node>();//用于存放右孩子
            Node node = _head, right;//right用于存放右栈出栈的节点
            do
            {
                while (node != null)//当node不为空的时候将父节点和右孩子同时入栈
                {
                    right = node.Right;
                    lstack.Push(node);
                    rstack.Push(right);
                    node = node.Left;//沿着左孩子的方向继续循环
                }
                node = lstack.Pop();//父节点和右孩子同时出栈
                right = rstack.Pop();
                if (right == null)//如果右栈出栈的元素为空则访问左边出栈的元素
                {
                    sb.Append(node + " -> ");
                    //Console.Write(node);
                }
                else
                {
                    lstack.Push(node);//左边出栈的元素退回栈
                    rstack.Push(null);//右栈补充一个空元素
                }
                node = right;//如果右边出栈的部位空则以上面的规则访问这个右孩子节点
            }
            while (rstack.Count > 0 || rstack.Count > 0);//当左栈或右栈不空的时候继续循环。
        }

        /*方法二：只利用一个栈，利用规律：任何节点如果存在做孩子，那么在后续遍历中，
         * 必然紧跟在它的右孩子后面。
         * 规则：
         * 1、同上沿着左孩子依次入栈。
         * 2、如果之前出栈节点是栈顶元素右边孩子或为空则出栈，即访问该节点。
         * 3、不满足以上条件则将栈顶元素的右孩子入栈
         */
        public void AfterStackOrder2()//性能更优的单栈非递归算法
        {
            Node node = _head, pre = _head;
            //pre指针指向“之前出栈节点”，如果为null有问题，这里指向头节点,因为后续遍历中头节点肯定是最后被访问的。
            Stack<Node> stack = new Stack<Node>();
            while (node != null || stack.Count > 0)
            {
                while (node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }
                if (stack.Count > 0)
                {
                    Node temp = stack.Peek().Right;//获取栈顶元素的右孩子，C#的栈因为有了这个方法使得操作简单
                    if (temp == null || temp == pre)//满足规则1
                    {
                        node = stack.Pop();//出栈进行访问
                        Console.Write(node);
                        pre = node;//设置“之前出栈节点”
                        node = null;//防止null再次入栈
                    }
                    else
                    {
                        node = temp;//规则2 继续循环。将栈顶节点的右孩子入栈，重复规则1的操作
                    }
                }
            }

        }

        /*方法三：在特定情况下性能优于方法二
         * 这种方法是在前面的非递归先序遍历算法的基础上进行修改然后的到后续遍历的逆序。
         * 这种算法在时间复杂度上与前面两种算法相同，但是空间复杂度上较差，但它在某些
         * 情况下却是最优秀的：
         * 1、只是为了得到二叉树的后续遍历序列，那么最后的逆序的操作就可以省掉
         */
        public void AfterStackOrder3()
        {
            Node node = _head;
            Stack<Node> stack = new Stack<Node>();
            Stack<Node> st = new Stack<Node>();//辅助栈将的到的逆序变为正的
            while (node != null || stack.Count > 0)
            {
                while (node != null)
                {
                    st.Push(node);
                    stack.Push(node);
                    node = node.Right;//在先序遍历非递归算法中这里是node.Left及沿着右孩子放学压入栈
                }
                if (stack.Count > 0)
                {
                    node = stack.Pop();
                    node = node.Left;//在先序遍历非递归算法中这里是node.Right

                }
            }
            while (st.Count > 0)
                Console.Write(st.Pop());
        }

        //广度优先遍历
        public void LevelOrder()
        {
            sb.Clear();

            Node node = _head;
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(node);
            while (queue.Count > 0)
            {
                node = queue.Dequeue();

                sb.Append(node+" -> ");
                //Console.Write(node);
                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);

                }
                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
            }
        }

        /*二叉树遍历的应用*/
        //1、计算叶子节点的个数(先序遍历)
        //度为2的节点和度为0的节点也就是叶子节点的关系是n0=n2+1;加上可以统计节点的个数所以就可以
        //分别统计度为0、度为1和度为2的节点数了。
        public void CountLeaf(Node node, ref int count)
        {
            if (node != null)
            {
                if ((node.Left == null) && (node.Right == null))
                    count++;
                CountLeaf(node.Left, ref count);
                CountLeaf(node.Right, ref count);
            }
        }

        //计算节点数
        public int Count(Node root)
        {
            if (root == null) return 0;
            return Count(root.Left) + Count(root.Right) + 1;
        }

        //2、计算树的高度（后序遍历）
        public int Height(Node root)
        {
            int a, b;
            if (root == null) return 0;
            a = Height(root.Left);
            b = Height(root.Right);
            if (a > b) return a + 1; else return b + 1;
        }
        //3、复制二叉树（后序遍历）
        public Node CopyTree(Node root)
        {
            Node newroot;
            if (root == null)
            {
                newroot = null;
            }
            else
            {
                CopyTree(root.Left);
                CopyTree(root.Right);
                newroot = root;
            }
            return newroot;
        }

        /*4、建立二叉树饿存储结构（建立二叉树的二叉链表）。上面的复制也是种建立方法*/
        //(1)按给定先序序列建立二叉树
        public static BinaryTree CreateByPre(string s)
        {
            BinaryTree tree = new BinaryTree(s);//先以层序序列初始化个树，再调整
            int _count = 0;
            Node node = tree.Head;
            Stack<Node> stack = new Stack<Node>();
            while (node != null || stack.Count > 0)
            {
                while (node != null)
                {
                    node.Data = s[_count++];
                    stack.Push(node);
                    node = node.Left;
                }
                if (stack.Count > 0)//第2步
                {
                    node = stack.Pop();
                    node = node.Right;

                }
            }
            return tree;
        }

        //以中序序列建立二叉树
        public static BinaryTree CreateByIn(string s)
        {
            BinaryTree tree = new BinaryTree(s);//先以层序序列初始化个树，再调整
            int _count = 0;
            Node node = tree.Head;
            Stack<Node> stack = new Stack<Node>();
            while (node != null || stack.Count > 0)
            {
                while (node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }
                if (stack.Count > 0)
                {
                    node = stack.Pop();
                    node.Data = s[_count++];
                    node = node.Right;

                }
            }
            return tree;
        }

        public static BinaryTree CreateByAfter(string s)
        {
            BinaryTree tree = new BinaryTree(s);//先以层序序列初始化个树，再调整
            int _count = 0;
            Node node = tree.Head;
            Node pre = tree.Head; ;
            //pre指针指向“之前出栈节点”，如果为null有问题，这里指向头节点,因为后续遍历中头节点肯定是最后被访问的。
            Stack<Node> stack = new Stack<Node>();
            while (node != null || stack.Count > 0)
            {
                while (node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }
                if (stack.Count > 0)
                {
                    Node temp = stack.Peek().Right;//获取栈顶元素的右孩子，C#的栈因为有了这个方法使得操作简单
                    if (temp == null || temp == pre)//满足规则1
                    {
                        node = stack.Pop();//出栈进行访问
                        node.Data = s[_count++];
                        pre = node;//设置“之前出栈节点”
                        node = null;//防止null再次入栈
                    }
                    else
                    {
                        node = temp;//规则2 继续循环。将栈顶节点的右孩子入栈，重复规则1的操作
                    }
                }
            }
            return tree;
        }
    }
}
