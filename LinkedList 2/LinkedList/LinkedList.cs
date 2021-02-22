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
        int count;
        Node<T> first;
        Node<T> last;
        public T this[int index]
        {
            get
            {
                if (index >= count)
                    throw new IndexOutOfRangeException($"Length is {count} you try to get {index} element");
                Node<T> cur = first;
                if (index == 0)
                    return cur.Element;
                for (int i = 0; i < index; i++)
                {
                    cur = cur.Next;
                }
                return cur.Element;
            }
            set
            {
                if (index >= count)
                    throw new IndexOutOfRangeException($"Length is {count} you try to set {index} element");
                Node<T> cur = first;
                if (index == 0)
                {
                    cur.Element = value;
                    return;
                }

                for (int i = 0; i < index; i++)
                {
                    cur = cur.Next;
                }
                cur.Element = value;
            }
        }

        public int Length
            => count;

        public void Add(T item)
        {
            if (count == 0)
            {
                first = new Node<T>(item);
                last = first;
                count++;
            }
            else
            {
                count++;
                Node<T> newNode = new Node<T>(item);
                last.Next = newNode;
                last = newNode;

            }
        }

        public bool Contains(T item)
        {
            Node<T> cur = first;
            Comparer<T> comparer = Comparer<T>.Default;
            for (int i = 0; i < count - 1; i++)
            {
                if (comparer.Compare(cur.Element, item) == 0)
                    return true;
                cur = cur.Next;
            }
            return false;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public void Remove(int index)
        {
            if (index >= count)
                throw new IndexOutOfRangeException($"Length is {count} you try to remove {index} element");
            if (index == 0)
            {
                first = first.Next;
                count--;
                return;
            }
            Node<T> cur = first;
            Node<T> left = first;
            for (int i = 0; i < index; i++)
            {
                left = cur;
                cur = cur.Next;
            }
            var right = cur.Next;
            left.Next = right;
            count--;
        }

        public override string ToString()
        {
            string stringOfItems = "";
            Node<T> cur = first;
            for (int i = 0; i < count; i++)
            {
                if (i == count - 1)
                    stringOfItems += $"{cur.Element}";
                else
                {
                    stringOfItems += $"{cur.Element} ";
                    cur = cur.Next;
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
        public T Element { get; set; }
        public Node<T> Next { get; set; }

        public Node(T element)
        {
            Element = element;
        }
    }
}
