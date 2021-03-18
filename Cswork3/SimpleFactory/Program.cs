using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory
{
    public interface ShapeFactory
    {
        double Area { get; }
    }
    public class RecFactory : ShapeFactory
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
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
