namespace xin
{

    internal class Prime
    {
        static void Main(String[] args)
        {
            void Findfactor(int n)
            {
                int i = 2;
                while (1 < n)
                {
                    if (n % i == 0)
                    {
                        Console.WriteLine(i);
                        n = n / i;

                    }
                    else i++;
                }
            }
            int prime = Convert.ToInt32(Console.ReadLine());
            Findfactor(prime);

        }
    }
}