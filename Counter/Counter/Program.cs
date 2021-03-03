using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("请输入第一个数字：");
            double num1 = double.Parse(Console.ReadLine());
            Console.Write("请输入运算符号：");
            string A = Console.ReadLine();
            Console.Write("请输入第二个数字：");
            double num2 = double.Parse(Console.ReadLine());
            double num3 = 0;
            if (A == "+")
                num3 = num1 + num2;
            else if (A == "-")
                num3 = num1 - num2;
            else if (A == "*")
                num3 = num1 * num2;
            else if (A == "/")
                num3 = num1 / num2;
            else
                Console.WriteLine("运算符错误");
            Console.WriteLine("结果是：" + num3);
            Console.ReadKey();
        }
    }
}

