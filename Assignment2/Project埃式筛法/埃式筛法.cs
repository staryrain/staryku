using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project埃式筛法
{
    internal class Filtrate
    {
      
        public int n;
        public Filtrate(int n)
        {
            this.n = n;
        }

        public void filtratefind(int n)
        {
            int[] array= new int[n-1];
            for(int i=2;i<=n;i++)
                array[i-2]=i;
            for(int j=4;j<=n;j++)
            { 
              for(int k=2;k<=j/2;k++)
                { if (array[j-2] == -1) continue;
                  if (array[j-2] % k == 0) array[j - 2] = -1;
                }
            }
            for (int i = 2; i <= n; i++)
            {
                if (array[i-2] != -1)
                    Console.WriteLine(array[i - 2]);
            }
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            Filtrate filtrate = new Filtrate(100);



            filtrate.filtratefind(100);
        }

    }
}
