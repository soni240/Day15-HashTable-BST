// See https://aka.ms/new-console-template for more information
using BinarySearchTree_HashTable;

Console.WriteLine("----- Binary_Search_Tree -----\n");

BinarySearchTreeOps<int> binarySearchTree = new BinarySearchTreeOps<int>(56); //Root=56  

binarySearchTree.InsertMultiItems(30, 70, 22, 40, 60, 95, 11, 65, 3, 16, 63, 67);

Console.WriteLine("\n>> Binary_Search_Tree :- ");
binarySearchTree.Display();

binarySearchTree.GetSizeOfBSt(binarySearchTree);

binarySearchTree.IfExists(95, binarySearchTree);

Console.ReadKey();


