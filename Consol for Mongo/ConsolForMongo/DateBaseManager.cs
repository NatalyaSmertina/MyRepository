using MongoDB.Bson;

using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections;
using System.Collections.Generic;


namespace ConsolForMongo
{
    public class DatabaseManager
    {
        //Learn:
        //1.Read about lazy loading conception.

        private const string _userName = "slots_test";
        private const string _password = "hbnvuii2u4jh31j23bnbn";
        private const string _hostPort = "213.239.218.139:27017";
        private const string _databaseName = "slots_test";
        private const string _machineItemName = "title";
        private const string _groupItem = "level";
        private MongoCollection<BsonDocument> _collection;
        private string _connectionString 
        {
            get {return string.Format("mongodb://{0}:{1}@{2}/{3}", _userName, _password, _hostPort, _databaseName);}
        }

        private IEnumerable<BsonValue> _levelNumbers { get; set; }
        private List<int> _levelNumbersList;
        private MongoCursor<BsonDocument> _statisticItemSet { get; set; }
        private string _collectionName { get; set; }
        private MongoDatabase _database;
        private MongoServer _server;
        
        public DatabaseManager()
        {
            _server = MongoServer.Create(_connectionString);
            _database = _server.GetDatabase(_databaseName);
        }

        private void IdentifyAnyCollection(string collectionNameToCreat)
        { 
            _collectionName = collectionNameToCreat;
            _collection = _database.GetCollection(_collectionName);
        }

        private void SortLevelNumbers()
        {
            _levelNumbersList = new List<int>();
            foreach (BsonValue levelNumber in _levelNumbers)
            {
                _levelNumbersList.Add(levelNumber.AsInt32);
            }
            _levelNumbersList.Sort();
        }

        private void MachineTitleFieldFinder()
        {
            Console.Write("\nОптимальный способ:\n\n");
            foreach (BsonDocument item in _collection.FindAll().SetFields(Fields.Exclude("_id").Include(_machineItemName)))
            {
                Console.WriteLine(item[_machineItemName]);
            }

        }
        
        private void MachineAllFieldsFinder()
        {
            Console.WriteLine("\nНе оптимальный способ:\n\n");
            foreach (BsonDocument item in _collection.FindAll())
            {
                Console.WriteLine(item[_machineItemName]);
            }
        }

        public void CountAverageWinSpent()
        {

            IdentifyAnyCollection("user");
            _levelNumbers = _collection.Distinct(_groupItem);
            _statisticItemSet = _collection.FindAll().SetFields(Fields.Exclude("_id").Include("statistics.money_spent"
                                                                                            , "statistics.total_win", "level"));
            Console.WriteLine(string.Format("Имя обрабатываемой таблицы: {0}", _collectionName));
            SortLevelNumbers();
            double averageForGroup = 0d;
            int countUsersInGroup = 0;
            foreach (int levelNumber in _levelNumbersList)
            {
                countUsersInGroup = 0;
                averageForGroup = 0d;
                foreach (BsonDocument statisticItem in _statisticItemSet)
                {
                    if (statisticItem[_groupItem].AsInt32 == levelNumber)
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
                Console.WriteLine("\n Отношение выигрыша к затратам на уровне {0} составляет {1} %",
                    levelNumber, (averageForGroup == 0d ? 0d : averageForGroup / countUsersInGroup) * 100);

            }
        }

        public void ShowMashineTitles()
        {
            IdentifyAnyCollection("machine");
            TimeMessuring.StartTime();
            MachineTitleFieldFinder();
            TimeMessuring.EndTime();

            TimeMessuring.StartTime();
            MachineAllFieldsFinder();
            TimeMessuring.EndTime();
        }

    }
}
