using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_CSharp.MenuItems
{
    //Элемент меню "Hello World"
    public class MenuItemHelloWorld : MenuItemTemplate
    {
        //Заголовок меню "Hello World"
        public override string Title { get{ return "Hello World!"; } }

        //Основной метод меню "Hello World"
        public override void Execute()
        {
            Console.WriteLine("Hello world!");
        }
    }
}
