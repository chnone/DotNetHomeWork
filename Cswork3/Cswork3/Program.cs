using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shape
{
    public interface Shape
    {
        double Area { get; }
    }
    public class Rectangle : Shape
    {
        private int longth;
        private int width;
        private int area;

        public Rectangle(int longth, int width)
        {
            this.longth = longth;
            this.width = width;
        }

        public double Area
        {
            get
            {
                if (longth > 0 && width > 0)
                {
                    area = longth * width;
                    return area;
                }
                else
                {
                    return -1;
                }

            }

        }
    }

    public class Square : Shape
    {
        private int side;
        private int area;

        public Square(int side)
        {
            this.side = side;
        }
        public double Area
        {
            get
            {
                if (side > 0)
                {
                    area = side * side;
                    return area;
                }
                else
                {
                    return -1;
                }
            }
        }
    }

    public class Triangle : Shape
    {
        private double side1;
        private double side2;
        private double side3;
        private double area;

        public Triangle(double side1, double side2, double side3)
        {
            this.side1 = side1;
            this.side2 = side2;
            this.side3 = side3;
        }
        public double Area
        {
            get
            {
                if ((side1 - side2 < side3) && (this.side1 + this.side2 > this.side3)
                && (this.side1 - this.side3 < this.side2) && (this.side1 + this.side3 > this.side2)
                && (this.side3 - this.side2 < this.side1) && (this.side3 + this.side2 > this.side1))
                {
                    double p = (side1 + side2 + side3) / 2;
                    double num = p * (p - side1) * (p - side2) * (p - side3);
                    area = Math.Sqrt(num);
                    return area;
                }
                else
                {
                    return -1;
                }
            }

        }
    }

    class ShapeFactory
    {
        public static Shape RandomShape(int n)
        {
            Random random = new Random(n);
            int key = random.Next(0, 3);
            Shape shape = null;
            switch (key)
            {
                case 0:
                    Random random1 = new Random(n);
                    int longth = random1.Next(1, 10);
                    int width = random1.Next(1, 10);
                    shape = new Rectangle(longth, width);
                    Console.WriteLine("长方形"); break;
                case 1:
                    Random random2 = new Random(n);
                    int side = random2.Next(1, 10);
                    shape = new Square(side);
                    Console.WriteLine("正方形"); break;
                case 2:
                    Random random3 = new Random(n);
                    int side1 = random3.Next(2, 4);
                    int side2 = random3.Next(2, 4);
                    int side3 = random3.Next(2, 4);
                    shape = new Triangle(side1, side2, side3);
                    Console.WriteLine("三角形"); break;
            }
            return shape;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle(3, 4);
            double b = rectangle.Area;
            Console.WriteLine("长方形面积为：");
            Console.WriteLine(b);

            Square square = new Square(3);
            double c = square.Area;
            Console.WriteLine("正方形面积为：");
            Console.WriteLine(c);

            Triangle triangle = new Triangle(3, 4, 5);
            double a = triangle.Area;
            Console.WriteLine("三角形面积为：");
            Console.WriteLine(a);

            double allArea = 0;
            for (int i = 0; i < 10; i++)
            {
                Console.Write("第" + (i + 1) + "个图形为：");
                Shape shape = ShapeFactory.RandomShape(i);
                allArea += shape.Area;
                Console.WriteLine("面积为" + shape.Area);
            }
            Console.WriteLine("十个图形总面积为：" + allArea);

        }
    }
}
