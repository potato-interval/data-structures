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
        }
    }
}