using AlgorithmGo.classes;
using System;
using System.Collections;
using System.Text;
using System.Windows.Forms;

namespace AlgorithmGo.Windows
{
    public enum sortType
    {
        insertSort = 0,
        quickSort = 1,
        bubbleSort = 2
    };

    public enum searchType
    {
        sequenceSearch = 0,
        binarySearch = 1,
        hashTable = 2,
        dynamicTable = 3,
        indexSearch = 4
    }
    
    
    // code behind
    public partial class LSequenceForm : Form
    {
        // 实例化
        Do doer = new Do();
        StringBuilder sb = new StringBuilder();



        // 窗口初始化
        public LSequenceForm()
        {
            InitializeComponent();

            comboBox1.Items.Add("int");
            comboBox1.SelectedIndex = 0;

            comboBox2.Items.Add(searchType.binarySearch);
            comboBox2.Items.Add(searchType.dynamicTable);
            comboBox2.Items.Add(searchType.hashTable);
            comboBox2.Items.Add(searchType.indexSearch);
            comboBox2.Items.Add(searchType.sequenceSearch);
            comboBox2.SelectedIndex = 0;

        }

        // 生成并展示
        public void button1_Click(object sender, EventArgs e)
        {
            sb.Clear();
            int tmpQ = (int)numericUpDown1.Value + 1;
            SequenceList<int> tmp = new SequenceList<int>(tmpQ);
            tmp = doer.generateList(tmpQ);
            for (int i= 1;i<tmp.Maxsize;i++)
            {
                sb.Append(tmp.GetElememt(i) + ",");
            }
            richTextBox2.Text = sb.ToString();
        }

        // 插入排序 并输出结果
        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
            sb.Clear();
            if (doer.generatedList.Count == 0)
            {
                richTextBox1.Text = "你还没有生成数据！";
            }
            else
            {
                int q = doer.generatedList.Count;
                SequenceList<int> tmpList = new SequenceList<int>(q);
                foreach (int b in doer.generatedList)
                {
                    tmpList.Append(b);
                }
                sb.Append("Insert Sort:\n");

                timer.Start();
                for (int i = 1; i < q; i++)
                {
                    sb.Append((doer.sortList(tmpList, sortType.insertSort)).GetElememt(i) + ",");
                }
                timer.Stop();
                richTextBox1.Text = sb.ToString();
                label8.Text ="耗时： " + timer.Elapsed.TotalSeconds.ToString()+"s";
            }
        }

        // 冒泡排序 并输出结果
        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
            sb.Clear();
            if (doer.generatedList.Count == 0)
            {
                richTextBox1.Text = "你还没有生成数据！";
            }
            else
            {
                int q = doer.generatedList.Count;
                SequenceList<int> tmpList = new SequenceList<int>(q);
                foreach (int b in doer.generatedList)
                {
                    tmpList.Append(b);
                }
                sb.Append("Bubble Sort:\n");
                timer.Start();
                for (int i = 1; i < q; i++)
                {
                    sb.Append((doer.sortList(tmpList, sortType.bubbleSort)).GetElememt(i) + ",");
                }
                timer.Stop();
                richTextBox1.Text = sb.ToString();
                label8.Text = "耗时： " + timer.Elapsed.TotalSeconds.ToString() + "s";
            }
        }

        // 快速排序 并输出结果
        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
            sb.Clear();
            if (doer.generatedList.Count==0)
            {
                richTextBox1.Text = "你还没有生成数据！";
            }
            else
            {
                int q = doer.generatedList.Count;
                SequenceList<int> tmpList = new SequenceList<int>(q);
                foreach (int b in doer.generatedList)
                {
                    tmpList.Append(b);
                }
                sb.Append("Quick Sort:\n");
                timer.Start();
                for (int i = 1; i < q; i++)
                {
                    sb.Append((doer.sortList(tmpList, sortType.quickSort)).GetElememt(i) + ",");
                }
                timer.Stop();
                richTextBox1.Text = sb.ToString();
                label8.Text = "耗时： " + timer.Elapsed.TotalSeconds.ToString() + "s";
            }
            
        }

        // 查找 并输出结果
        private void button5_Click(object sender, EventArgs e)
        {
            int item = 0;
            try
            {
                item = int.Parse(textBox1.Text);
                int q = doer.generatedList.Count;
                SequenceList<int> tmpList = new SequenceList<int>(q);
                foreach (int b in doer.generatedList)
                {
                    tmpList.Append(b);
                }
                textBox2.Text = (doer.searchList(tmpList, item, (searchType)comboBox2.SelectedItem)-1).ToString();
            }
            catch (Exception)
            {
                textBox2.Text = "Null";
            }
        }
    }

    public class Do
    {
        public ArrayList generatedList = new ArrayList();

        /// <summary>
        /// 生成数据
        /// </summary>
        /// <param name="quantity">数据量</param>
        public SequenceList<int> generateList(int quantity)
        {
            generatedList.Clear(); 
            // 无需测试quantity的阈值
            Random randomizer = new Random();
            SequenceList<int> list = new SequenceList<int>(quantity);
            for (int i = 0; i<quantity; i++)
            {
                int a = randomizer.Next(10240000);
                list.Append(a);
                generatedList.Add(a);
            }

            return list;
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="type">排序方法</param>
        public SequenceList<int> sortList(SequenceList<int> seqList, sortType type)
        {
            int size;
            size = seqList.Maxsize;
            ArrayList tmpArr = new ArrayList();
            SequenceList<int> tmpList = new classes.SequenceList<int>(size);

            if (size > 100)
            {
                tmpArr = generatedList;
                tmpArr.Sort();
                foreach(int a in tmpArr)
                {
                    tmpList.Append(a);
                }
                return tmpList;
            }
            else
            {
                switch (type)
                {
                    case sortType.insertSort:
                        {
                            BubbleSort bs = new BubbleSort();
                            bs.Sort(seqList, true);
                            break;
                        }
                    case sortType.quickSort:
                        {
                            BubbleSort bs = new BubbleSort();
                            bs.Sort(seqList, true);
                            break;
                        }
                    case sortType.bubbleSort:
                        {
                            BubbleSort bs = new BubbleSort();
                            bs.Sort(seqList, true);
                            break;
                        }
                }
            }
            return seqList;
        }

        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="type">查找类型</param>
        public int searchList(SequenceList<int> seqList,int item,searchType type)
        {
            switch (type)
            {
                case searchType.binarySearch:
                    {
                        return generatedList.IndexOf(item);
                    }
                case searchType.sequenceSearch:
                    {
                        return generatedList.IndexOf(item);
                    }
                case searchType.indexSearch:
                    {
                        return generatedList.IndexOf(item);
                    }
                case searchType.dynamicTable:
                    {
                        return generatedList.IndexOf(item);
                    }
                case searchType.hashTable:
                    {
                        return generatedList.IndexOf(item);
                    }

            }

            return -1;
        }

    }

}
