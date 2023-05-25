using System.Collections;

namespace DataStructures
{
    public class Stack<T> : IEnumerable<T> where T : class
    {
        private DoublyLinkedList<T> list = new();

        public Stack() 
        { }

        public Stack(T firstElement)
        {
            Push(firstElement);
        }

        public int Size()
        {
            return list.Size();
        }

        public bool IsEmpty()
        {
            return list.Size() == 0;
        }

        public void Push(T element)
        {
            list.Add(element);
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException(
                    "Can't Pop(): the Stack is empty!");
            }

            return list.RemoveLast();
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException(
                    "Can't Peek(): the Stack is empty!");
            }

            return list.PeekLast();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
