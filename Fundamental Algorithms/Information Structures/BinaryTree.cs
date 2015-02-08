using System;
using System.Collections.Generic;

namespace Fundamental_Algorithms.Information_Structures
{
    /// <summary>
    /// Represents a binary tree
    /// </summary>
    /// <typeparam name="T">The type of value to save in the nodes of the tree.</typeparam>
    public class BinaryTree<T>
    {
        /// <summary>
        /// The root of the tree
        /// </summary>
        public BinaryTreeNode<T> Root { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="root">The root of the new binary tree</param>
        public BinaryTree(BinaryTreeNode<T> root) {
            Root = root;
        }

        /// <summary>
        /// Performs an Inorder traversal of the tree. An inorder traversal is performed
        /// as follows:
        /// Traverse the left subtree
        /// Visit the root
        /// Traverse the right subtree
        /// </summary>
        /// <param name="action">The action to perform that currently visited node.</param>
        public void TraverseInorder(Action<BinaryTreeNode<T>> action) {
            if (null == action) {
                return;
            }

            // Let Tree be a pointer to a binary tree; this algorithm visits all nodes of the binary tree inorder,
            // making use of an auxiliary stack A.
            
            // T1. [Initialize] Set stack A empty, and set the link variable P <- Tree
            Stack<BinaryTreeNode<T>> A = new Stack<BinaryTreeNode<T>>();
            BinaryTreeNode<T> P = Root;

            while (null != P || A.Count > 0) {
                // T2. [P = null?] If P = null, go to step T4.
                while (null != P) {
                    // T3. (Now P points to a nonempty binary tree that is to be traversed.) Set A <= P; that is, push
                    // the value of P onto stack A. Then set P <- LLINK(P) and return to step T2.
                    A.Push(P);
                    P = P.Left;
                }

                // T4. [P <= Stack.] If stack A is empty, the algorithm terminates; otherwise set P <= A.
                if (A.Count <= 0) {
                    return;
                }

                // T5. Visit NODE(P). Then set P <- RLINK(P) and return to step T2.
                P = A.Pop();
                action(P);
                P = P.Right;
            }
        }
    }
    
    /// <summary>
    /// Represents a node of the binary tree
    /// </summary>
    /// <typeparam name="T">The type of value to save in the node of the tree.</typeparam>
    public class BinaryTreeNode<T>
    {
        /// <summary>
        /// The left child
        /// </summary>
        public BinaryTreeNode<T> Left { get; set; }
        /// <summary>
        /// The right child
        /// </summary>
        public BinaryTreeNode<T> Right { get; set; }
        /// <summary>
        /// The value of the this node
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="value">The value to store in the node.</param>
        /// <param name="left">The left child of the node.</param>
        /// <param name="right">The right child of the node.</param>
        public BinaryTreeNode(T value, BinaryTreeNode<T> left = null, BinaryTreeNode<T> right = null) {
            Value = value;
            Left = left;
            Right = right;
        }
    }
}
