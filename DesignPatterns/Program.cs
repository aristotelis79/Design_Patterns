using System;
using System.Collections.Generic;


namespace DesignPatterns
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region OpenClosePrinicple
            var apple = new OpenClosedPrinciple.Product("Apple", OpenClosedPrinciple.Color.Green, OpenClosedPrinciple.Size.Small);
            var tree = new OpenClosedPrinciple.Product("Tree", OpenClosedPrinciple.Color.Green, OpenClosedPrinciple.Size.Large);
            var house = new OpenClosedPrinciple.Product("House", OpenClosedPrinciple.Color.Blue, OpenClosedPrinciple.Size.Large);

            var products = new List<OpenClosedPrinciple.Product>() { apple, tree, house };

            var fp = new OpenClosedPrinciple.FilterProducts();
            Console.WriteLine("Green products:");
            var gp = fp.Filter(products, new OpenClosedPrinciple.Specification(OpenClosedPrinciple.Size.Large));
            foreach (var p in gp)
            {
                Console.WriteLine($" - {p.Name} is Large");
            }

            var fps = new OpenClosedPrinciple.FilterProducts();
            Console.WriteLine("Green products an large:");

            var lp = new List<OpenClosedPrinciple.ISpecification<OpenClosedPrinciple.Product>> { new OpenClosedPrinciple.Specification(OpenClosedPrinciple.Size.Large), new OpenClosedPrinciple.Specification(OpenClosedPrinciple.Color.Green) };
            var gps = fp.Filters(products, lp);
            foreach (var p in gps)
            {
                Console.WriteLine($" - {p.Name} is green and large");
            }
            #endregion


            #region FluentBuilder

            var me = FluentBuilder.Person.New.Called("Aris").WorkAsA("superstart");

            Console.WriteLine(me);

            #endregion


            #region FacetedBuilder

            var pb = new FacetedBuilder.PersonBuilder();
            FacetedBuilder.Person person = pb.Lives.At("street")
                                  .In("Madrid")
                                  .WithPostcode("100")
                            .Works.At("Nilsen")
                                  .AsA("CEO")
                                  .Earning(1000000);

            Console.WriteLine(person);
            #endregion


            #region Factory

            var point = Point.Factory.NewPolarPoint(1, 3);

            #endregion


            #region AbstractFactory

            //var machine = new HotDrinkMachine();
            //var drink = machine.MakeDrink(HotDrinkMachine.AvailableDrink.Tea, 100);
            #endregion


            #region AbstractFactoryWithOCP

            //var machineOpc = new HotDrinkMachineOPC();

            //var drinkOpc = machineOpc.MakeDrink();
            
            //drinkOpc.Consume();

            #endregion

            #region Prototype

            var john = new Person(new []{"John", "Smith"}, new Address("London Road", 123));

            var jane = john.DeepCopy();
            jane.Names = new[] {"Jane", "Smith"};
            Console.WriteLine(john);
            Console.WriteLine(jane);

            #endregion

            Console.ReadLine();

        }
    }
}