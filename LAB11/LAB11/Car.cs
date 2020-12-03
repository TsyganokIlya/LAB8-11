using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using LAB11;

namespace LAB3
{
    public partial class Car
    {
        private readonly long id; //rand
        private string _marka;    //rand
        private string _model;   //BMW
        private string _model1;   //BMW
        private string _model2;   //Ferrari
        private string _model3;   //Nissan
        private DateTime _year;   //not rand
        private string _color;    //rand
        private long _price;      //not rand
        private string _CarNumber;//rand  
        private static string[] _availableMarka;
        private static string[] _model1_1;
        private static string[] _model2_2;
        private static string[] _model3_3;
        private static string[] _availablecolor;
        public static int count;


        public string CarNumber
        {
            get
            {
                return _CarNumber;
            }
            set
            {
                if (Program.nCarNumber.IsMatch(value))
                {
                    _CarNumber = value;
                }
                if (_CarNumber == null)
                {
                    _marka = null;
                }
            }
        }
        public string Marka
        {
            get
            {
                return _marka;
            }
            set
            {
                if (_availableMarka.Contains(value))
                {
                    _marka = value;
                }
            }

        }
        public string Model1
        {
            get
            {
                return _model1;
            }
            set
            {
                if (_model1_1.Contains(value))
                {
                    _model1 = value;
                }
            }
        }
        public string Model2
        {
            get
            {
                return _model2;
            }
            set
            {
                if (_model2_2.Contains(value))
                {
                    _model2 = value;
                }
            }
        }
        public string Model3
        {
            get
            {
                return _model3;
            }
            set
            {
                if (_model3_3.Contains(value))
                {
                    _model3 = value;
                }
            }
        }
        public string Color
        {
            get
            {
                return _color;
            }
            set
            {
                if (_availablecolor.Contains(value))
                {
                    _color = value;
                }
            }
        }
        public long Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }
        public int GetAge()
        {
            return DateTime.Now.Year - year.Year;
        }
        Car(long seed = 21414141)
        {
            id = seed.GetHashCode();
            count++;
        }
        public DateTime year
        {
            get { return _year; }
            set { _year = value; }
        }

        ~Car() => count--;
        static Car()
        {
            _availableMarka = new string[] { "BMW", "Ferrari", "Nissan" };
            _model1_1 = new string[] { "M4", "M5", "M3", "X5" };
            _model2_2 = new string[] { "F430", "458 Italia", "F12 Berlinetta" };
            _model3_3 = new string[] { "Silvia V", "Skyline R33", "GTR" };
            _availablecolor = new string[] { "Красный", "Синий", "Желтый", "Черный", "Белый", "Зеленый", "Оранжевый" };
        }
        public Car() : this(DateTime.Now.Millisecond)
        {
            Marka = _availableMarka[Program.rand.Next(_availableMarka.Length)];
            Model1 = _model1_1[Program.rand.Next(_model1_1.Length)];
            Model2 = _model2_2[Program.rand.Next(_model2_2.Length)];
            Model3 = _model3_3[Program.rand.Next(_model3_3.Length)];
            Color = _availablecolor[Program.rand.Next(_availablecolor.Length)];
            Price = Program.rand.Next(1, 15);
            _year = new DateTime(year: Program.rand.Next(1989, DateTime.Now.Year - 1),
                                 month: Program.rand.Next(1, 12),
                                 day: Program.rand.Next(1, 30));
        }

        public override string ToString()
        {
            if (_CarNumber != null)
            {
                if (_marka == "BMW")
                {
                    _model = _model1;
                }
                if (_marka == "Ferrari")
                {
                    _model = _model2;
                }
                if (_marka == "Nissan")
                {
                    _model = _model3;
                }
                return $"[{CarNumber}] {_color}\t{_price} млн. ||\t{_marka}\t {_model}\t{_year.ToShortDateString()}";

            }
            return _CarNumber;
        }
    }
}