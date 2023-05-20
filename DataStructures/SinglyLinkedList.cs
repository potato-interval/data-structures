using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace DataStructures
{
   public class SinglyLinkedList<T> : IEnumerable<T>
    {
        private int size = 0;
        private Node<T> head = null;
        private Node<T> tail = null;

        internal class Node<T>
        {
            internal T data;
            internal Node<T> next;

            public Node(T value)
            {
                this.data = value;
            }
        }

        public void Add(T value)
        {
            AddLast(value);
        }

        public void AddFirst(T value)
        {
            var node = new Node<T>(value);

            if (IsEmpty())
            {
                head = node;
                tail = node;
            }
            else
            {
                node.next = head;
                head = node;
            }

            size++;
        }

        public void AddLast(T value)
        {
            var node = new Node<T>(value);

            if (IsEmpty())
            {
                head = node;
                tail = node;
            }
            else
            {
                tail.next = node;
                tail = node;
            }

            size++;
        }

        public T PeekFirst()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Can't PeekFirst(): Linked List is Empty!");
            }

            return head.data;
        }

        public T PeekLast()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Can't PeekLast(): Linked List is Empty!");
            }

            return tail.data;
        }
        
        public T RemoveFirst()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Can't RemoveFirst(): Linked List is Empty!");
            }

            T data = head.data;
            
            // Create a copy of link to second node
            Node<T> pointerToSecond = head.next;
            
            // Erase original link
            head.next = null;
            
            // Declare the second node as a new first node
            head = pointerToSecond;
            
            size--;
            return data;
        }

        public int IndexOf(T value)
        {
            Node<T> trav = head;

            int index = 0;
            while (trav != null)
            {
                if (value.Equals(trav.data))
                {
                    return index;
                }

                trav = trav.next;
                index++;
            }

            return -1;
        }

        public bool Contains(T value)
        {
            return (IndexOf(value) != -1);
        }

        // TODO: refactor this method.
        public T GetDataByIndex(int idx)
        {
            if (idx < size)
            {
                T currentValue = head.data;
                var trav = head;

                int jdx = 0;
                while (jdx <= idx)
                {
                    currentValue = trav.data;

                    trav = trav.next;

                    if (jdx == idx)
                    {
                        break;
                    }

                    jdx++;
                }

                return currentValue;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        private bool IsEmpty()
        {
            return head == null;
        }

        public override string ToString()
        {
            string output = string.Empty;
            output += "[";

            if (IsEmpty())
            {
                return output;
            }
            else
            {
                Node<T> trav = head;

                while (trav != null)
                {
                    output += trav.data.ToString();
                    output += ", ";
                    trav = trav.next;
                }

                output = output.Trim().Trim(',');
                output += "]";
                return output;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> trav = head;

            while (trav != null)
            {
                yield return trav.data;
                trav = trav.next;
            }                
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}