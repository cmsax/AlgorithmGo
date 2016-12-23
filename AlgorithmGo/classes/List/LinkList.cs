using AlgorithmGo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmGo.classes.List
{
    /// <summary>
    /// 单链表
    /// </summary>
    public class LinkList<T> : ISequenceList<T>
    {
        // 字段与属性
        private Node<T> head;
        public Node<T> Head
        {
            get { return head; }
            set { head = value; }
        }

        // 构造器
        public LinkList()
        {
            head = null;
        }



        /*
         * 方法 
         * 
         */

        // 求长度
        public int GetLength()
        {
            Node<T> p = head;
            int len = 0;
            while (p != null)
            {
                ++len;
                p = p.Next;
            }

            return len;
        }

        // 清空
        public void Clear()
        {
            head = null;
        }

        // 是否为空
        public bool IsEmpty()
        {
            return head == null ? true : false;
        }

        // 尾部附加
        public void Append(T item)
        {
            Node<T> q = new Node<T>(item);
            Node<T> p = new Node<T>();

            if(head==null)
            {
                head = q;
                return;
            }

            p = head;
            while (p.Next != null)
            {
                p = p.Next;
            }
            p.Next = q;

        }

        // 插入结点
        public void Insert(T item, int index)
        {
            if (IsEmpty() || index < 1)
            {
                throw new Exception("EmptyListOrNullIndexException");
            }

            if (index == 1)
            {
                Node<T> q = new Node<T>(item);
                q.Next = head;
                head = q;
                return;
            }

            Node<T> p = head;
            Node<T> r = new Node<T>();
            int j = 1;

            while(p.Next != null && j<index)
            {
                r = p;
                p = p.Next;
                ++j;
            }

            if (j == index)
            {
                Node<T> q = new Node<T>(item);
                q.Next = p;
                r.Next = q;
            }

        }

        // 在后方插入结点
        public void InsertPost(Node<T> item, int index)
        {
            //TODO:
        }

        // 删除结点
        public void Delete(int index)
        {
            if (IsEmpty() || index < 0)
            {
                throw new Exception("EmptyListOrNullIndexException");
            }

            Node<T> q = new Node<T>();

            if(index == 1)
            {
                q = head;
                head = head.Next;
                
            }

            Node<T> p = head;
            int j = 1;
            while(p.Next != null && j < index)
            {
                ++j;
                q = p;
                p = p.Next;
            }

            if (j == index)
            {
                q.Next = p.Next;
            }
            else
            {
                throw new Exception("NullNodeException");
            }

        }

        // 获取结点值
        public T GetElememt(int index)
        {
            if (IsEmpty() || index < 0)
            {
                throw new Exception("EmptyListOrNullIndexException");
            }

            Node<T> p = new Node<T>();
            p = head;
            int j = 1;

            while (p.Next != null && j < index)
            {
                ++j;
                p = p.Next;
            }

            if(j == index)
            {
                return p.Data;
            }
            else
            {
                throw new Exception("NullNodeException");
            }

        }

        // 索引
        public int Locate(T value)
        {
            if (IsEmpty())
            {
                throw new Exception("EmptyListOrNullIndexException");
            }

            Node<T> p = new Node<T>();
            p = head;
            int i = 1;
            while (!p.Data.Equals(value) && p.Next != null)
            {
                p = p.Next;
                ++i;
            }

            if (p.Data.Equals(value))
                return i;
            else
                return -1;

        }

        // 倒置
        public void Reverse()
        {
            //TODO:
        }

        // 合并
        public void Merge()
        {
            //TODO:
        }

        // 去重合并
        public void Purge()
        {
            //TODO:
        }

        // 去重
        public void Duplicate()
        {
            //TODO:
        }

    }

    // 结点类
    public class Node<T>
    {
        private T data;             // 数据域
        private Node<T> next;       // 地址域

        // 构造器
        public Node(T val, Node<T> p)
        {
            data = val;
            next = p;
        }

        public Node(Node<T> p)
        {
            next = p;
        }

        public Node(T val)
        {
            data = val;
            next = null;
        }

        public Node()
        {
            data = default(T);
            next = null;
        }

        // 属性
        public T Data               // 数据域
        {
            get { return data; }
            set { data = value; }
        }

        public Node<T> Next         // 地址域
        {
            get { return next; }
            set { next = value; }
        }
    }

}
