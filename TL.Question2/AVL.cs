using System;
namespace TL.Question2
{
    /// <summary>
    /// Class <c>AVL</c> models AVL tree data structure.
    /// Reference: https://en.wikipedia.org/wiki/AVL_tree
    /// </summary>
    public class AVL
    {
        Node Root;

        public AVL()
        {
        }

        /// <summary>
        /// Method <c>AddData</c> adds a node to the AVL tree.
        /// </summary>
        /// <param name="data">the new data to be added</param>
        public void AddData(int data)
        {
            Root = Root == null ? new Node(data) : Insert(Root, new Node(data));
        }

        /// <summary>
        /// Method <c>SearchData</c> looks up the node inside the AVL tree.
        /// </summary>
        /// <param name="key">the new data to be added</param>
        public void SearchData(int key)
        {
            if (LookUp(key, Root).Data == key)
            {
                Console.WriteLine("{0} was found!", key);
            }
            else
            {
                Console.WriteLine("Not found!");
            }
        }

        /// <summary>
        /// Method <c>Print</c> prints all nodes using in order traversal
        /// </summary>
        public void Print()
        {
            if (Root == null)
            {
                Console.WriteLine("Empty");
                return;
            }

            InOrderTraversal(Root);
            Console.WriteLine();
        }

        private Node LookUp(int key, Node currentNode)
        {

            if (key < currentNode.Data)
            {
                if (key == currentNode.Data)
                {
                    return currentNode;
                }
                else
                    return LookUp(key, currentNode.Left);
            }
            else
            {
                if (key == currentNode.Data)
                {
                    return currentNode;
                }
                else
                    return LookUp(key, currentNode.Right);
            }
        }

        /// <summary>
        /// Method <c>InOrderTraversal</c> performs in order traversal.
        /// </summary>
        /// <param name="currentNode">the current node</param>
        private void InOrderTraversal(Node currentNode)
        {
            if (currentNode != null)
            {
                InOrderTraversal(currentNode.Left);
                Console.Write("{0} ", currentNode.Data);
                InOrderTraversal(currentNode.Right);
            }
        }

        /// <summary>
        /// Method <c>Insert</c> inserts a new node to current AVL tree recursively.
        /// </summary>
        /// <param name="newNode">the new node to be added</param>
        /// <param name="currentNode">the current node</param>
        /// <returns>new node</returns>
        private Node Insert(Node currentNode, Node newNode)
        {
            if (currentNode == null)
            {
                currentNode = newNode;
            }
            else if (newNode.Data <= currentNode.Data)
            {
                currentNode.Left = Insert(currentNode.Left, newNode);
                currentNode = ReBalance(currentNode);
            }
            else if (newNode.Data > currentNode.Data)
            {
                currentNode.Right = Insert(currentNode.Right, newNode);
                currentNode = ReBalance(currentNode);
            }

            return currentNode;
        }

        /// <summary>
        /// Method <c>ReBalance</c> rebalances the AVL based on balance factor.
        /// </summary>
        /// <param name="currentNode">the current node</param>
        /// <returns>new node</returns>
        private Node ReBalance(Node currentNode)
        {
            int balanceFactor = GetBalanceFactor(currentNode);
            if (balanceFactor > 1)
            {
                if (GetBalanceFactor(currentNode.Left) > 0)
                {
                    // Left Left variant
                    currentNode = RotateRight(currentNode);
                }
                else
                {
                    // Left Right variant
                    currentNode = RotateLR(currentNode);
                }
            }
            else if (balanceFactor < -1)
            {
                if (GetBalanceFactor(currentNode.Right) > 0)
                {
                    // Right Left variant
                    currentNode = RotateRL(currentNode);
                }
                else
                {
                    // Right Right variant
                    currentNode = RotateLeft(currentNode);
                }
            }

            return currentNode;
        }

        /// <summary>
        /// Method <c>GetBalanceFactor</c> calculates balance factor for current node.
        /// </summary>
        /// <param name="currentNode">the current node</param>
        /// <returns>An integer for balance factor</returns>
        private int GetBalanceFactor(Node currentNode)
        {
            int leftHeight = GetHeight(currentNode.Left);
            int rightHeight = GetHeight(currentNode.Right);
            int balanceFactor = leftHeight - rightHeight;
            return balanceFactor;
        }

        /// <summary>
        /// Method <c>GetHeight</c> calculates the height for current node.
        /// </summary>
        /// <param name="currentNode">the current node</param>
        /// <returns>An integer for the height</returns>
        private int GetHeight(Node currentNode)
        {
            int height = 0;
            if (currentNode != null)
            {
                int l = GetHeight(currentNode.Left);
                int r = GetHeight(currentNode.Right);
                int m = Math.Max(l, r);
                height = m + 1;
            }
            return height;
        }

        /// <summary>
        /// Method <c>RotateLeft</c> performs rebalancing for Right Right variant.
        /// </summary>
        /// <param name="root">the root node</param>
        /// <returns>the new root Node after rebalancing</returns>
        private Node RotateLeft(Node root)
        {
            Node pivot = root.Right;
            root.Right = pivot.Left;
            pivot.Left = root;
            return pivot;
        }

        /// <summary>
        /// Method <c>RotateRight</c> performs rebalancing for Left Left variant.
        /// </summary>
        /// <param name="root">the root node</param>
        /// <returns>the new root Node after rebalancing</returns>
        private Node RotateRight(Node root)
        {
            Node pivot = root.Left;
            root.Left = pivot.Right;
            pivot.Right = root;
            return pivot;
        }

        /// <summary>
        /// Method <c>RotateLR</c> performs rebalancing for Left Right variant.
        /// </summary>
        /// <param name="root">the root node</param>
        /// <returns>the new root Node after rebalancing</returns>
        private Node RotateLR(Node root)
        {
            Node pivot = root.Left;
            root.Left = RotateLeft(pivot);
            return RotateRight(root);
        }

        /// <summary>
        /// Method <c>RotateRL</c> performs rebalancing for Right Left variant.
        /// </summary>
        /// <param name="root">the root node</param>
        /// <returns>the new root Node after rebalancing</returns>
        private Node RotateRL(Node parent)
        {
            Node pivot = parent.Right;
            parent.Right = RotateRight(pivot);
            return RotateLeft(parent);
        }
    }
}

