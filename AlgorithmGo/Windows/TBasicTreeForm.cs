using AlgorithmGo.classes.Tree;
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
    enum TraversalType
    {
        PreStackOrder = 0,
        InStackOrdrer = 1,
        AfterStackOrder =2,
        LevelOdrer = 3
    }


    public partial class TBasicTreeForm : Form
    {
        public BinaryTree Tree = new BinaryTree();
        
        public TBasicTreeForm()
        {
            InitializeComponent();

            comboBox1.Items.Add("int");
            comboBox1.SelectedIndex = 0;

            comboBox2.Items.Add(TraversalType.PreStackOrder);
            comboBox2.Items.Add(TraversalType.InStackOrdrer);
            comboBox2.Items.Add(TraversalType.AfterStackOrder);
            comboBox2.Items.Add(TraversalType.LevelOdrer);

            comboBox2.SelectedIndex = 0;

        }

        // 生成树 并先根遍历展示
        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            Random randomizer = new Random();
            for (int i = 1; i<numericUpDown1.Value;i++)
            {
                sb.Append((char)randomizer.Next(65,112));
            }

            TreeTmp tmpTree = new TreeTmp(sb.ToString());
            Tree = tmpTree.Tree;
            Tree.PreStackOrder();
            richTextBox2.Text = Tree.Sb.ToString();
            //tree.PreOrder();
            
        }

        // 遍历
        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                Tree.PreStackOrder();
                richTextBox2.Text = Tree.Sb.ToString();
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                Tree.InStackOrder();
                richTextBox2.Text = Tree.Sb.ToString();
            }
            else if (comboBox2.SelectedIndex == 2)
            {
                Tree.AfterStackOrder();
                richTextBox2.Text = Tree.Sb.ToString();
            }
            else if (comboBox2.SelectedIndex == 3)
            {
                Tree.LevelOrder();
                richTextBox2.Text = Tree.Sb.ToString();
            }
        }
    }

    // 在外面构造一个Tree
    // 其实完全没必要..
    public class TreeTmp
    {
        private BinaryTree tree = new BinaryTree();
        public BinaryTree Tree
        {
            get { return tree; }
            set { tree = value; }
        }

        public TreeTmp(string str)
        {
            BinaryTree tree2 = new BinaryTree(str);
            tree = tree2;
        }
        
    }

}
