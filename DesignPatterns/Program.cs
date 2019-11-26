using System;
using System.Collections.Generic;

namespace DesignPatterns
{
    public class Program
    {
        private static void Main(string[] args)
        {

            #region OpenClosePrinicple
            //var apple = new OpenClosedPrinciple.Product("Apple", OpenClosedPrinciple.Color.Green, OpenClosedPrinciple.Size.Small);
            //var tree = new OpenClosedPrinciple.Product("Tree", OpenClosedPrinciple.Color.Green, OpenClosedPrinciple.Size.Large);
            //var house = new OpenClosedPrinciple.Product("House", OpenClosedPrinciple.Color.Blue, OpenClosedPrinciple.Size.Large);

            //var products = new List<OpenClosedPrinciple.Product>() { apple, tree, house };

            //var fp = new OpenClosedPrinciple.FilterProducts();
            //Console.WriteLine("Green products:");
            //var gp = fp.Filter(products, new OpenClosedPrinciple.Specification(OpenClosedPrinciple.Size.Large));
            //foreach (var p in gp)
            //{
            //    Console.WriteLine($" - {p.Name} is Large");
            //}

            //var fps = new OpenClosedPrinciple.FilterProducts();
            //Console.WriteLine("Green products an large:");

            //var lp = new List<OpenClosedPrinciple.ISpecification<OpenClosedPrinciple.Product>> { new OpenClosedPrinciple.Specification(OpenClosedPrinciple.Size.Large), new OpenClosedPrinciple.Specification(OpenClosedPrinciple.Color.Green) };
            //var gps = fp.Filters(products, lp);
            //foreach (var p in gps)
            //{
            //    Console.WriteLine($" - {p.Name} is green and large");
            //}
            #endregion


            #region FluentBuilder

            //var me = FluentBuilder.Person.New.Called("Aris").WorkAsA("superstart");

            //Console.WriteLine(me);

            #endregion


            #region FacetedBuilder

            //var pb = new FacetedBuilder.PersonBuilder();
            //FacetedBuilder.Person person = pb.Lives.At("street")
            //                      .In("Madrid")
            //                      .WithPostcode("100")
            //                .Works.At("Nilsen")
            //                      .AsA("CEO")
            //                      .Earning(1000000);

            //Console.WriteLine(person);
            #endregion


            #region Factory

            //var point = Point.Factory.NewPolarPoint(1, 3);

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

            //var john = new Person(new[] { "John", "Smith" }, new Address("London Road", 123));

            //var jane = john.DeepCopy();
            //jane.Names = new[] { "Jane", "Smith" };
            //Console.WriteLine(john);
            //Console.WriteLine(jane);

            #endregion


            #region Singleton

            //var db = SingletonDatabase.Instance;
            //var city = "Tokyo";
            //Console.WriteLine($"Tokyo has population {db.GetPopulation(city)}");

            #endregion


            #region Bridge

            //var rasterRenderer = new RasterRenderer();
            //var vectorRenderer = new VectorRenderer();
            //var circle = new Circle(vectorRenderer,5);

            //circle.Draw();
            //circle.Resize(2);

            #endregion


            #region Composite

            //var drawing = new GraphicObject {Name = "My Drawing"};
            //drawing.Children.Add(new SquareC{Color = "Red"});
            //drawing.Children.Add(new CircleC{Color = "Yellow"});


            //var group = new GraphicObject();
            //group.Children.Add(new SquareC{Color = "Blue"});
            //group.Children.Add(new CircleC{Color = "Blue"});
            
            
            //drawing.Children.Add(group);
            
            //Console.WriteLine(drawing);
            #endregion
            #region Composite2
            //var neuron1 = new Neuron();
            //var neuron2 = new Neuron();

            //neuron1.ConnectTo(neuron2);

            //var neuronLayer1 = new NeuronLayer();
            //var neuronLayer2 = new NeuronLayer();

            //neuron1.ConnectTo(neuronLayer1);
            //neuronLayer1.ConnectTo(neuronLayer2);

            #endregion

            #region Adapter - Decorator

            //ExtendStringBuilder s = "hello ";
            //s += "world";
            //Console.WriteLine(s);

            #endregion


            #region Dynamic Decorator Composite

            //var square = new SquareD(1.23f);
            //Console.WriteLine(square.AsString());

            //var colorSquare = new ColorShape(square, "red");
            //Console.WriteLine(colorSquare.AsString());

            //var transparentSquare = new TransparentShape(colorSquare, 0.5f);
            //Console.WriteLine(transparentSquare.AsString());

            #endregion


            #region FlyWeight

            var ft = new FormatterText("This is a flyWeight pattern");
            ft.For(10, 18).Capitalize = true;
            Console.WriteLine(ft);
            #endregion

            //Console.ReadLine();

        }
    }
}