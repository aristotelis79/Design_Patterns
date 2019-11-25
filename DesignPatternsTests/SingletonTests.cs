using Autofac;
using DesignPatterns;
using NUnit.Framework;

namespace DesignPatternsTests
{

    [TestFixture]
    public class SingletonTests
    {
        [Test]
        public void DIPopulationTest()
        {
            var cb = new ContainerBuilder();
            cb.RegisterType<OrdinaryDatabase>().As<IDatabase>().SingleInstance();
            cb.RegisterType<ConfigurableRecordFinder>();
            using (var c = cb.Build())
            {
                var rf = c.Resolve<ConfigurableRecordFinder>();
            }
        }

        [Test]
        public void IsSingletonTest()
        {
            var db1 = SingletonDatabase.Instance;
            var db2 = SingletonDatabase.Instance;
            Assert.That(db1, Is.SameAs(db2));
            Assert.That(SingletonDatabase.Count, Is.EqualTo(1));

        }

        [Test]
        public void SingletonTotalPopulationTest()
        {
            var rf = new SingletonRecordFinder();
            var names = new[] { "Seoul", "Mexico City" };
            var tp = rf.GetTotalPopulation(names);
            Assert.That(tp, Is.EqualTo(1750000 + 1740000));

        }

        
        [Test]
        public void ConfigurablePopulationTest()
        {
            var rf = new ConfigurableRecordFinder(new DummyDatabase());
            var names = new[] {"alpha", "gamma"};
            var tp = rf.GetTotalPopulation(names);
            Assert.That(tp, Is.EqualTo(4));

        }
    }
}