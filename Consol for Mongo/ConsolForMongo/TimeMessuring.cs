using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsolForMongo
{
    public static class TimeMessuring
    {
        private static DateTime _startTime;

        public static void StartTime()
        {
            _startTime = DateTime.Now;
        }

        public static void EndTime()
        {
            Console.WriteLine(string.Format("Время запроса и вывода в консоль: {0}", DateTime.Now - _startTime));
        }
    }
}
