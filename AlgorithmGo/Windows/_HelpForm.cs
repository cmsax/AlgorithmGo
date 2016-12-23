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
    public partial class _HelpForm : Form
    {
        public _HelpForm()
        {
            InitializeComponent();

            #region Initializing RichTextBox 初始化文本框内容
            richTextBox1.Text = "这个程序是我的《数据结构》的课程作业，用以展示各个基础的数据结构与算法的操作与内容。";
            richTextBox2.Text = "点击左侧的树状图对应的结点，查看相应的数据结构与算法的数据操作内容。";
            #endregion

        }

        // 超链接事件
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/cmsax/AlgorithmGo");
        }
    }
}
