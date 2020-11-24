using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackNRed.TreeClasses
{
    public partial class BRTree
    {

        public Node root { get; private set; }

        public BRTree() { root = null; }

        Node getRoot() { return root; }


        public void Insert(int n)
        {
            Node newNode = new Node(n);
            if (root == null)
            {
                newNode.color = COLOR.BLACK;

                root = newNode;
            }
            else
            {
                Node temp = search(n);

                if (temp.val == n)
                {
                    return;
                }
                newNode.parent = temp;

                if (n < temp.val)
                {
                    temp.left = newNode;
                }
                else
                    temp.right = newNode;
                fixRedRed(newNode);
            }
        }

        public bool Find(int value)
        {
            Node tmp = null;
            tmp = search(value);
            if (tmp.val != value) return false;
            else
                return true;
        }
        public void Erase(int n)
        {
            if (root == null)
                return;

            Node v = search(n), u;

            if (v.val != n)
            {
                return;
            }

            deleteNode(v);
        }

        public void Show() => print(this.root);
        void print(Node t, int u = 0)
        {
            if (t == null)
            {
                Console.WriteLine("\n");
                for (int i = 0; i < u + (4 * u); ++i)
                    Console.Write(" ");
                Console.WriteLine("null(BLACK)");
                return;
            }
            {
                print(t.right, ++u);
                Console.WriteLine();
                for (int i = 0; i < u + (3 * u); ++i)
                    Console.Write(" ");
                if (t != null)
                    Console.WriteLine(t.val + "(" + t.color + ")");
                else
                {

                    Console.WriteLine("null(BLACK)");

                }
                u--;
                print(t.left, ++u);
            }
        }

        Node search(int n)
        {
            Node temp = root;
            while (temp != null)
            {
                if (n < temp.val)
                {
                    if (temp.left == null)
                        break;
                    else
                        temp = temp.left;
                }
                else if (n == temp.val)
                {
                    break;
                }
                else
                {
                    if (temp.right == null)
                        break;
                    else
                        temp = temp.right;
                }
            }

            return temp;
        }

        void leftRotate(Node x)
        {
            // new parent will be node's right child 
            Node nParent = x.right;

            // update root if current node is root 
            if (x == root)
                root = nParent;

            x.moveDown(nParent);

            // connect x with new parent's left element 
            x.right = nParent.left;
            // connect new parent's left element with node 
            // if it is not null 
            if (nParent.left != null)
                nParent.left.parent = x;

            // connect new parent with x 
            nParent.left = x;
        }

        void rightRotate(Node x)
        {
            // new parent will be node's left child 
            Node nParent = x.left;

            // update root if current node is root 
            if (x == root)
                root = nParent;

            x.moveDown(nParent);

            // connect x with new parent's right element 
            x.left = nParent.right;
            // connect new parent's right element with node 
            // if it is not null 
            if (nParent.right != null)
                nParent.right.parent = x;

            // connect new parent with x 
            nParent.right = x;
        }

        void swapColors(Node x1, Node x2)
        {
            COLOR temp;
            temp = x1.color;
            x1.color = x2.color;
            x2.color = temp;
        }

        void swapValues(Node u, Node v)
        {
            int temp;
            temp = u.val;
            u.val = v.val;
            v.val = temp;
        }

        // fix red red at given node 
        void fixRedRed(Node x)
        {
            // if x is root color it black and return 
            if (x == root)
            {
                x.color = COLOR.BLACK;
                return;
            }

            // initialize parent, grandparent, uncle 
            Node parent = x.parent, grandparent = parent.parent,
            uncle = x.uncle();

            if (parent.color != COLOR.BLACK)
            {
                if (uncle != null && uncle.color == COLOR.RED)
                {
                    // uncle red, perform recoloring and recurse 
                    parent.color = COLOR.BLACK;
                    uncle.color = COLOR.BLACK;
                    grandparent.color = COLOR.RED;
                    fixRedRed(grandparent);
                }
                else
                {
                    // Else perform LR, LL, RL, RR 
                    if (parent.isOnLeft())
                    {
                        if (x.isOnLeft())
                        {
                            // for left right 
                            swapColors(parent, grandparent);
                        }
                        else
                        {
                            leftRotate(parent);
                            swapColors(x, grandparent);
                        }
                        // for left left and left right 
                        rightRotate(grandparent);
                    }
                    else
                    {
                        if (x.isOnLeft())
                        {
                            // for right left 
                            rightRotate(parent);
                            swapColors(x, grandparent);
                        }
                        else
                        {
                            swapColors(parent, grandparent);
                        }

                        // for right right and right left 
                        leftRotate(grandparent);
                    }
                }
            }
        }

        // find node that do not have a left child 
        // in the subtree of the given node 
        Node successor(Node x)
        {
            Node temp = x;

            while (temp.left != null)
                temp = temp.left;

            return temp;
        }

        // find node that replaces a deleted node in BST 
        Node BSTreplace(Node x)
        {
            // when node have 2 children 
            if (x.left != null && x.right != null)
                return successor(x.right);

            // when leaf 
            if (x.left == null && x.right == null)
                return null;

            // when single child 
            if (x.left != null)
                return x.left;
            else
                return x.right;
        }

        // deletes the given node 
        void deleteNode(Node v)
        {
            Node u = BSTreplace(v);

            // True when u and v are both black 
            bool uvBlack = ((u == null || u.color == COLOR.BLACK) && (v.color == COLOR.BLACK));
            Node parent = v.parent;

            if (u == null)
            {
                // u is null therefore v is leaf 
                if (v == root)
                {
                    // v is root, making root null 
                    root = null;
                }
                else
                {
                    if (uvBlack)
                    {
                        // u and v both black 
                        // v is leaf, fix double black at v 
                        fixDoubleBlack(v);
                    }
                    else
                    {
                        // u or v is red 
                        if (v.sibling() != null)
                            // sibling is not null, make it red" 
                            v.sibling().color = COLOR.RED;
                    }

                    // delete v from the tree 
                    if (v.isOnLeft())
                    {
                        parent.left = null;
                    }
                    else
                    {
                        parent.right = null;
                    }
                }
                v = null;
                return;
            }

            if (v.left == null || v.right == null)
            {
                // v has 1 child 
                if (v == root)
                {
                    // v is root, assign the value of u to v, and delete u 
                    v.val = u.val;
                    v.left = v.right = null;
                    u = null;
                }
                else
                {
                    // Detach v from tree and move u up 
                    if (v.isOnLeft())
                    {
                        parent.left = u;
                    }
                    else
                    {
                        parent.right = u;
                    }
                    v = null;
                    u.parent = parent;
                    if (uvBlack)
                    {
                        // u and v both black, fix double black at u 
                        fixDoubleBlack(u);
                    }
                    else
                    {
                        // u or v red, color u black 
                        u.color = COLOR.BLACK;
                    }
                }
                return;
            }

            // v has 2 children, swap values with successor and recurse 
            swapValues(u, v);
            deleteNode(u);
        }

        void fixDoubleBlack(Node x)
        {
            if (x == root)
                // Reached root 
                return;

            Node sibling = x.sibling(), parent = x.parent;
            if (sibling == null)
            {
                // No sibiling, double black pushed up 
                fixDoubleBlack(parent);
            }
            else
            {
                if (sibling.color == COLOR.RED)
                {
                    // Sibling red 
                    parent.color = COLOR.RED;
                    sibling.color = COLOR.BLACK;
                    if (sibling.isOnLeft())
                    {
                        // left case 
                        rightRotate(parent);
                    }
                    else
                    {
                        // right case 
                        leftRotate(parent);
                    }
                    fixDoubleBlack(x);
                }
                else
                {
                    // Sibling black 
                    if (sibling.hasRedChild())
                    {
                        // at least 1 red children 
                        if (sibling.left != null && sibling.left.color == COLOR.RED)
                        {
                            if (sibling.isOnLeft())
                            {
                                // left left 
                                sibling.left.color = sibling.color;
                                sibling.color = parent.color;
                                rightRotate(parent);
                            }
                            else
                            {
                                // right left 
                                sibling.left.color = parent.color;
                                rightRotate(sibling);
                                leftRotate(parent);
                            }
                        }
                        else
                        {
                            if (sibling.isOnLeft())
                            {
                                // left right 
                                sibling.right.color = parent.color;
                                leftRotate(sibling);
                                rightRotate(parent);
                            }
                            else
                            {
                                // right right 
                                sibling.right.color = sibling.color;
                                sibling.color = parent.color;
                                leftRotate(parent);
                            }
                        }
                        parent.color = COLOR.BLACK;
                    }
                    else
                    {
                        // 2 black children 
                        sibling.color = COLOR.RED;
                        if (parent.color == COLOR.BLACK)
                            fixDoubleBlack(parent);
                        else
                            parent.color = COLOR.BLACK;
                    }
                }
            }
        }
    }
}
