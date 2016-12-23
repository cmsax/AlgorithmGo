using AlgorithmGo.Windows;
using System;
using System.Windows.Forms;

namespace AlgorithmGo
{
    /*
     * Author: 蔡明师（Cai MS）
     * Date: 2016/12/20
     * Github: github.com/cmsax/AlgorithmGo
     * 
     * The MIT License (MIT)
     * Copyright © 2016 <CaiMingshi github:github.com/cmsax>
     *
     * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), 
     * to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
     * *and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
     * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
     * THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER *LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
     * 
     * 
     */



    public partial class MainForm : Form
    {
       
        public MainForm()
        {
            InitializeComponent();

            #region TreeView Initializing 初始化树形图

            treeView1.Nodes.Add("List","线性表");
            treeView1.Nodes[0].Nodes.Add("SequenceList","顺序表");
            treeView1.Nodes[0].Nodes.Add("LinkList", "单链表");
            //treeView1.Nodes[0].Nodes.Add("DoubleList", "双向链表");

            treeView1.Nodes.Add("Tree","树和二叉树");
            treeView1.Nodes[1].Nodes.Add("Traversal", "遍历");
            //treeView1.Nodes[1].Nodes.Add("Forest", "森林");

            treeView1.Nodes.Add("Graph","图");
            treeView1.Nodes[2].Nodes.Add("Metrix", "邻接矩阵");
            treeView1.Nodes[2].Nodes.Add("DFT", "深度优先遍历");
            treeView1.Nodes[2].Nodes.Add("BFT", "广度优先遍历");
            treeView1.Nodes[2].Nodes.Add("Dijkstra", "dijkstra算法");
            treeView1.Nodes[2].Nodes.Add("Floyd", "floyd算法");

            treeView1.Nodes.Add("Sort","排序");
            treeView1.Nodes[3].Nodes.Add("InsertionSort", "简单插入排序");
            treeView1.Nodes[3].Nodes.Add("BubbleSort", "冒泡排序");
            treeView1.Nodes[3].Nodes.Add("HeapSort", "堆排序");
            treeView1.Nodes[3].Nodes.Add("MergeSort", "归并排序");
            treeView1.Nodes[3].Nodes.Add("QuickSort","快速排序");

            treeView1.Nodes.Add("Search","查找");
            treeView1.Nodes[4].Nodes.Add("SequentialSearch", "静态 顺序查找");
            treeView1.Nodes[4].Nodes.Add("BinarySearch", "静态 有序表的折半查找");
            treeView1.Nodes[4].Nodes.Add("IndexSearch", "静态 索引查找");
            treeView1.Nodes[4].Nodes.Add("DynamicTable", "动态查找表");
            treeView1.Nodes[4].Nodes.Add("HashTable", "哈希表");

            treeView1.Nodes.Add("About","关于");

            treeView1.Nodes.Add("Help", "帮助");


            treeView1.ExpandAll();
            #endregion

            
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            initializeWindows init = new initializeWindows();
            MainPanel.Controls.Clear();
            string selectedItem = treeView1.SelectedNode.Name;
            
            #region Switch方式实现显示每个树节点对应的窗口
            switch (selectedItem)
            {

                //case "About": init.abf.MdiParent = this; init.abf.Show(); break;
                case "About":
                    {
                        init.abf.TopLevel = false;
                        init.abf.FormBorderStyle = FormBorderStyle.None;
                        MainPanel.Controls.Add(init.abf);
                        groupBox1.Text = "关于";
                        init.abf.Show();
                        break;
                    }
                case "Help":
                    {
                        init.hlpf.TopLevel = false;
                        init.hlpf.FormBorderStyle = FormBorderStyle.None;
                        MainPanel.Controls.Add(init.hlpf);
                        groupBox1.Text = "帮助";
                        init.hlpf.Show();
                        break;
                    }
                case "SequenceList":
                    {
                        init.sf.TopLevel = false;
                        init.sf.FormBorderStyle = FormBorderStyle.None;
                        MainPanel.Controls.Add(init.sf);
                        groupBox1.Text = "顺序表";
                        init.sf.Show();
                        break;
                    }
                case "LinkList":
                    {
                        init.llf.TopLevel = false;
                        init.llf.FormBorderStyle = FormBorderStyle.None;
                        MainPanel.Controls.Add(init.llf);
                        groupBox1.Text = "链表";
                        init.llf.Show();
                        break;
                    }
                //TODO:
                case "DoubleList":
                    {
                        init.abf.TopLevel = false;
                        init.abf.FormBorderStyle = FormBorderStyle.None;
                        MainPanel.Controls.Add(init.abf);
                        groupBox1.Text = "双向链表";
                        init.abf.Show();
                        break;
                    }
                case "Traversal":
                    {
                        init.btf2.TopLevel = false;
                        init.btf2.FormBorderStyle = FormBorderStyle.None;
                        MainPanel.Controls.Add(init.btf2);
                        groupBox1.Text = "遍历";
                        init.btf2.Show();
                        break;
                    }
                //TODO:
                case "Forest":
                    {
                        init.abf.TopLevel = false;
                        init.abf.FormBorderStyle = FormBorderStyle.None;
                        MainPanel.Controls.Add(init.abf);
                        groupBox1.Text = "森林";
                        init.abf.Show();
                        break;
                    }
                case "Metrix":
                    {
                        init.amf.TopLevel = false;
                        init.amf.FormBorderStyle = FormBorderStyle.None;
                        MainPanel.Controls.Add(init.amf);
                        groupBox1.Text = "邻接矩阵";
                        init.amf.Show();
                        break;
                    }
                case "DFT":
                    {
                        init.btf.TopLevel = false;
                        init.btf.FormBorderStyle = FormBorderStyle.None;
                        MainPanel.Controls.Add(init.btf);
                        groupBox1.Text = "深度优先遍历";
                        init.btf.Show();
                        break;
                    }
                case "BFT":
                    {
                        init.btf.TopLevel = false;
                        init.btf.FormBorderStyle = FormBorderStyle.None;
                        MainPanel.Controls.Add(init.btf);
                        groupBox1.Text = "广度优先遍历";
                        init.btf.Show();
                        break;
                    }
                case "Dijkstra":
                    {
                        init.dj.TopLevel = false;
                        init.dj.FormBorderStyle = FormBorderStyle.None;
                        MainPanel.Controls.Add(init.dj);
                        groupBox1.Text = "Dijkstra算法";
                        init.dj.Show();
                        break;
                    }
                case "Floyd":
                    {
                        init.ff.TopLevel = false;
                        init.ff.FormBorderStyle = FormBorderStyle.None;
                        MainPanel.Controls.Add(init.ff);
                        groupBox1.Text = "Floyd算法";
                        init.ff.Show();
                        break;
                    }
                case "InsertionSort":
                    {
                        init.sf.TopLevel = false;
                        init.sf.FormBorderStyle = FormBorderStyle.None;
                        MainPanel.Controls.Add(init.sf);
                        groupBox1.Text = "简单插入排序";
                        init.sf.Show();
                        break;
                    }
                case "BubbleSort":
                    {
                        init.sf.TopLevel = false;
                        init.sf.FormBorderStyle = FormBorderStyle.None;
                        MainPanel.Controls.Add(init.sf);
                        groupBox1.Text = "冒泡排序";
                        init.sf.Show();
                        break;
                    }
                case "HeapSort":
                    {
                        init.sf.TopLevel = false;
                        init.sf.FormBorderStyle = FormBorderStyle.None;
                        MainPanel.Controls.Add(init.sf);
                        groupBox1.Text = "堆排序";
                        init.sf.Show();
                        break;
                    }
                case "MergeSort":
                    {
                        init.sf.TopLevel = false;
                        init.sf.FormBorderStyle = FormBorderStyle.None;
                        MainPanel.Controls.Add(init.sf);
                        groupBox1.Text = "归并排序";
                        init.sf.Show();
                        break;
                    }
                case "QuickSort":
                    {
                        init.sf.TopLevel = false;
                        init.sf.FormBorderStyle = FormBorderStyle.None;
                        MainPanel.Controls.Add(init.sf);
                        groupBox1.Text = "快速排序";
                        init.sf.Show();
                        break;
                    }
                case "SequentialSearch":
                    {
                        init.sf.TopLevel = false;
                        init.sf.FormBorderStyle = FormBorderStyle.None;
                        MainPanel.Controls.Add(init.sf);
                        groupBox1.Text = "顺序搜索";
                        init.sf.Show();
                        break;
                    }
                case "BinarySearch":
                    {
                        init.sf.TopLevel = false;
                        init.sf.FormBorderStyle = FormBorderStyle.None;
                        MainPanel.Controls.Add(init.sf);
                        init.sf.Show();
                        break;
                    }
                case "IndexSearch":
                    {
                        init.sf.TopLevel = false;
                        init.sf.FormBorderStyle = FormBorderStyle.None;
                        MainPanel.Controls.Add(init.sf);
                        groupBox1.Text = "索引表搜索";
                        init.sf.Show();
                        break;
                    }
                case "DynamicTable":
                    {
                        init.sf.TopLevel = false;
                        init.sf.FormBorderStyle = FormBorderStyle.None;
                        MainPanel.Controls.Add(init.sf);
                        groupBox1.Text = "动态数据表搜索";
                        init.sf.Show();
                        break;
                    }
                case "HashTable":
                    {
                        init.sf.TopLevel = false;
                        init.sf.FormBorderStyle = FormBorderStyle.None;
                        MainPanel.Controls.Add(init.sf);
                        groupBox1.Text = "哈希表";
                        init.sf.Show();
                        break;
                    }
               
            }
            #endregion
        }
    }

