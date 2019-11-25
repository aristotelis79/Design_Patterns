using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MoreLinq;


namespace DesignPatterns
{

    public interface IDatabase
    {
        int GetPopulation(string name);
    }

    public class SingletonDatabase : IDatabase
    {
        private readonly Dictionary<string, int> _capitals;
        private static int _instanceCount = 0;
        public static int Count => _instanceCount;
        private static readonly Lazy<SingletonDatabase> _instance = new Lazy<SingletonDatabase>(() => new SingletonDatabase());

        public static SingletonDatabase Instance = _instance.Value;

        private SingletonDatabase()
        {
            Console.WriteLine("Init database");
            _instanceCount++;
            _capitals = File.ReadAllLines(//"capitals.txt")
                                            Path.Combine(new FileInfo(typeof(IDatabase).Assembly.Location).DirectoryName, "capitals.txt"))
                            .Batch(2)
                            .ToDictionary(
                                            list => list.ElementAt(0).Trim(),
                                            list => int.Parse(list.ElementAt(1))
                                        );
        }

        public int GetPopulation(string name)
        {
            return _capitals[name];
        }
    }

    public class SingletonRecordFinder
    {
        public int GetTotalPopulation(IEnumerable<string> names)
        {
            return names.Sum(name => SingletonDatabase.Instance.GetPopulation(name));
        }
    }

    public class ConfigurableRecordFinder
    {
        public IDatabase Database { get; }

        public ConfigurableRecordFinder(IDatabase database)
        {
            this.Database = database;
        }

        public int GetTotalPopulation(IEnumerable<string> names)
        {
            return names.Sum(name => SingletonDatabase.Instance.GetPopulation(name));
        }
    }

    public class OrdinaryDatabase : IDatabase
    {
        private readonly Dictionary<string, int> _capitals;

        private OrdinaryDatabase()
        {
            Console.WriteLine("Init database");

            _capitals = File.ReadAllLines(//"capitals.txt")
                    Path.Combine(new FileInfo(typeof(IDatabase).Assembly.Location).DirectoryName, "capitals.txt"))
                .Batch(2)
                .ToDictionary(
                    list => list.ElementAt(0).Trim(),
                    list => int.Parse(list.ElementAt(1))
                );
        }

        public int GetPopulation(string name)
        {
            return _capitals[name];
        }
    }

    public class DummyDatabase : IDatabase
    {
        public int GetPopulation(string name)
        {
            return new Dictionary<string, int>
            {
                ["alpha"] =1,
                ["beta"] = 2,
                ["gamma"] = 3
            }[name];
        }
    }
}