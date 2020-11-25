using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackNRed.TreeClasses
{
    public partial class BRTree
    {

        public class Node
        {
            public int val;
            public COLOR color;
            public Node left, right, parent;
            public bool isFinded { get; set; }
            
            public int X { get; set; }
            public int Y { get; set; }

            public Node(int val)
            {
                this.val = val;
                parent = left = right = null;
                color = COLOR.RED;
            }

            // returns pointer to uncle 
            public Node uncle()
            {
                // If no parent or grandparent, then no uncle 
                if (parent == null || parent.parent == null)
                    return null;

                if (parent.isOnLeft())
                    // uncle on right 
                    return parent.parent.right;
                else
                    // uncle on left 
                    return parent.parent.left;
            }

            // check if node is left child of parent 
            public bool isOnLeft() { return this == parent.left; }

            // returns pointer to sibling 
            public Node sibling()
            {
                // sibling null if no parent 
                if (parent == null)
                    return null;

                if (isOnLeft())
                    return parent.right;

                return parent.left;
            }

            // moves node down and moves given node in its place 
            public void moveDown(Node nParent)
            {
                if (parent != null)
                {
                    if (isOnLeft())
                    {
                        parent.left = nParent;
                    }
                    else
                    {
                        parent.right = nParent;
                    }
                }
                nParent.parent = parent;
                parent = nParent;
            }

            public bool hasRedChild()
            {
                return (left != null && left.color == COLOR.RED) ||
                       (right != null && right.color == COLOR.RED);
            }
        }
    }
}

