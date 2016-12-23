using AlgorithmGo.classes;
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
    public partial class GDijkstraForm : Form
    {
        DijkstraAlgorithm a = new DijkstraAlgorithm();

        public GDijkstraForm()
        {
            InitializeComponent();
        }

        // 生成
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Text = "邻接矩阵：\n" + (a.displayMetrix()).ToString();
            }
            catch (Exception f)
            {
                richTextBox1.Text = f.ToString();
            }
        }

        // dijkstra
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Text = "Dijkstra遍历结果：\n" + (a.displayResult()).ToString();
            }
            catch (Exception f)
            {
                richTextBox1.Text = f.ToString();
            }
        }
    }
}
