﻿using System.Collections;
using System.Collections.Generic;

namespace doubly_linked_list
{
    public class DoubleLinkedList<T> : IEnumerable<Node<T>>
    {
        private Node<T> _head;
        public Node<T> First
        {
            get
            {
                return _head;
            }
        }

        private Node<T> _tail;
        public Node<T> Last
        {
            get
            {
                return _tail;
            }
        }

        private int _length;
        public int Count
        {
            get
            {
                return _length;
            }
        }

        public IEnumerator<Node<T>> GetEnumerator()
        {
            Node<T> current = _head;
            while (current != default)
            {
                yield return current;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable WalkInReverse()
        {
            Node<T> current = _head;
            while (current != default)
            {
                yield return current;
                current = current.Previous;
            }
        }

        public DoubleLinkedList<T> AddLast(T data)
        {
            Node<T> newNode = new Node<T>
            {
                Data = data,
            };

            if (_tail == default)
            {
                _head = newNode;
            }
            else
            {
                newNode.Previous = _tail;
                _tail.Next = newNode;
            }

            _tail = newNode;
            _length++;
            return this;
        }

        public DoubleLinkedList<T> AddFirst(T data)
        {
            Node<T> newNode = new Node<T>
            {
                Data = data,
            };

            if (_head == default)
            {
                _tail = newNode;
            }
            else
            {
                _head.Previous = newNode;
            }

            _head = newNode;
            _length++;
            return this;
        }

        public bool Contains(T data)
        {
            Node<T> current = _head;
            while (current != default)
            {
                if (current.Data.Equals(data)) return true;
                
                current = current.Next;
            }

            return false;
        }

        public DoubleLinkedList<T> Remove(T data)
        {
            if (_head == default) return this;

            Node<T> current = _head;
            while (current != default && !current.Data.Equals(data))
            {
                current = current.Next;
            }

            if (current == default) return this;

            // 1 -> 2 -> 3 -> 4 -> 5
            // 4.prev = 2
            current.Previous.Next = current.Next;

            // 2.next = 4
            current.Next.Previous = current.Previous;

            current.Previous = default;
            current.Next = default;
            _length--;
            return this;
        }

        public DoubleLinkedList<T> RemoveFirst()
        {
            if (_head == default) return this;

            // Only single node
            if (_head.Next == default)
            {
                _head = default;
                _tail = default;
            }
            // Multiple nodes
            else
            {
                // 1 -> 2 -> 3 -> 4 -> 5

                // 2.prev = null
                _head.Next.Previous = default;

                // 1.next = 2
                _head = _head.Next;
            }

            _length--;
            return this;
        }
    }
}