using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree_HashTable
{
    public class MyMapNode<K, V>
    {
        private readonly int size; ///declaring size variable of readonly type
        private readonly LinkedList<KeyValue<K, V>>[] items; ///declaring referance array variable of generic type
        public MyMapNode(int size)
        { ///intitaiallising the instances of current class
            this.size = size;
            this.items = new LinkedList<KeyValue<K, V>>[size];
        }
        public void Add(K key, V value)  ///this methd add <key,value> that we have passed while calling the methd
        {
            int position = GetArrayPosition(key); //here getArrayPostion methd is called tp get HashCode of String Key
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position); // GetLinkedList methd is called to create LinkedList of respective Position
            KeyValue<K, V> item = new KeyValue<K, V>() { Key = key, Value = value };//Object of Strcture KeyValue is getting created
            linkedList.AddLast(item);///Adding item in LinkedList using inbulit methd AddLast
        }
        public void Remove(K key)  ///Used to remove KeyValue pair
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            bool itemFound = false;
            KeyValue<K, V> foundItem = default(KeyValue<K, V>);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    itemFound = true;
                    foundItem = item;
                }
            }
            if (itemFound)
            {
                linkedList.Remove(foundItem);
            }


        }
        protected int GetArrayPosition(K key) ///used to get the hash code os string Key
        {
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }
        protected LinkedList<KeyValue<K, V>> GetLinkedList(int position) ///used to create LinkedList at Position of items array
        {
            LinkedList<KeyValue<K, V>> linkedList = items[position];
            if (linkedList == null)
            {
                linkedList = new LinkedList<KeyValue<K, V>>();
                items[position] = linkedList;
            }
            return linkedList;
        }
        public struct KeyValue<k, v>  ///Structure to get Structure of <Key,Value>
        {
            public k Key { get; set; }
            public v Value { get; set; }
        }
        public int CheckHash(K key) ///returns count of which the KeyValue is repeated in given array of string
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> LinkedListofPosition = GetLinkedList(position);
            int count = 1;
            bool found = false;
            KeyValue<K, V> founditem = default(KeyValue<K, V>);

            foreach (KeyValue<K, V> keyValue in LinkedListofPosition)
            {
                if (keyValue.Key.Equals(key))
                {
                    count = Convert.ToInt32(keyValue.Value) + 1;
                    found = true;
                    founditem = keyValue;
                }
            }
            if (found)
            {
                LinkedListofPosition.Remove(founditem);
                return count;
            }
            else
            {
                return 1;
            }

        }
        public void GetFreq() // get the Freq of Repetation of Strings in our items array of size 16
        {
            MyMapNode<string, int> myMap = new MyMapNode<string, int>(10);
            string[] Paragraph;
            string input = "Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations";
            Paragraph = input.Split(' ');
            //Given string input

            int counts = 1;
            foreach (string i in Paragraph)
            {
                counts = myMap.CheckHash(i);
                if (counts > 1)
                {
                    myMap.Add(i, counts);
                }
                else
                {
                    myMap.Add(i, 1);
                }
            }
            Console.WriteLine("\n>> Frequency of words in paragraph :-\n");
            IEnumerable<string> distinct = Paragraph.Distinct<string>();
            foreach (var i in distinct)
            {
                myMap.Display(i);
            }

        }
        public void Display(K key) //Extract all KeyValue pairs and display on console
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> LinkedListofPosition = GetLinkedList(position);
            foreach (KeyValue<K, V> keyValue in LinkedListofPosition)
            {
                if (keyValue.Key.Equals(key))
                {
                    Console.WriteLine("[ > KeyValue : " + keyValue.Key + "    => Freq of Occurance : " + keyValue.Value + " ]\n");
                }

            }
        }

    }
}
