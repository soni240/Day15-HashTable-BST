using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree_HashTable
{
    public class BinarySearchTreeOps<T> where T : IComparable<T>
    {
        public T NodeData { get; set; }
        public BinarySearchTreeOps<T> leftTree { get; set; }
        public BinarySearchTreeOps<T> rightTree { get; set; }

        int leftCount = 0, rightCount = 0;
        bool result = false;
        public BinarySearchTreeOps(T NodeData)
        {
            this.NodeData = NodeData;
            this.leftTree = leftTree;
            this.rightTree = rightTree;
        }


        public void Insert(T item)
        {
            T currentnodevalue = this.NodeData;

            if ((currentnodevalue.CompareTo(item)) > 0)
            {
                if (this.leftTree == null)
                {
                    this.leftTree = new BinarySearchTreeOps<T>(item);
                    Console.WriteLine("> {0} is inserted in BinarySearchTree...", item);
                }
                else
                {
                    this.leftTree.Insert(item);
                }

            }

            else
            {
                if (this.rightTree == null)
                {
                    this.rightTree = new BinarySearchTreeOps<T>(item);
                    Console.WriteLine("> {0} is inserted in BinarySearchTree...", item);
                }
                else
                {
                    this.rightTree.Insert(item);
                }
            }
        }

        public void Display()
        {
            if (this.leftTree != null)
            {
                leftCount++;
                this.leftTree.Display();
            }

            Console.WriteLine(this.NodeData.ToString());

            if (this.rightTree != null)
            {
                rightCount++;
                this.rightTree.Display();
            }


        }

    }
}
