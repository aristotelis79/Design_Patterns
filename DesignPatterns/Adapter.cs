using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DesignPatterns
{
    public class Adapter
    {
        public class Point
        {
            public int X, Y;

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        public class Line
        {
            public Point Start, End;

            public Line(Point start, Point end)
            {
                Start = start;
                End = end;
            }
        } 

        public class VectorObject : Collection<Line>
        {
        }

        public class VectorRectangle : VectorObject
        {
            public VectorRectangle(int x, int y, int width, int height)
            {
                Add(new Line(new Point(x,y),new Point(x + width, y)));
                Add(new Line(new Point(x + width, y),new Point(x + width, y + height)));
                Add(new Line(new Point(x, y),new Point(x, y + height)));
                Add(new Line(new Point(x, y + height),new Point(x + width, y + height)));
            }
        }

        public class  LineToPointAdapter : Collection<Point>
        {
            private static int count;

            public LineToPointAdapter(Line line)
            {
                Console.WriteLine($"{++count}: Generating points for line [{line.Start.X},{line.Start.Y}]-[{line.End.X},{line.End.Y}]");     
                
                //...code 
            }
        }

        public static readonly List<VectorObject> vectorObjects = new List<VectorObject>
        {
            new VectorRectangle(1, 1, 10, 10), new VectorRectangle(3, 3, 6, 6)
        };

        public static void DrawPoint(Point p)
        {
            Console.WriteLine(".");
        }
    }
}