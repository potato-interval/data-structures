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

            var doublyList = new DoublyLinkedList<string>();
            doublyList.Add("1");
            doublyList.Add("3");
            doublyList.Add("6");
            Console.WriteLine(doublyList);
            foreach (var item in doublyList)
            {
                Console.WriteLine(item);
            }

            doublyList.RemoveAt(1);
            doublyList.RemoveAt(0);

            Console.WriteLine(doublyList);
            
            doublyList.Add("5");
            doublyList.Add("6");
            Console.WriteLine(doublyList);

            doublyList.RemoveAt(1);
            Console.WriteLine(doublyList);

            doublyList.Remove("6");
            Console.WriteLine(doublyList);

            if (doublyList.Remove("6"))
            {
                Console.WriteLine("yes");
            }

        }
    }
}