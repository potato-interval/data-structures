using System.Collections.Generic;
using DataStructures;
namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new SinglyLinkedList<float>() { 1.4f, 3.2f, 5.7f };

            Console.WriteLine(list);

            var doublyList = new DoublyLinkedList();
            doublyList.Add(1);
            doublyList.Add(3);
            doublyList.Add(6);
            Console.WriteLine(doublyList);

            doublyList.RemoveAt(1);
            doublyList.RemoveAt(0);

            Console.WriteLine(doublyList);
            
            doublyList.Add(6);
            doublyList.Add(6);
            doublyList.Clear();
            Console.WriteLine(doublyList);

            doublyList.RemoveLast();
        }
    }
}