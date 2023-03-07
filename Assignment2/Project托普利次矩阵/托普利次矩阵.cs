using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project托普利次矩阵
{
    internal class Matrix
    {
        int M, N;
        public Matrix(int m, int n)
        {
            this.M = m;
            this.N = n;
        }
        public bool IsMatrix(int[][] a)
        {

            for (int i = M - 1; i >= 0; i--)
            {
                int j = 0;
                while (i < M || j < N)
                {
                    int k = i;
                    if (k == M - 1 || j == N - 1) break;
                    if (a[k][j] == a[k + 1][j + 1]) { k++; j++; }
                    else return false;
                }
            }

            for (int j = 1; j < N; j++)
            {

                int i = 0;
                while (i < M || j < N)
                {
                    int k = j;
                    if (i == M - 1 || k == N - 1) break;
                    if (a[i][k] == a[i + 1][k + 1]) { i++; k++; }
                    else return false;
                }
            }

            return true;
        }
        public static void Main(string[] args)
        {
            Matrix matrix = new Matrix(3, 3);
            int[][] array = { new int[] { 2, 2, 3 }, new int[] { 3, 1, 2 }, new int[] { 2, 3, 1 } };
            Console.WriteLine(matrix.IsMatrix(array));
            Console.ReadKey();

        }
    }
}

