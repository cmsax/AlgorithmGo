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
    public partial class GAdjacencyMetrixForm : Form
    {
        public GAdjacencyMetrixForm()
        {
            InitializeComponent();
        }

        // 随机生成邻接矩阵
        private void button1_Click(object sender, EventArgs e)
        {
            int[,] Metrix = new int[7, 7]
            {
                {0,9,3,7,2048,2048,2048},
                {9,0,5,2048,2048,12,2048 },
                {3,5,0,8,19,4,2048},
                {7,2048,8,0,20,2048,2048 },
                {2048,2048,19,20,0,6,7 },
                {2048,12,4,2048,6,0,4 },
                {2048,2048,2048,2048,7,4,0 }
            };
            StringBuilder sb = new StringBuilder();
            sb.Append("{ \n");
            for (int i = 0; i<7;i++)
            {
                sb.Append("\t{");
                for (int j = 0;j<7;j++)
                {
                    sb.Append(Metrix[i,j]+",");
                }
                sb.Append("},\n");
            }
            sb.Append("\n }");
            richTextBox1.Text = sb.ToString();
        }

        // 清除邻接矩阵
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "Null";
        }
    }
}
