using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu.ClearMenuItems();
            Menu.AddMenuItem(new MenuItems.MenuItemExit());
            Menu.AddMenuItem(new MenuItems.MenuItemHelloWorld());
            Menu.AddMenuItem(new MenuItems.MenuItemCalculator());
            Menu.AddMenuItem(new MenuItems.MenuItemData());
            
            while (true)
            {
                Menu.Execute();
            }
        }
    }
}
