using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Print
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }

    public class GenericList<T>
    {
        public Node<T> head;
        public Node<T> tail;

        public GenericList()
        {
            head = tail = null;
        }
        public Node<T> Head
        {
            get => head;
        }
        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail==null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }

        public void ForEach(Action<Node<T>> action)
        {
            Node<T> p = head;
            while (p != null)
            {
                action(p);
                p = p.Next;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> intlist = new GenericList<int>();
            for (int i = 0; i < 10; i++)
            {
                intlist.Add(i);
            }

            intlist.ForEach(x => Console.Write(x.Data+" "));
            Console.WriteLine();

            int max = int.MinValue;
            intlist.ForEach(x => max = x.Data > max ? x.Data : max);
            Console.WriteLine($"max: {max}");

            int min = int.MaxValue;
            intlist.ForEach(x => min = x.Data < min ? x.Data : min);
            Console.WriteLine($"min: {min}");

            int sum = 0;
            intlist.ForEach(x => sum += x.Data);
            Console.WriteLine($"sum: {sum}");
        }
    }
}
