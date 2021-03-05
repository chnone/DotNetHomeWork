using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace juzhen
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] juzhen = { { 1, 2, 3, 4 }, { 5, 1, 2, 3 }, { 9, 5, 1, 2 } };
            int M = 3;
            int N = 4;
            bool Bool = true;

            for (int i = 1; i < M; i++)
            {
                for (int j = i; j < N; j++)
                {
                    if (juzhen[i,j]!=juzhen[i-1,j-1])
                    {
                        Bool = false;
                        break;
                    }
                }
            }
            if (Bool)
            {
                Console.WriteLine("是");
            }
            else
            {
                Console.WriteLine("不是");
            }

        }
    }
}
