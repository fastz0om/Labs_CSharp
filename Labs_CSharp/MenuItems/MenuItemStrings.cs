using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Labs_CSharp.MenuItems
{
    //Элемент меню "Strings"
    public class MenuItemStrings : MenuItemTemplate
    {
        //Заголовок меню "Strings"
        public override string Title { get { return "Strings"; } }

        //Основной метод меню "Strings"
        public override void Execute()
        {
            Console.WriteLine("Введите первую строку:");
            string sOneString = Console.ReadLine();
            Console.WriteLine("Введите вторую строку:");
            string sTwoString = Console.ReadLine();
            Console.WriteLine("Результаты проверок:");
            IsMatch(sOneString, sTwoString);
            IsMatchAfterProcessing(sOneString, sTwoString);
            IsPalingrome(sOneString, sTwoString);
            if (IsEmail(sOneString) || IsIPAddress(sOneString) || IsPhoneNumber(sOneString))
            {
                Console.WriteLine("Строка №1 является специальной строкой (Email, IP адрес, тел. номер)");
            }
            else
            {
                Console.WriteLine("Строка №1 не является специальной строкой (Email, IP адрес, тел. номер)");
            }
            if (IsEmail(sTwoString) || IsIPAddress(sTwoString) || IsPhoneNumber(sTwoString))
            {
                Console.WriteLine("Строка №2 является специальной строкой (Email, IP адрес, тел. номер)");
            }
            else
            {
                Console.WriteLine("Строка №2 не является специальной строкой (Email, IP адрес, тел. номер)");
            }
        }

        //Метод, проверяющий, совпадают ли две строки.
        private bool IsMatch(string oneString, string twoString)
        {
            if (oneString.Equals(twoString))
            {
                Console.WriteLine("Строки совпадают.");
                return true;
            }
            Console.WriteLine("Строки не совпадают.");
            return false;
        }

        //Метод, проверяющий совпадают ли строки, после обработки:
        //(удаленные пробелы в начале и конце, единый регистр, отсутствие двойных пробелов)
        private bool IsMatchAfterProcessing(string oneString, string twoString)
        {
            oneString = oneString.ToLower().Trim().Replace("  ", " ");
            twoString = twoString.ToLower().Trim().Replace("  ", " ");
            if (oneString.Equals(twoString))
            {
                Console.WriteLine("Отформатированные строки совпадают.");
                return true;
            }
            Console.WriteLine("Отформатированные строки не совпадают.");
            return false;
        }

        //Метод, проверяющий, является ли строка перевертышом к другой строке
        private bool IsPalingrome(string oneString, string twoString)
        {
            if (oneString.Length != twoString.Length)
            {
                Console.WriteLine("Первая строка не является перевертышом ко второй.");
                return false;
            }

            int min = 0;
            int max = oneString.Length - 1;
            while (true)
            {
                if (min > max)
                {
                    Console.WriteLine("Первая строка является перевертышом ко второй.");
                    return true;
                }
                char a = oneString[min];
                char b = twoString[max];
                if (char.ToLower(a) != char.ToLower(b))
                {
                    Console.WriteLine("Первая строка не является перевертышом ко второй.");
                    return false;
                }
                min++;
                max--;
            }
        }

        //Метод, проверяющий, является ли строка электронной почтой.
        private bool IsEmail(string inputString)
        {
            Regex rgx = new Regex(@"^[a-zA-Z0-9]+[@][a-zA-Z]+\.[c,o,m,r,u]{2,3}$");
            if (rgx.IsMatch(inputString))
            {
                return true;
            }
            return false;
        }

        //Метод, проверяющий является ли строка IP адресом.
        private bool IsIPAddress(string inputString)
        {
            Regex rgx = new Regex(@"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$");
            if (rgx.IsMatch(inputString))
            {
                return true;
            }
            return false;
        }

        //Метод, проверяющий является ли строка телефонным номером.
        //Используется проверка согласно международному формату: +7 XXX XXX-XX-XX (Например: +7 123 456-78-90)
        private bool IsPhoneNumber(string inputString)
        {
            Regex rgx = new Regex(@"^\+7 \d{3} \d{3}-\d{2}-\d{2}$");
            if (rgx.IsMatch(inputString))
            {
                return true;
            }
            return false;
        }
    }
}
