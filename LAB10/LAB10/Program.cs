using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using ThirdTask;

namespace LAB10
{
    class Boss
    {
        private string name;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public Boss(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
    class Program
    {
        private static void Deal(object a, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: 
                    {
                        Boss newBoss = e.NewItems[0] as Boss;
                        Console.WriteLine("Add object: " + newBoss.Name + ".");
                        break;
                    }
                case NotifyCollectionChangedAction.Remove:
                    {
                        Boss oldBoss = e.OldItems[0] as Boss;
                        Console.WriteLine("Del object: " + oldBoss.Name + ".");
                        break;
                    }
            }
        }
        static void Main(string[] args)
        {
            Random rand = new Random();
            Console.WriteLine("1 задание:");
            ArrayList list = new ArrayList();
            for(int i = 0; i < 5; i ++)
            {
                list.Add(rand.Next(100));
            }
            list.Add("STRING");
            list.RemoveAt(3);
            Console.WriteLine($"Количество элементов: {list.Count}");
            Console.WriteLine($"Элементы:");
            foreach (var item in list)
            {
                Console.WriteLine($"||{item}");
            }
            Console.WriteLine($"Поиск элемента: {list.Contains("STRING")}");
            Console.WriteLine($"2 задание:");
            ArrayList SortedSet = new ArrayList();
            int count = rand.Next(5, 10);
            for(int i = 0; i < count; i++)
            {
                SortedSet.Add(rand.Next(100));
            }
            Console.WriteLine($"Элементы:");
            foreach (var item1 in SortedSet)
            {
                Console.WriteLine($"||{item1}");
            }
            Console.WriteLine($"Элементы после удаления:");
            for (int i = 1; i < 3; i++)
            {
                SortedSet.RemoveAt(i);
            }
            foreach(var item2 in SortedSet)
            {
                Console.WriteLine($"||{item2}");
            }
            ArrayList Queue = new ArrayList();
            for(int i = 0; i < SortedSet.Count; i++)
            {
                Queue.Add(SortedSet[i]);
            }
            Console.WriteLine($"Элементы Queue:");
            foreach (var item3 in Queue)
            {
                Console.WriteLine($"||{item3}");
            }
            Console.WriteLine($"Поиск элемента: {Queue.Contains("34")}");
            Console.WriteLine($"3 задание:");

            One x = new One("Hello", 6, "World", 5.1f);
            Two y = new Two("Helllo", 3, 2.4f, "Worrld");

            LinkedList<Org> list3 = new LinkedList<Org>();

            list3.AddLast(x);
            list3.AddLast(y);

            foreach (var item4 in list3)
            {
                Console.WriteLine(item4);
            }

            int k = 2;

            for (int i = 0; i < k; i++)
            {
                list3.RemoveFirst();
            }

            Queue<Org> Que_1 = new Queue<Org>();
            Org[] Arr_1 = new Org[list3.Count];

            list3.CopyTo(Arr_1, 0);

            for (int i = 0; i < Arr_1.Length; i++)
            {
                Que_1.Enqueue(Arr_1[i]);
            }

            foreach (var item in Que_1)
            {
                Console.WriteLine(item);
            }

            bool isFound_1 = Que_1.Contains(x);
            Console.WriteLine(isFound_1 + "\n");
            Console.WriteLine($"4 задание:");
            ObservableCollection<Boss> students = new ObservableCollection<Boss>();

            students.CollectionChanged += Deal;

            for (int i = 0; i < 4; i++)
            {
                students.Add(new Boss(Convert.ToString(rand.Next(0, 255))));
            }
            students.Remove(new Boss(Convert.ToString(rand.Next(0, 255))));
        }
    }
}
