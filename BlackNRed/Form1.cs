using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BlackNRed.TreeClasses;

namespace BlackNRed
{
	public partial class Form1 : Form
	{
		int pictureHeight;
		int pictureWidth;
		int r = 12;

		public Form1()
		{
			InitializeComponent();

			pictureHeight = pictureBox.Height;
			pictureWidth = pictureBox.Width; 

			BRTree tree = new BRTree();
			DrawBRTree drawing = new DrawBRTree(tree, pictureWidth, pictureHeight);

			tree.Insert(13);
			tree.Insert(8);
			tree.Insert(1);
			tree.Insert(11);
			tree.Insert(6);
			tree.Insert(17);
			tree.Insert(15);
			tree.Insert(25);
			tree.Insert(22);
			tree.Insert(27);

			drawing.Draw(tree.root, pictureWidth / 2, r, true);
			pictureBox.Image = drawing.Bitmap;
		}

		private void button_Insert_Click(object sender, EventArgs e)
		{

		}

		private void button_Delete_Click(object sender, EventArgs e)
		{

		}

		private void button_Find_Click(object sender, EventArgs e)
		{

		}

		private void textBox_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
