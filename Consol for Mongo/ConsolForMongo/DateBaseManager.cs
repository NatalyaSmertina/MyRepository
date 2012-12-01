using MongoDB.Bson;

using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace ConsolForMongo
{
    public class DatabaseManager
    {
        //Learn:
        //1.Read about lazy loading conception.

        private const string USER_NAME = "slots_test";
        private const string PASSWORD = "hbnvuii2u4jh31j23bnbn";
        private const string HOST_PORT = "213.239.218.139:27017";
        private const string DATABASE_NAME = "slots_test";
        private const string MACHINE_ITEM_NAME = "title";
        private const string GROUP_ITEM = "level";
        private MongoDatabase _database;
        private MongoServer _server;
        private string _connectionString
        {
            get { return string.Format("mongodb://{0}:{1}@{2}/{3}", USER_NAME, PASSWORD, HOST_PORT, DATABASE_NAME); }
        }
  

        private MongoCollection<BsonDocument> GetCollection(string collectionNameToCreat)
        {
           if (_server == null) 
                _server = MongoServer.Create(_connectionString);
            if (_database ==null)
                _database = _server.GetDatabase(DATABASE_NAME);
            return _database.GetCollection(collectionNameToCreat);
        }

        private List<int> GetSortedLevelNumberList(IEnumerable<BsonValue> levelNumbers)
        {
            List<int> levelNumbersList = new List<int>();
            foreach (BsonValue levelNumber in levelNumbers)
            {
                levelNumbersList.Add(levelNumber.AsInt32);
            }
            levelNumbersList.Sort();
            return levelNumbersList;
        }

        private void ShowMachineTitleField_OptimalWay(MongoCollection<BsonDocument> machineCollection)
        {
            Console.Write("\nОптимальный способ:\n\n");
            foreach (BsonDocument item in machineCollection.FindAll().SetFields(Fields.Exclude("_id").Include(MACHINE_ITEM_NAME)))
            {
                Console.WriteLine(item[MACHINE_ITEM_NAME]);
            }

        }

        private void ShowMachineTitleField_NonoptimalWay(MongoCollection<BsonDocument> machineCollection)
        {
            Console.WriteLine("\nНе оптимальный способ:\n\n");
            foreach (BsonDocument item in machineCollection.FindAll())
            {
                Console.WriteLine(item[MACHINE_ITEM_NAME]);
            }
        }

        public void CountAverageWinSpent()
        {
            MongoCollection<BsonDocument> userCollection = GetCollection("user");
            IEnumerable<BsonValue> levelNumbers = userCollection.Distinct(GROUP_ITEM);
            List<BsonDocument> statisticItemSet = userCollection.FindAll().SetFields(Fields.Exclude("_id").
                                                 Include("statistics.money_spent", "statistics.total_win", "level")).ToList();
            Console.WriteLine("Имя обрабатываемой таблицы: {0}", userCollection.Name);
            foreach (int levelNumber in GetSortedLevelNumberList(levelNumbers))
            {
                double averageForGroup = 0d;
                int countUsersInGroup = 0;
                foreach (BsonDocument statisticItem in statisticItemSet)
                {
                    if (statisticItem.ElementCount != 0)
                    {
                        if (statisticItem[GROUP_ITEM].AsInt32 == levelNumber)
                        {
                            double totalWin = statisticItem["statistics"].ToBsonDocument().GetElement("total_win").Value.ToDouble();
                            double totalSpent = statisticItem["statistics"].ToBsonDocument().GetElement("money_spent").Value.ToDouble();
                            if (totalSpent != 0)
                            {
                                averageForGroup += totalWin / totalSpent;
                                countUsersInGroup += 1;
                            }

                        }
                    }

                }
                Console.WriteLine("\n Отношение выигрыша к затратам на уровне {0} составляет {1} %",
                    levelNumber, (averageForGroup == 0d ? 0d : averageForGroup / countUsersInGroup) * 100);

            }
            Console.WriteLine("Работа с таблицей user окончена");
        }

        public void ShowMashineTitles()
        {
            MongoCollection<BsonDocument> machineCollection = GetCollection("machine"); 
            TimeMessuring.StartTime();
            ShowMachineTitleField_OptimalWay(machineCollection);
            TimeMessuring.EndTime();

            TimeMessuring.StartTime();
            ShowMachineTitleField_NonoptimalWay(machineCollection);
            TimeMessuring.EndTime();

            Console.WriteLine("Работа с таблицей machine окончена");
        }

    }
}
