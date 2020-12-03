using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB8
{
    class NotNumberException : Exception
    {
        public NotNumberException(string msg) : base(msg)
        { }
    }
    interface IOperations<T>
    {
        void Add(T value);
        bool Delete(T value);
        void View();
    }
    public class MT
    {
        dynamic A;
        public dynamic mt
        {
            get { return A; }
            set
            {
                var test = value;
                if(test is string || test is char)
                {
                    throw new NotNumberException("Должно быть число");
                }
                else
                {
                    A = value;
                }
            }
        }
    }
    public class Node<T>
    {
        public Node(T date)
        {
            Date = date;
        }
        public T Date{  get; set; }
        public Node<T> Next { get; set; }
    }
    public class List<T> : IEnumerable<T>, IOperations<T> where T : struct
    {
        Node<T> head;
        Node<T> tail;
        int count;
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Date;
                current = current.Next;
            }
        }
        public void Add(T date)
        {
            Node<T> node = new Node<T>(date);
            if(head == null)
            {
                head = node;
            }
            else
            {
                tail.Next = node;
            }
            tail = node;
            count++;
        }
        public bool Delete(T date)
        {
            Node<T> current = head;
            Node<T> prev = null;
            while (current != null)
            {
                if(current.Date.Equals(date))
                {
                    if(prev != null)
                    {
                        prev.Next = current.Next;
                        if(current.Next == null)
                        {
                            tail = prev;
                        }
                    }
                    else
                    {
                        head = head.Next;
                        if(head == null)
                        {
                            tail = null;
                        }
                    }
                    count--;
                    return true;
                }
                prev = current;
                current = current.Next;
            }
            return false;
        }
        public void View()
        {
            List<int> _List = new List<int>();
            _List.Add(13);
            _List.Add(4);
            _List.Add(90);
            foreach(var item in _List)
            {
                Console.WriteLine(item);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<float> List_ = new List<float>();
                List_.Add(1.3f);
                List_.Add(2.4f);
                List_.Add(7.5f);
                foreach(var item in List_)
                {
                    Console.WriteLine(item);
                }
                List<int> IList1 = new List<int>(); 
                List<int> IList2 = new List<int>(); 
                for(int i = 0; i < 7; i++)
                {
                    MT t = new MT();
                    t.mt = i;
                    IList1.Add(t.mt);
                    IList2.Add(t.mt);
                    if(t.mt == 2)
                    {
                        IList2.Delete(t.mt);
                    }
                }
                Console.WriteLine(IList1 != IList2);
                Console.WriteLine("Элементы IList1: ");
                foreach(var item in IList1)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Элементы IList2: ");
                foreach (var item in IList2)
                {
                    Console.WriteLine(item);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.WriteLine("Всё, что еще ждешь?");
            }
        }
    }
}
