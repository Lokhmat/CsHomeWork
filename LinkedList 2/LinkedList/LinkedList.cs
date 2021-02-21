using System;
using System.Collections.Generic;
using System.Data.Common;

namespace LinkedList
{
    /// <summary>
    /// Необходимо реализовать унаследованный классом LinkedList интерфейс 
    /// (реализовать = написать все объявленные в нем методы)
    /// throw new NotImplementedException(); подлежат удалению и замене на реализацию каждой ветви кода, где такие бросания сейчас находятся.
    /// Кроме того, я не выписал некоторые члены интерфейса, 
    /// потому программа поначалу не будет компилироваться - просьба разобраться и выписать их самим - гугл и студия в помощь.
    /// 
    /// Сразу поясняю T - не равно Node!
    /// Другие члены - поля, свойства, методы и пр. - можно добавлять на ваше усмотрение!
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class LinkedList<T> : ICustomCollection<T>
    {
        int Count { get; set; }
        Node<T> first;
        Node<T> last;
        public T this[int index]
        {
            get
            {
                if (index >= Count)
                    throw new IndexOutOfRangeException($"Length is {Count} you try to get {index} element");
                Node<T> cur = first;
                if (index == 0)
                    return cur.element;
                for (int i = 0; i < index; i++)
                {
                    cur = cur.next;
                }
                return cur.element;
            }
            set
            {
                if (index >= Count)
                    throw new IndexOutOfRangeException($"Length is {Count} you try to set {index} element");
                Node<T> cur = first;
                if (index == 0)
                {
                    cur.element = value;
                    return;
                }

                for (int i = 0; i < index; i++)
                {
                    cur = cur.next;
                }
                cur.element = value;
            }
        }

        public int Length
            => Count;

        public void Add(T item)
        {
            if (Count == 0)
            {
                first = new Node<T>(item);
                last = first;
                Count++;
            }
            else
            {
                Count++;
                Node<T> newNode = new Node<T>(item);
                last.next = newNode;
                last = newNode;

            }
        }

        public bool Contains(T item)
        {
            Node<T> cur = first;
            Comparer<T> comparer = Comparer<T>.Default;
            for (int i = 0; i < Count - 1; i++)
            {
                if (comparer.Compare(cur.element, item) == 0)
                    return true;
                cur = cur.next;
            }
            return false;
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public void Remove(int index)
        {
            if (index >= Count)
                throw new IndexOutOfRangeException($"Length is {Count} you try to remove {index} element");
            if (index == 0)
            {
                first = first.next;
                Count--;
                return;
            }
            Node<T> cur = first;
            Node<T> left = first;
            for (int i = 0; i < index; i++)
            {
                left = cur;
                cur = cur.next;
            }
            var right = cur.next;
            left.next = right;
            Count--;
        }

        public override string ToString()
        {
            string stringOfItems = "";
            Node<T> cur = first;
            for (int i = 0; i < Count; i++)
            {
                if (i == Count - 1)
                    stringOfItems += $"{cur.element}";
                else
                {
                    stringOfItems += $"{cur.element} ";
                    cur = cur.next;
                }
            }
            return $"{Length} items: [{stringOfItems}]";

        }
    }

    /// <summary>
    /// Это класс, представляющий из себя коробочки, из которых должен состоять односвязный список - 
    /// какие в нем должны быть члены - 
    /// можно догадаться, 
    /// посмотреть в справочном материале в гугле/слаке, 
    /// вспомнить, о чем говорилось в конце занятия в субботу
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Node<T>
    {
        public T element;
        public Node<T> next;

        public Node(T element)
        {
            this.element = element;
        }
    }
}
