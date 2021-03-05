using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aishishaifa
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[] Bool = new bool[101];
            for (int i = 2; i <= 100; i++)
                Bool[i] = true;
            for (int i = 2; i <= 100; i++)
                if (Bool[i])
                {
                    for (int j = 2 * i; j <= 100; j += i)
                        Bool[j] = false;
                    Console.WriteLine(i);
                }

        }
    }
}
