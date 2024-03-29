﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DesignPatterns
{
    class OpenClosedPrinciple
    {
        public class Product
        {
            public string Name { get; }
            public Spec ColorSpec { get; }
            public Spec SizeSpec { get; }

            public Product(string name, Spec color, Spec size)
            {
                Name = name;
                ColorSpec = color;
                SizeSpec = size;
            }
        }
        
        public class Spec
        {
            public int Value { get; set; }
        }

        public static class Color
        {
            public static Spec Red => new Spec { Value = 1 };
            public static Spec Green => new Spec { Value = 2 };
            public static Spec Blue => new Spec { Value = 3 };
        }

        public static class Size
        {
            public static Spec Small => new Spec { Value = 100 };
            public static Spec Medium => new Spec { Value = 101 };
            public static Spec Large => new Spec { Value = 102 };
        }

        public interface ISpecification<in T>
        {
            bool IsSatisfied(T t);
        }

        public interface IFilter<T>
        {
            IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
        }

        public class Specification : ISpecification<Product>
        {
            private readonly Spec _spec;
            private readonly IEnumerable<PropertyInfo> _productSpecs = typeof(Product).GetProperties().Where(x=>x.PropertyType == typeof(Spec));

            public Specification(Spec spec)
            {
                _spec = spec;
            }

            public bool IsSatisfied(Product p)
            {
                return _productSpecs.Select(s => (Spec) s.GetValue(p)).Any(specValue => specValue.Value == _spec.Value);
            }
        }

        public class FilterProducts : IFilter<Product>
        {
            public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
            {
                //return items.Where(spec.IsSatisfied);
                foreach (var i in items)
                {
                    if (spec.IsSatisfied(i))
                        yield return i;
                }
            }

            public IEnumerable<Product> Filters(IEnumerable<Product> items, List<ISpecification<Product>> specs)
            {
                foreach (var i in items)
                {
                    var idSatisfied = new List<bool>();
                    foreach (var s in specs)
                    {
                        idSatisfied.Add(s.IsSatisfied(i));
                    }

                    if (idSatisfied.All(x => x))
                        yield return i;
                }
            }
        }

        private static void Main(string[] args)
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
        }
    }
}
