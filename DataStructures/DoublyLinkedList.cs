using System.Collections;

namespace DataStructures
{
    public class DoublyLinkedList<T> : IEnumerable<T> where T : class
    {
        private Node<T>? head = null;
        private Node<T>? tail = null;
        private int size = 0;

        internal class Node<T> 
        {
            internal T? data;
            internal Node<T>? next;
            internal Node<T>? prev;

            public Node(T? data, Node<T>? prev, Node<T>? next)
            {
                this.data = data;
                this.prev = prev;
                this.next = next;
            }

            public override string? ToString() => data.ToString();
        }

        public void Clear()
        {
            Node<T>? traverse = head;

            while (traverse != null)
            {
                Node<T>? next = traverse.next;

                traverse.prev = null;
                traverse.next = null;
                traverse.data = null;
                
                traverse = next;
            }

            head = tail = null;
            size = 0;
        }

        public int Size() => size;

        public bool IsEmpty() => size == 0;

        public void Add(T data)
        {
            AddLast(data);
        }

        public void AddFirst(T data)
        {
            if (IsEmpty())
            {
                head = tail = new Node<T>(data: data, prev: null, next: null);
            }
            else
            {
                head.prev = new Node<T>(data: data, prev: null, next: head);
                head = head.prev;
            }
            size++;
        }

        public void AddLast(T data)
        {
            if (IsEmpty())
            {
                head = tail = new Node<T>(data: data, prev: null, next: null);
            }
            else
            {
                tail.next = new Node<T>(data: data, prev: tail, next: null);
                tail = tail.next;
            }
            size++;
        }

        public T? PeekFirst()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException(
                    "Can't PeekFirst(): the Linked List is empty!");
            }
            return head.data;
        }

        public T? PeekLast()
        {
            if (IsEmpty())
            { 
                throw new InvalidOperationException(
                    "Can't PeekLast(): the Linked List is empty!"); 
            }
            return tail.data;
        }

        public T? RemoveFirst()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException(
                    "Can't RemoveFirst(): the Linked List is empty!");
            }
            
            T? data = head.data;
            
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

        public T? RemoveLast()
        {
            if (IsEmpty())
            { 
                throw new InvalidOperationException(
                    "Can't RemoveLast(): the Linked List is empty!");
            }

            T? data = tail.data;

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

        private T? Remove(Node<T> node)
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

            T? data = node.data;

            node.data = null;
            node.next = null;
            node.prev = null;
            
            size--;

            return data;
        }

        public T? RemoveAt(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new ArgumentOutOfRangeException(
                    $"Can't RemoveAt({index}): Index is out of range!");
            }

            int localIndex = 0;
            Node<T>? traverse = head;
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
            Node<T>? traverse;

            if (obj == null)
            {
                for (traverse = head; 
                    traverse != null; 
                    traverse = traverse.next)
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
                for (traverse = head; 
                    traverse != null; 
                    traverse = traverse.next)
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
            Node<T>? traverse;

            if (obj == null)
            {
                for (traverse = head; 
                    traverse != null; 
                    traverse = traverse.next, index++)
                {
                    if (traverse.data == null)
                    {
                        return index;
                    }
                }
            }
            else
            {
                for (traverse = head; 
                    traverse != null; 
                    traverse = traverse.next, index++)
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

            Node<T>? traverse = head;
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

        public IEnumerator<T> GetEnumerator()
        {
            Node<T>? traverse = head;

            while (traverse != null)
            {
                yield return traverse.data;
                traverse = traverse.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
