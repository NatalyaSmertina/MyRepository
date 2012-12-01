using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ConsolForMongo
{

    class Program
    {
        public static void Main(string[] args)
        {
            int userChoiceInt;
            Console.WriteLine("Выберите вариант работы с программой: ");
            Console.WriteLine("Для работы с таблицой User нажмите кнопку 1");
            Console.WriteLine("Для работы с таблицой Machine нажмите кнопку 2");
            Console.WriteLine("Для выхода из консоли нажмите 0");
            if (int.TryParse(Console.ReadLine(), out userChoiceInt))
            {
                if (userChoiceInt == 1 || userChoiceInt == 2)
                {
                    DatabaseManager databaseManager = new DatabaseManager();

                    if (userChoiceInt == 1)
                    {
                        databaseManager.CountAverageWinSpent();
                    }
                    else if (userChoiceInt == 2)
                    {
                        databaseManager.ShowMashineTitles();
                    }
                }
                else if (userChoiceInt == 0)
                {
                    Console.WriteLine("Выход");
                    return;
                }
                else
                    Console.WriteLine("Не выбран ни один из предложенных вариантов");
            }
            else
                Console.WriteLine("Введена неверная последовательность символов");
            Console.ReadKey();
        }
    }
}

