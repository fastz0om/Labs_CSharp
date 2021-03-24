using Labs_CSharp.MenuItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_CSharp

{
    //Класс меню
    public class Menu
    {
        //Список элементов меню
        private static List<MenuItemTemplate> MenuItems = new List<MenuItemTemplate>();

        //Добавить элемент в меню
        public static void AddMenuItem(MenuItemTemplate menuItem)
        {
            MenuItems.Add(menuItem);
        }

        //Удалить все элементы меню
        public static void ClearMenuItems()
        {
            MenuItems.Clear();
        }

        //Удалить конкретный элемент меню
        public static void RemoveMenuItem(MenuItemTemplate menuItem)
        {
            if (MenuItems.Contains(menuItem))
                MenuItems.Remove(menuItem);
        }

        //Основной метод, выполняющий полезную работу
        public static void Execute()
        {
            ShowMenu();
            int iValue = CheckingInt();
            switch (iValue)
            {
                case 0:
                    MenuItems[0].Execute();
                    break;
                case 1:
                    MenuItems[1].Execute();
                    break;
                case 2:
                    MenuItems[2].Execute();
                    break;
                case 3:
                    MenuItems[3].Execute();
                    break;
                default:
                    Console.WriteLine("ОШИБКА: Не существует элемента меню под указанным номером ({0})! Пожалуйста повторите попытку!", iValue);
                    break;
            }
        }

        //Метод, для отображения меню
        private static void ShowMenu()
        {
            Console.WriteLine("========= MENU =========");

            int iMenuItem = 0;
            foreach (MenuItemTemplate menuItem in MenuItems)
            {
                Console.WriteLine("[{0}] {1}", iMenuItem++, menuItem.Title);
            }
        }

        //Метод, осуществляющий проверку на корректность введённого элемента меню.
        private static int CheckingInt()
        {
            while (true)
            {
                string sValue = Console.ReadLine();
                if (Int32.TryParse(sValue, out int iValue))
                {
                    return iValue;
                }
                else
                {
                    Console.WriteLine("ОШИБКА: Некорректный формат введённых данных! Пожалуйста повторите попытку!");
                    ShowMenu();
                }
            }
        }


    }
}
