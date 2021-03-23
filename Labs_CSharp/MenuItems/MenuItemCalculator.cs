using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_CSharp.MenuItems
{
    //Структура для аргумента
    struct Argument
    {
        //Значение аргумента
        public int iValue;
        //Описание аргумента
        public string sDeskription;
    }


    //Класс меню "Calc"
    public class MenuItemCalculator : MenuItemTemplate
    {
        //Текущая формула
        private string _formula = "X/Z+Y^2";

        //Аргументы для расчета формулы
        private Argument g_aX = new Argument { sDeskription = "X" };
        private Argument g_aY = new Argument { sDeskription = "Y" };
        private Argument g_aZ = new Argument { sDeskription = "Z" };
        //    private Argument g_aX, g_aY, g_aZ;

        public string Formula { get { return _formula; } set { _formula = value; } }

        // Заголовок меню "Calculator"
        public override string Title { get { return "Calc: " + _formula; } }

        //Основной метод меню "Calc"
        public override void Execute()
        {
            Console.WriteLine("Расчет по формуле {0}", _formula);
            Console.WriteLine("Для расчета пожалуйста через пробел введите аргументы X,Y,Z: ");
            string[] sArguments = Console.ReadLine().Split(' ');
            double dResult = 0.0;
            if (!CheckingArguments(sArguments))
            {
                bool bIsCurrent = false;
                while (!bIsCurrent)
                {
                    sArguments = Console.ReadLine().Split(' ');
                    bIsCurrent = CheckingArguments(sArguments);
                }
                dResult = Calculation();
            }
            else
            {
                dResult = Calculation();
            }
            Console.WriteLine("Ответ: {0:f3}", dResult);
        }

        //Метод проверки аргументов
        private bool CheckingArguments(string[] arguments)
        {
            //Проверка на необходимое кол-во аргументов
            if (arguments.Length != 3 || string.IsNullOrEmpty(arguments[0]) || string.IsNullOrEmpty(arguments[1]) || string.IsNullOrEmpty(arguments[2]))
            {
                Console.WriteLine("ОШИБКА: Неверное кол-во аргументов. Повторите попытку!");
                return false;
            }

            CheckCorrectValue(arguments[0], g_aX.sDeskription, out g_aX.iValue);
            CheckCorrectValue(arguments[1], g_aY.sDeskription, out g_aY.iValue);
            CheckCorrectValue(arguments[2], g_aZ.sDeskription, out g_aZ.iValue);
            return true;
        }

        //Общая проверка аргументов на корректность (не являются ли строками или нулем (Z))
        private void CheckCorrectValue(string value, string argDeskription, out int rResult)
        {
            string sTemp = value;
            bool bIsCorrect = false;
            int iTempResult = 0;
            while (!bIsCorrect)
            {
                bIsCorrect = isNotNumber(sTemp, argDeskription);
                if (bIsCorrect)
                {
                    iTempResult = Int32.Parse(sTemp);
                    if (argDeskription.Equals("Z"))
                        bIsCorrect = isNotZero(iTempResult);
                }
                if (!bIsCorrect)
                    sTemp = Console.ReadLine();
            }
            rResult = iTempResult;

        }

        //Проверка на ноль
        private bool isNotZero(int a)
        {
            if (a.Equals(0))
            {
                Console.WriteLine("ОШИБКА: Аргумент Z не может быть равен нулю! Повторите попытку: ");
                return false;
            }
            return true;
        }

        //Провекра на число
        private bool isNotNumber(string value, string description)
        {
            if (!Int32.TryParse(value, out int num))
            {
                Console.WriteLine("ОШИБКА: Аргумент {0} не является числом! Повторите попытку: ", description);
                return false;
            }
            return true;
        }

        //Расчет по формуле
        private double Calculation()
        {
            return (double)g_aX.iValue / g_aZ.iValue + Math.Pow(g_aY.iValue, 2);
        }

    }
}
