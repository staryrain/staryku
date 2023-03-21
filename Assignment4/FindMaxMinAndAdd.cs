using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project求值
{
    public class Node<T>
    {
       public Node<T> Next { get; set; }
        public T Data {  get; set; }
        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }
    public class GenericList<T> {
        private Node<T> head;
        private Node<T> tail;
         
        public GenericList()
        {
            tail=head=null;
        } 
         public Node<T> Head
        {
            get => head;
        }
        public void Add(T t) { 
        Node<T> n =new Node<T>(t);
        if(tail==null) {
            head = tail = n;
        }
        else
        {
            tail.Next = n;
            tail = n;
        }
        }
        public void ForEach(Action<T> action)
        {
            Node<T> current = head;

            while (current != null)
            {
                action(current.Data);
                current = current.Next;
            }
        }
    }

    class Program
    {
        private static void Main(string[] args)
        {
            GenericList<int> list = new GenericList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            list.ForEach(x => Console.WriteLine(x));

            int sum = 0;
            int max = int.MinValue;
            int min = int.MaxValue;

            list.ForEach(x =>
            {
                sum += x;
                max = Math.Max(max, x);
                min = Math.Min(min, x);
            });

            Console.WriteLine("Sum= " + sum);
            Console.WriteLine("Max= " + max);
            Console.WriteLine("Min= " + min);
            Console.ReadLine();
        }
    }
}
