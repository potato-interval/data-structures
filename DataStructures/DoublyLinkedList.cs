using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class DoublyLinkedList
    {
        private Node? head = null;
        private Node? tail = null;
        private int size = 0;

        internal class Node
        {
            internal int? data;
            internal Node? next;
            internal Node? prev;

            public Node(int? data, Node? prev, Node? next)
            {
                this.data = data;
                this.prev = prev;
                this.next = next;
            }

            public override string ToString()
                => data.ToString();
        }

        public void Clear()
        {
            Node? traverse = head;
            while (traverse != null)
            {
                Node? next = traverse.next;
                traverse.prev = traverse.next = null;
                traverse.data = null;
                traverse = next;
            }
            head = tail = null;
            size = 0;
        }

        public int Size() => size;

        public bool IsEmpty() => size == 0;

        public void Add(int? data)
        {
            AddLast(data);
        }

        public void AddFirst(int? data)
        {
            if (IsEmpty())
            {
                head = tail = new Node(data: data, prev: null, next: null);
            }
            else
            {
                head.prev = new Node(data: data, prev: null, next: head);
                head = head.prev;
            }
            size++;
        }

        public void AddLast(int? data)
        {
            if (IsEmpty())
            {
                head = tail = new Node(data: data, prev: null, next: null);
            }
            else
            {
                tail.next = new Node(data: data, prev: tail, next: null);
                tail = tail.next;
            }
            size++;
        }

        public int? PeekFirst()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }
            return head.data;
        }

        public int? PeekLast()
        {
            if (IsEmpty())
            { 
                throw new InvalidOperationException(); 
            }
            return tail.data;
        }

        public int? RemoveFirst()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }
            
            int? data = head.data;
            
            head = head.next;
            size--;

            if (IsEmpty())
            {
                tail = null;
            }
            else
            {
                head.prev = null;
            }
            
            return data;
        }

        public int? RemoveLast()
        {
            if (IsEmpty())
            { 
                throw new InvalidOperationException();
            }

            int? data = tail.data;

            tail = tail.prev;
            size--;

            if (IsEmpty())
            {
                head = null;
            }
            else
            {
                tail.next = null;
            }
            
            return data;
        }

        private int? Remove(Node? node)
        {
            if (node.prev == null)
            {
                return RemoveFirst();
            }

            if (node.next == null)
            {
                return RemoveLast();
            }

            node.next.prev = node.prev;
            node.prev.next = node.next;

            int? data = node.data;

            node.data = null;
            node.next = null;
            node.prev = null;
            
            size--;

            return data;
        }

        public int? RemoveAt(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new ArgumentOutOfRangeException();
            }

            int localIndex = 0;
            Node? traverse = head;
            while (localIndex < index)
            {
                traverse = traverse.next;
                localIndex++;
            }

            if (traverse == head)
            {
                return RemoveFirst();
            }

            if (traverse == tail)
            {
                return RemoveLast();
            }

            return Remove(traverse);
        }

        public bool Remove(Object obj)
        {
            Node? traverse;

            if (obj == null)
            {
                for (traverse = head; traverse != null; traverse = traverse.next)
                {
                    if (traverse.data == null)
                    {
                        Remove(traverse);
                        return true;
                    }
                }
            }
            else
            {
                for (traverse = head; traverse != null; traverse = traverse.next)
                {
                    if (obj.Equals(traverse.data))
                    {
                        Remove(traverse);
                        return true;
                    }
                }
            }
            
            return false;
        }

        public int IndexOf(Object obj)
        {
            int index = 0;
            Node? traverse;

            if (obj == null)
            {
                for (traverse = head; traverse != null; traverse = traverse.next, index++)
                {
                    if (traverse.data == null)
                    {
                        return index;
                    }
                }
            }
            else
            {
                for (traverse = head; traverse != null; traverse = traverse.next, index++)
                {
                    if (obj.Equals(traverse.data))
                    {
                        return index;
                    }
                }
            }
            
            return -1;
        }

        public bool Contains(Object obj) => IndexOf(obj) != -1;

        public override string ToString()
        {
            String? list = "[ ";

            Node? traverse = head;
            while (traverse != null)
            {
                list += traverse.data.ToString();
                list += ", ";
                traverse = traverse.next;
            }

            list = list.Trim().Trim(',');
            list += " ]";

            return list;
        }
    }
}
