using AlgorithmGo.classes.Graph;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgorithmGo.Windows
{
    // 遍历方法
    enum type
    {
        dft = 0,
        bft = 1,
    }

    public partial class GBreadthTraversalForm : Form
    {
        AdjacencyList<string> a = new AdjacencyList<string>();

        // 初始化
        public GBreadthTraversalForm()
        {
            InitializeComponent();

            comboBox1.Items.Add(type.dft);
            comboBox1.Items.Add(type.bft);
            comboBox1.SelectedIndex = 0;

        }
      
        // 清除数据
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "并不支持清空。";
        }

        // 遍历
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    richTextBox1.Text ="深度优先遍历：\n" + (a.DFSTraverse()).ToString();

                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    richTextBox1.Text="广度优先遍历：\n" + (a.BFSTraverse()).ToString(); //广度优先搜索遍历
                }
            }
            catch (Exception f)
            {
                richTextBox1.Text = f.ToString();
            }

        }

        // 插入结点
        private void button4_Click(object sender, EventArgs e)
        {
            a.AddVertex(textBox1.Text);
            richTextBox1.Text = "添加了：" + textBox1.Text + "\n" + a.ToString();
        }

        // 插入无向边
        private void button5_Click(object sender, EventArgs e)
        {
            a.AddEdge("V3", "V4");
            richTextBox1.Text = "添加了无向边：" + "V3 -> V4" + a.ToString();
        }

        // 查找结点
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                textBox4.Text = a.Find(textBox5.Text).ToString();
            }
            catch (Exception f)
            {
                richTextBox1.Text = f.ToString();
            }
        }

        // 生成图
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                a.AddVertex("V1");
                a.AddVertex("V2");
                a.AddVertex("V3");
                a.AddVertex("V4");
                a.AddVertex("V5");
                a.AddVertex("V6");
                a.AddVertex("V7");
                a.AddVertex("V8");
                a.AddEdge("V1", "V2");
                a.AddEdge("V1", "V3");
                a.AddEdge("V2", "V4");
                a.AddEdge("V2", "V5");
                a.AddEdge("V3", "V6");
                a.AddEdge("V3", "V7");
                a.AddEdge("V4", "V8");
                a.AddEdge("V5", "V8");
                a.AddEdge("V6", "V8");
                a.AddEdge("V7", "V8");
                StringBuilder sb = new StringBuilder();
                sb.Append(a.ToString());
                richTextBox1.Text = sb.ToString();
            }
            catch (Exception f)
            {
                richTextBox1.Text ="出错了。请在左侧重新选择本页面。"+ f.ToString();
            }
            
        }
    }
}
