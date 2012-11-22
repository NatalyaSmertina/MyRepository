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
            Console.WriteLine("Выберите вариант работы с программой: ");
            Console.WriteLine("Для работы с таблицой User нажмите кнопку 1");
            Console.WriteLine("Для работы с таблицой Machine нажмите кнопку 2");
            Console.WriteLine("Для выхода из консоли нажмите 0");

            string userChoice = Console.ReadLine();
            int userChoiceInt = Convert.ToInt32(userChoice);
            DatabaseManager databaseManager = new DatabaseManager();

            switch (userChoiceInt)
            { 
                case 0 :
                    return;
                case 1 :
                    databaseManager.CountAverageWinSpent();
                    break;
                case 2 :
                    databaseManager.ShowMashineTitles();
                    break;
                default: break;            
            }
            Console.ReadKey();
        }
    }
}

