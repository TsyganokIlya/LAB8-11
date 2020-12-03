using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB9
{
    public delegate void BMet(string mes);
    public class Boss
    {
        public event BMet Amerce;
        public event BMet Enhancement;
        public int _salary;
        public Boss(int salary) => _salary = salary;
        public int CSalary { get => _salary;  }
        public void DownSalary(int amrc)
        {
            if(_salary == 0)
            {
                Amerce?.Invoke($"Куда еще один штраф?!");
            }
            else
            {
                if ((_salary - amrc) < 0)
                {
                    _salary = 0;
                    Amerce?.Invoke($"Вас оштрафовали на {amrc} руб. ||\tЗарплата:{_salary} руб.");
                }
                else
                {
                    _salary -= amrc;
                    Amerce?.Invoke($"Вас оштрафовали на {amrc} руб. ||\tЗарплата:{_salary} руб.");
                }
            }
        }

        public void UpSalary(int enh)
        {
            _salary += enh;
            Enhancement?.Invoke($"Поздравляю, вам повысили зарплату на {enh} руб. ||\tЗарплата:{_salary} руб.");
        }
    }

    public static class STRING
    {
        public static string Method(this string str, Func<string, string> func) => func.Invoke(str);
        public static string Method(this string str, Func<string, int, string> func, int pos) => func.Invoke(str, pos);
    }

    class Program
    {
        private static void Display(string mes) => Console.WriteLine(mes);
        static void Operation(string strO, string strT, Action<string, string> oper)
        {
            if (strO != strT)
                oper(strO, strT);
        }

        static void Main(string[] args)
        {
            Boss boss_1 = new Boss(1000);
            Boss boss_2 = new Boss(100);
            Boss boss_3 = new Boss(0);

            boss_1.Amerce += Display;
            boss_1.Enhancement += Display;

            boss_2.Amerce += Display;
            boss_2.Enhancement += Display;

            boss_3.Amerce += Display;
            boss_3.Enhancement += Display;

            boss_1.DownSalary(250);
            boss_1.UpSalary(1000);
            Console.WriteLine();

            boss_2.DownSalary(250);
            boss_2.UpSalary(1000);
            Console.WriteLine();

            boss_3.DownSalary(250);
            boss_3.UpSalary(1000);
            Console.WriteLine();

            Action<string, string> oper;

            Func<string, string> removeLowerCase = s => s.ToUpper();
            Func<string, string> removeUpperCase = s => s.ToLower();
            Func<string, int, string> removeIndex = (s, i) => s.Remove(i, 1);

            string str = "HelloWorld";

            Console.WriteLine(str.Method(removeLowerCase));
            Console.WriteLine(str.Method(removeUpperCase));
            Console.WriteLine(str.Method(removeIndex, 2));
        }
    }
}
