using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal class Intarray
    {
       public static int Min(int[] array)
        { if (array == null) throw new ArgumentNullException();
         int min = 0;
          bool Ismin = false;
            foreach (int x in array)
            {
                if (Ismin)
                {
                    if (x<min ) min = x;
                }
                else
                {
                    min = x;
                    Ismin= true;
                }
            }
            if (Ismin) { return min; };
            throw new Exception("none");

        }
        public static int Max(int[] array) {
            {
                if (array == null) throw new ArgumentNullException();
                int max = 0;
                bool Ismax = false;
                foreach (int x in array)
                {
                    if (Ismax)
                    {
                        if (x > max) max = x;
                    }
                    else
                    {
                        max = x;
                        Ismax = true;
                    }
                }
                if (Ismax) { return max; };
                throw new Exception("none");

            }
        }
        public static int Add(int[] array)
        {
            int sum=0; 
            foreach(int v in array) { sum += v; }
            return sum;
        }
        public static double Average(int[] array) 
        {
            long sum = 0;
            foreach (int v in array) { sum+=v; }
            long n=array.Length;
            double average =(double)sum/n;
            return (double)average;
        }
        static void Main(String[] args)
        {
            int[] array = new int[] { 1, 2, 4 };
            Console.WriteLine("Min="+Min(array)+"\n"+"Max="+Max(array)+"\n"+"Add="+Add(array)+"\n"+"Average="+Average(array));
            Console.ReadKey();
        }
    }
}
