using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_CSharp.MenuItems
{
    //Элемент меню "Exit"
    public class MenuItemExit : MenuItemTemplate
    {
        //Заголовок меню "Exit"
        public override string Title { get { return "Exit"; } }

        //Основной метод меню "Exit"
        public override void Execute()
        {
            Console.WriteLine("Closing the application");
            Environment.Exit(0);
        }
    }
}
