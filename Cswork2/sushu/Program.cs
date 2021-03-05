using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sushu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("请输入数字：");
            int num1 = int.Parse(Console.ReadLine());
            while (num1 > 1)
            {
                for (int i = 2; i <= num1; i++)
                {
                    double n = num1 % i;
                    if (n==0)
                    {
                        Console.WriteLine(i);
                        num1 = num1 / i;
                        break;
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
