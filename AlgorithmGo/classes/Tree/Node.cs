using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmGo.classes.Tree
{
    public class Node
    {
        // 属性
        private object _data;
        private Node _left;
        private Node _right;

        // 字段
        public object Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public Node Left
        {
            get { return _left; }
            set { _left = value; }
        }

        public Node Right
        {
            get { return _right; }
            set { _right = value; }
        }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="data"></param>
        public Node(object data)
        {
            _data = data;
        }

        // 重写ToString()
        public override string ToString()
        {
            return _data.ToString();
        }


    }
}
