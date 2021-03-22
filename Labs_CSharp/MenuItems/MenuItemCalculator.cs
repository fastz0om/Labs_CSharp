using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_CSharp.MenuItems
{
    //Класс меню "Calc"
    public class MenuItemCalculator : MenuItemTemplate
    {
        //Текущая формула
        private string _formula = "x+y+z";

        //Аргументы для расчета формулы
        private int _x, _y, _z;

        public string Formula { get { return _formula; } set { _formula = value; } }

        // Заголовок меню "Calculator"
        public override string Title { get { return "Calc: " + _formula; } }

        //Основной метод меню "Calc"
        public override void Execute()
        {
            Console.WriteLine("Расчет по формуле {0}", _formula);
            Console.WriteLine("Для расчета пожалуйста через пробел введите аргументы X,Y,Z: ");
            string[] strArgs = Console.ReadLine().Split(' ');
            double res = 0.0;
            if (!CheckingArguments(strArgs))
            {
                bool checkIs = false;
                while (!checkIs)
                {
                    strArgs = Console.ReadLine().Split(' ');
                    checkIs = CheckingArguments(strArgs);
                }
                res = Calculation();
            }
            else
            {
                res = Calculation();
            }
            Console.WriteLine("Ответ: {0:f3}", res);
        }

        //Метод проверки аргументов на корректность
        private bool CheckingArguments(string[] arguments)
        {
            //Проверка на необходимое кол-во аргументов
            if (arguments.Length != 3 || string.IsNullOrEmpty(arguments[0]) || string.IsNullOrEmpty(arguments[1]) || string.IsNullOrEmpty(arguments[2]))
            {
                Console.WriteLine("ОШИБКА: Неверное кол-во аргументов. Повторите попытку!");
                return false;
            }

            CheckingX(arguments[0]);
            CheckingY(arguments[1]);
            CheckingZ(arguments[2]);
            return true;
        }

        //Проверка аргумента X
        private void CheckingX(string x)
        {
            if (!Int32.TryParse(x, out _x))
            {
                string xTemp = x;
                while (!Int32.TryParse(xTemp, out _x))
                {
                    Console.WriteLine("ОШИБКА: Некорректно задан аргумент X! Введите аргумент X: ");
                    xTemp = Console.ReadLine();
                }
            }
        }


        //Проверка аргумента Y
        private void CheckingY(string y)
        {
            if (!Int32.TryParse(y, out _y))
            {
                string yTemp = y;
                while (!Int32.TryParse(yTemp, out _y))
                {
                    Console.WriteLine("ОШИБКА: Некорректно задан аргумент Y! Введите аргумент Y: ");
                    yTemp = Console.ReadLine();
                }
            }
        }

        //Проверка аргумента Z
        private void CheckingZ(string z)
        {
            if (!Int32.TryParse(z, out _z))
            {
                string zTemp = z;
                while (!Int32.TryParse(zTemp, out _z))
                {
                    Console.WriteLine("ОШИБКА: Некорректно задан аргумент Z! Введите аргумент Z: ");
                    zTemp = Console.ReadLine();
                }
            }
        }

        //Рассчет по формуле
        private double Calculation()
        {
            //  return _x * _y % _z;
            return _x + _y + _z;
        }

    }
}
