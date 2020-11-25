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
		int r = 20;

		BRTree tree;
		DrawBRTree drawing;

		public Form1()
		{
			InitializeComponent();

			pictureHeight = pictureBox.Height;
			pictureWidth = pictureBox.Width; 

			tree = new BRTree();
			drawing = new DrawBRTree(tree, pictureWidth, pictureHeight);

			drawing.Clear();
			drawing.Draw(tree.root, pictureWidth / 2, r, true);
			pictureBox.Image = drawing.Bitmap;
		}

		private void button_Insert_Click(object sender, EventArgs e)
		{
			if (button_Delete.Enabled == false)
			{
				button_Delete.Enabled = true;
			}
			if (button_Find.Enabled == false)
			{
				button_Find.Enabled = true;
			}

			button_Insert.Enabled = false;

			textBox.Visible = true;
		}

		private void button_Delete_Click(object sender, EventArgs e)
		{
			if (button_Insert.Enabled == false)
			{
				button_Insert.Enabled = true;
			}
			if (button_Find.Enabled == false)
			{
				button_Find.Enabled = true;
			}

			button_Delete.Enabled = false;

			textBox.Visible = true;
		}

		private void button_Find_Click(object sender, EventArgs e)
		{
			if (button_Delete.Enabled == false)
			{
				button_Delete.Enabled = true;
			}
			if (button_Insert.Enabled == false)
			{
				button_Insert.Enabled = true;
			}

			button_Find.Enabled = false;

			textBox.Visible = true;
		}

		private void textBox_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox_KeyUp(object sender, KeyEventArgs e)
		{
			int weight = 0;

			if (e.KeyCode == Keys.Enter)
			{

				if (Int32.TryParse(textBox.Text, out weight)) // если введенный текст является числом
				{
					if (button_Delete.Enabled == false)
					{
						tree.DeleteSearchMarks(tree.root);
						tree.Erase(weight);

						drawing.Clear();
						drawing.Draw(tree.root, pictureWidth / 2, r, true);
						pictureBox.Image = drawing.Bitmap;

						button_Delete.Enabled = true;
					}
					if (button_Find.Enabled == false)
					{
						tree.DeleteSearchMarks(tree.root);
						tree.Find(weight);

						drawing.Clear();
						drawing.Draw(tree.root, pictureWidth / 2, r, true);
						pictureBox.Image = drawing.Bitmap;

						button_Find.Enabled = true;
					}
					if (button_Insert.Enabled == false)
					{
						tree.DeleteSearchMarks(tree.root);
						tree.Insert(weight);

						drawing.Clear();
						drawing.Draw(tree.root, pictureWidth / 2, r, true);
						pictureBox.Image = drawing.Bitmap;

						button_Insert.Enabled = true;
					}

					textBox.Visible = false;
					textBox.Text = "введите число";
				}
			}
		}

		private void textBox_MouseDown(object sender, MouseEventArgs e)
		{
			textBox.Text = "";
		}
	}
}
