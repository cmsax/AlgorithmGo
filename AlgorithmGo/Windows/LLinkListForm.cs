using AlgorithmGo.classes.List;
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
   
    public partial class LLinkListForm : Form
    {

        LinkList<int> list = new LinkList<int>();
        StringBuilder sb = new StringBuilder();

        public LLinkListForm()
        {
            InitializeComponent();

            comboBox1.Items.Add("int");
            comboBox1.SelectedIndex = 0;
            
        }

        // 生成链表
        private void button1_Click(object sender, EventArgs e)
        {
            sb.Clear();
            list.Clear();

            Random randomizer = new Random();
            for(int i = 0; i<numericUpDown1.Value; i++)
            {
                list.Append(randomizer.Next(100000));
            }

            for (int i = 1; i<=list.GetLength();i++)
            {
                sb.Append(list.GetElememt(i)+" -> ");
            }

            richTextBox2.Text = sb.ToString();
        }

        // 查找
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = list.Locate(int.Parse(textBox1.Text)).ToString();
            }
            catch(Exception f)
            {
                richTextBox2.Text ="查询值无效 或 未生成链表\n\n" + f.ToString();
            }
        }

        // 插入
        private void button3_Click(object sender, EventArgs e)
        {
            sb.Clear();
            try
            {
                list.Insert(int.Parse(textBox3.Text), int.Parse(textBox4.Text));
                sb.Append("在位置：" + textBox4.Text + "，插入了值：" + textBox3.Text + "\n");
                for (int i = 1; i <= list.GetLength(); i++)
                {
                    sb.Append(list.GetElememt(i) + " -> ");
                }
                richTextBox2.Text = sb.ToString();
            }
            catch(Exception f)
            {
                richTextBox2.Text = "插入无效 或 未生成链表\n\n" + f.ToString();
            }
            
        }

        // 添加
        private void button4_Click(object sender, EventArgs e)
        {
            sb.Clear();
            try
            {
                list.Append(int.Parse(textBox5.Text));
                sb.Append("在末尾添加了：" + textBox5.Text + "\n");
                for (int i = 1; i <= list.GetLength(); i++)
                {
                    sb.Append(list.GetElememt(i) + " -> ");
                }
                richTextBox2.Text = sb.ToString();
            }
            catch (Exception f)
            {
                richTextBox2.Text = "添加值无效 或 未生成链表\n\n" + f.ToString();
            }
            
        }

        // 删除
        private void button5_Click(object sender, EventArgs e)
        {
            sb.Clear();
            try
            {
                list.Delete(int.Parse(textBox6.Text));
                sb.Append("删除了位于：" + textBox6.Text + "的值\n");
                for (int i = 1; i <= list.GetLength(); i++)
                {
                    sb.Append(list.GetElememt(i) + " -> ");
                }
                richTextBox2.Text = sb.ToString();
            }
            catch (Exception f)
            {
                richTextBox2.Text ="位置无效 或 未生成链表"+ f.ToString();
            }

        }

        // 清空数据
        private void button6_Click(object sender, EventArgs e)
        {
            sb.Clear();
            try
            {
                list.Clear();
                sb.Append("链表已清空，请尝试链表其它操作，或者重新生成链表。");
                richTextBox2.Text = sb.ToString();
            }
            catch (Exception f)
            {
                richTextBox2.Text = f.ToString();
            }
           
        }
    }
}
