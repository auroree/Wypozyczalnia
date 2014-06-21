using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Wypozyczalnia.View
{
    public partial class HelpView : Form
    {
        TreeNode treeNode;
        public HelpView()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            richTextBox1.Text = node.Name;
        }

        private void HelpLoad(object sender, EventArgs e)
        {
            String line;
            TreeNode subNode = new TreeNode();

            System.IO.StreamReader file = new System.IO.StreamReader("help.txt");
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("!m ")) {
                    line = line.Substring(3);
                    treeNode = new TreeNode(line);
                    treeView1.Nodes.Add(treeNode);
                    Console.WriteLine(line);
                }

                else if (line.StartsWith("!s ")) {
                    line = line.Substring(3);
                    subNode = new TreeNode(line);
                    treeNode.Nodes.Add(subNode);
                    Console.WriteLine(line);
                }

                else if (line.StartsWith("!t "))
                {
                    line = line.Substring(3);
                    subNode.Name += line + '\n';
                }

                else if (line.StartsWith("!mt "))
                {
                    line = line.Substring(4);
                    treeNode.Name += line + '\n';
                }
            }
            file.Close();
        }
    }
}