    /// <summary>
    /// 用于初始化的类
    /// </summary>
    public class initializeWindows
    {
        #region Windows Initializing

        public _AboutForm abf = new _AboutForm();
        public _HelpForm hlpf = new _HelpForm();
        public FBinarySearchForm bsf = new FBinarySearchForm();
        public FDynamicSearchTableForm dstf = new FDynamicSearchTableForm();
        public FHashTableForm htf = new FHashTableForm();
        public FIndexSearchForm isf = new FIndexSearchForm();
        public FSequentialSearchForm ssf = new FSequentialSearchForm();
        public GAdjacencyMetrixForm amf = new GAdjacencyMetrixForm();
        public GBreadthTraversalForm btf = new GBreadthTraversalForm();
        public GDepthTraversalForm dtf = new GDepthTraversalForm();
        public GDijkstraForm dj = new GDijkstraForm();
        public GFloydForm ff = new GFloydForm();
        public LLinkListForm llf = new LLinkListForm();
        public LSequenceForm sf = new LSequenceForm();
        public SBubbleSortForm bsf2 = new SBubbleSortForm();
        public SHeapSortForm hsf = new SHeapSortForm();
        public SInsertionSortForm isf2 = new SInsertionSortForm();
        public SMergeSortForm msf = new SMergeSortForm();
        public SQuickSortForm qsf = new SQuickSortForm();
        public TBasicTreeForm btf2 = new TBasicTreeForm();
        public TBinaryTreeForm btf3 = new TBinaryTreeForm();
        public TTreeTraversalForm ttf = new TTreeTraversalForm();

        #endregion

    }
    
}
