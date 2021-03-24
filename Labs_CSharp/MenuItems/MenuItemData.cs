using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Labs_CSharp.MenuItems
{
    //Структура для хранения отрезков дат
    struct DateSection
    {
        public DateTime startDate;
        public DateTime finalDate;
    }

    //Класс меню "Data"
    public class MenuItemData : MenuItemTemplate
    {
        //Заголовок меню "Data"
        public override string Title { get { return "Recursion date"; } }


        //Основной метод меню "Data"
        public override void Execute()
        {
            Console.WriteLine("Введите отрезок первой даты (Пример: 01.02.2003-04.05.2006):");
            DateSection dateSectionOne = DateSectionInput();
            Console.WriteLine("Введите отрезок второй даты (Пример: 01.02.2003-04.05.2006):");
            DateSection dateSectionTwo = DateSectionInput();

            int iPeriod = GetPeriod(dateSectionOne, dateSectionTwo);
            if (IsNotBigNumber(iPeriod))
                Console.WriteLine("Период: {0} \nРезультат выполнения функции Аккермана: {1}", iPeriod, AckermanFunc(iPeriod));
        }

        //Метод, осущесвтляющий проверку отрезка даты на соответствие заданному шаблону
        private bool IsCurrentDateSection(string dateSection)
        {
            Regex rgx = new Regex(@"^\d{2}.\d{2}.\d{4}-\d{2}.\d{2}.\d{4}$");
            if (rgx.IsMatch(dateSection))
            {
                return true;
            }
            Console.WriteLine("ОШИБКА: Введенный отрезок не соответствует заданному шаблону! Повторите попытку:");
            return false;
        }

        //Метод, осуществляющий проверку отрезка даты на соответствие: ДатаНачала<ДатыКонца
        private bool IsNormalDataSection(DateTime startDate, DateTime finalDate)
        {
            if (DateTime.Compare(finalDate, startDate) == 1)
            {
                return true;
            }
            Console.WriteLine("ОШИБКА: Конечная дата меньше начальной! Повторите попытку:");
            return false;
        }

        //Метод, осуществляющий проверку на корректность периода, в соответствии с условием: Период <= X, 
        //где X=4 т.к. при больших значениях происходит переполнение буфера
        private bool IsNotBigNumber(int m)
        {
            if (m >= 4)
            {
                Console.WriteLine("ОШИБКА: Полученный период (N={0}) больше допустимого значения (4)!", m);
                return false;
            }
            return true;
        }

        //Метод, считытывания и обработки введенных в консоль данных.
        private DateSection DateSectionInput()
        {
            bool bIsSuccess = false;
            DateSection dataSection = new DateSection();
            while (!bIsSuccess)
            {
                string sDateSection = Console.ReadLine();
                bIsSuccess = IsCurrentDateSection(sDateSection);
                if (bIsSuccess)
                {
                    string[] sDateArr = sDateSection.Split('-');
                    DateTime dateStart = DateTime.Parse(sDateArr[0]);
                    DateTime dateFinal = DateTime.Parse(sDateArr[1]);
                    bIsSuccess = IsNormalDataSection(dateStart, dateFinal);
                    if (bIsSuccess)
                    {
                        dataSection.startDate = dateStart;
                        dataSection.finalDate = dateFinal;
                    }
                }
            }
            return dataSection;
        }

        //Расчет периода между двумя отрезками
        private int GetPeriod(DateSection dateSectionOne, DateSection dateSectionTwo)
        {
            DateTime startPeriodDate = DateTime.Compare(dateSectionOne.startDate, dateSectionTwo.startDate) == 1 ? dateSectionOne.startDate : dateSectionTwo.startDate;
            DateTime finalPeriodDate = DateTime.Compare(dateSectionOne.finalDate, dateSectionTwo.finalDate) == -1 ? dateSectionOne.finalDate : dateSectionTwo.finalDate;
            /*            if ((start == dateSectionOne.startDate && end == dateSectionOne.finalDate) || (start == dateSectionTwo.startDate && end == dateSectionTwo.finalDate))
                        {
                            return 0;
                        }*/
            //  else
            return ((finalPeriodDate - startPeriodDate).Days + 1) >= 0 ? ((finalPeriodDate - startPeriodDate).Days + 1) : 0;

        }

        //Реализация функции Аккермана
        private int AckermanFunc(int m, int n = 5)
        {

            if (m == 0)
                return n + 1;
            else if ((m >= 0) && (n == 0))
                return AckermanFunc(m - 1, 1);
            else
                return AckermanFunc(m - 1, AckermanFunc(m, n - 1));
        }
    }
}
