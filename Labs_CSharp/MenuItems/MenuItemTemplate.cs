using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_CSharp.MenuItems
{
    //Абстрактный класс, представляющий собой шаблон меню
    public abstract class MenuItemTemplate
    {
        //Заголовок меню
        public abstract string Title { get; }
        public abstract void Execute();

    }
}
