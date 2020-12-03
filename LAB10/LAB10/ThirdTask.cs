using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdTask
{
    public abstract class Organization
    {
        public string Name { get; set; }
        public Organization(string name)
        { Name = name; }
    }
    public class Org : Organization
    {
        public int Number { get; set; }
        public string DocName { get; set; }
        public Org(string name, int number) : base(name)
        {
            Number = number;
            DocName = Name;
        }
    }
    public class One : Org
    {
        public string Pay_LName { get; set; }
        public double Sum { get; set; }
        public One(string name, int number, string Pay_LName, double Sum) : base(name, number)
        {
            this.Pay_LName = Pay_LName;
            this.Sum = Sum;
        }
    }
    public class Two : Org
    {
        public double Amount { get; set; }
        public string To_Whom { get; set; }
        public Two(string name, int number, double amount, string to_whom) : base(name, number)
        {
            Amount = amount;
            To_Whom = to_whom;
        }
    }
}