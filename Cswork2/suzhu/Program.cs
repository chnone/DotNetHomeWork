using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suzhu
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] Array = { 3, 9, 8, 6, 7 };
            
            Console.WriteLine("数组为：");
            Console.Write("{");
            for (int i = 0; i < Array.Length; i++)
            {
                Console.Write(Array[i]+", ");
            }
            Console.WriteLine("}");

            int max = Array[0];
            for (int j = 0; j < Array.Length; j++)
            {
                if (Array[j]>max)
                {
                    max = Array[j];
                }
            }
            Console.WriteLine("最大值：" + max);

            int min = Array[0];
            for (int k = 0; k < Array.Length; k++)
            {
                if (Array[k] < min)
                {
                    min = Array[k];
                }
            }
            Console.WriteLine("最大值：" + min);

            int sum = 0;
            foreach (int arr in Array)
            {
                sum += arr;
            }
            Console.WriteLine("和：" + sum);


        }
    }
}
