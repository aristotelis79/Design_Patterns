using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DesignPatterns
{
    public class GraphicObject
    {
        public virtual string Name { get; set; } = "Group";
        public string Color { get; set; }

        public Lazy<List<GraphicObject>> _children { get; set; } = new Lazy<List<GraphicObject>>();
        public List<GraphicObject> Children => _children.Value;

        private void Print(StringBuilder sb, int depth)
        {
            sb.Append(new string('*', depth))
                .Append(string.IsNullOrWhiteSpace(Color) ? string.Empty : $"{Color} ")
                .AppendLine(Name);

            foreach (var c in Children)
            {
                c.Print(sb,depth+1);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            Print(sb, 0);
            return sb.ToString();
        }
    }

    public class CircleC : GraphicObject
    {
        public override string Name => "Circle";
    }

    public class SquareC : GraphicObject
    {
        public override string Name => "Square";
    }

    public class Neuron : IEnumerable<Neuron>
    {
        public float Value;
        public List<Neuron> In, Out;


        public IEnumerator<Neuron> GetEnumerator()
        {
            yield return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class NeuronLayer : Collection<Neuron>
    {
    }

    public static class ExtensionNeurons
    {
        public static void ConnectTo(this IEnumerable<Neuron> self, IEnumerable<Neuron> other)
        {
            if(ReferenceEquals(self,other )) return;

            foreach (var from in self)
            foreach (var to in other)
            {
                from.Out.Add(to);
                to.In.Add(from);
            }
            
        }
    }
}