using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static BlackNRed.TreeClasses.BRTree;

namespace BlackNRed.TreeClasses
{
	public class DrawBRTree
	{
		BRTree tree;
		public Bitmap Bitmap { get; private set; }
		Graphics graphic;

		private Pen red;
		private Pen black;
		private Pen gray;

		Brush redFill;
		Brush blackFill;
		Brush whiteFill;
		Font font;

		int R;

		public DrawBRTree(BRTree tree, int width, int height, int r = 12)
		{
			this.tree = tree;

			Bitmap = new Bitmap(width, height);
			graphic = Graphics.FromImage(Bitmap);

			red = new Pen(Color.DarkRed);
			red.Width = 2;

			black = new Pen(Color.Black);
			black.Width = 2;

			gray = new Pen(Color.Gray);
			gray.Width = 2;

			redFill = Brushes.DarkRed;
			blackFill = Brushes.Black;
			whiteFill = Brushes.WhiteSmoke;

			R = r;
			font = new Font("Times New Roman", R);
		}

		void DrawVertex(Node node, int x, int y)
		{
			var point = new PointF(x - R, y - R);

			if (node != null)
			{
				if (node.color == COLOR.BLACK)
				{
					graphic.FillEllipse(blackFill, x - R, y - R, 2 * R, 2 * R);
					graphic.DrawEllipse(black, x - R, y - R, 2 * R, 2 * R);
				}
				else if (node.color == COLOR.RED)
				{
					graphic.FillEllipse(redFill, x - R, y - R, 2 * R, 2 * R);
					graphic.DrawEllipse(red, x - R, y - R, 2 * R, 2 * R);
				}

				graphic.DrawString(node.val.ToString(), font, whiteFill, point);
			}
			else
			{
				graphic.FillEllipse(blackFill, x - R, y - R, 2 * R, 2 * R);
				graphic.DrawEllipse(black, x - R, y - R, 2 * R, 2 * R);

				graphic.DrawString("NULL", font, whiteFill, point);
			}
		}

		void DrawEdge (int x1, int y1, int x2, int y2)
		{
			PointF p1 = new PointF(x1, y1);
			PointF p2 = new PointF(x2, y2);

			graphic.DrawLine(gray, p1, p2);
		}

		public void Draw(Node node, int x, int y, bool isroot = false)
		{
			if (node != null)
			{
				int xUp = R;
				int yUp = 3 * R;

				if (isroot)
				{
					xUp = 6 * R;
				}
				else
				{
					xUp = 3 * R;
				}
				if (node.left != null)
				{
					DrawEdge(x, y, x - xUp, y + yUp);

					DrawVertex(node, x, y);

					Draw(node.left, x - xUp, y + yUp);
				}
				else
				{
					DrawVertex(node, x, y);
				}

				if (node.right != null)
				{
					DrawEdge(x, y, x + xUp, y + yUp);
					DrawVertex(node, x, y);

					Draw(node.right, x + xUp, y + yUp);
				}
				else
				{
					DrawVertex(node, x, y);
				}
			}
			else
			{
				DrawVertex(node, x, y);
			}
		}
	}
}
