using Fundamental_Algorithms.Information_Structures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_Fundamental_Algorithms.Information_Structures
{
    [TestClass]
    public class BinaryTreeUnitTest
    {
        [TestMethod]
        public void InorderTraversalTestMethod()
        {
            // Sample tree: a.b.d, a.c.e.f, a.c.f.h, a.c.f.j
            BinaryTree<string> binaryTree = new BinaryTree<string>(new BinaryTreeNode<string>("A"));
            binaryTree.Root.Left = new BinaryTreeNode<string>("B");
            binaryTree.Root.Left.Left = new BinaryTreeNode<string>("D");
            binaryTree.Root.Right = new BinaryTreeNode<string>("C");
            binaryTree.Root.Right.Left = new BinaryTreeNode<string>("E");
            binaryTree.Root.Right.Right = new BinaryTreeNode<string>("F");
            binaryTree.Root.Right.Left.Right = new BinaryTreeNode<string>("G");
            binaryTree.Root.Right.Right.Left = new BinaryTreeNode<string>("H");
            binaryTree.Root.Right.Right.Right = new BinaryTreeNode<string>("J");

            string output = string.Empty;
            binaryTree.TraverseInorder(node => output += node.Value);

            // Inorder Traversal test should output "DBAEGCHFJ" if nodes are being visited
            // in the correct order.
            Assert.AreEqual("DBAEGCHFJ", output);
        }
    }
}
