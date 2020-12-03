using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using LAB3;

namespace LAB11
{
    class Program
    {
        public static Regex nCarNumber = new Regex(@"\d{4}\s\w{2}-[0-9]");
        public static Random rand = new Random(DateTime.Now.Millisecond);
        public static string[] months;
        const string o = " : ";
        static void Main(string[] args)
        {
            string[] summer = { "June", "July", "August" };
            string[] autumn = { "September", "October", "November" };
            string[] winter = { "December", "January", "February" };
            string[] spring = { "March", "April", "May" };
            months = summer.Concat(autumn).Concat(winter).Concat(spring).ToArray();

            Console.Write("\nВведите длину строки: ");
            int n = Convert.ToInt32(Console.ReadLine());
            foreach (var y in from m in months where m.Length >= n select m)
                Console.Write(y + o);

            Console.WriteLine("\n\nВывод летних и зимних месяцев: ");
            foreach (var y in months.Where(x => months.Intersect(summer).Contains(x) || months.Intersect(winter).Contains(x)))
                Console.Write(y + o);

            Console.WriteLine("\n\nВывод месяцев в алфавитном порядке: ");
            Console.WriteLine(string.Join(o, from m in months orderby m select m));

            Console.WriteLine("\nМесяца содержащие буквук 'e' и длиной не менее 4: ");
            Console.WriteLine(string.Join(o, months.Where(x => x.Length >= 4 && x.Contains('e'))));

            List<Car> cars = new List<Car>();
            int count = rand.Next(5, 10);
            for(int i = 0; i < count; i++)
            {
                cars.Add(new Car());
            }
            foreach (var b in from car in cars orderby car.CarNumber select car)
            {
                Console.Write(b + "\n");
            }
            Console.Write("\nВведите срок эксплуатации: ");
            int years = Convert.ToInt32(Console.ReadLine());
            foreach( var b in cars.Where(x => x.GetAge() >= years))
            {
                Console.Write(b + "\n");
            }

            Console.Write("\nВведите месяц начала эксплуатации автомобиля: ");
            int startMonth = Convert.ToInt32(Console.ReadLine());
            foreach (var b in cars.Where(x => x.year.Month == startMonth))
                Console.Write(b + "\n");

            Console.WriteLine("\nГруппировка автомобилей по марке: ");
            foreach (var group in from car in cars group car by car.Marka)
                Console.WriteLine(string.Join("\n", group) + "\n");

            Console.ReadKey();
        }
    }
}
