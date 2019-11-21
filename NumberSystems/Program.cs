using System;

namespace NumberSystems
{
    class MyMath
    {
        public static int[] PrimesUntil(int n)
        {
            int[] arr = new int[n];
            int indx = 0;
            for (int i = 2; i < n; i++)
            {
                if (i % 2 != 0)
                {
                    arr[indx] = i;
                    indx++;
                }
            }
            return arr;
        }

        public static int[] Factors(int num)
        {
            int[] factors = new int[num];
            return factors;
        }
    }

    class Fraction
    {
        int top;
        int bottom;
        public Fraction(string rawData)
        {
            string[] splitted = rawData.Split("/");
            top = Convert.ToInt32(splitted[0]);
            bottom = Convert.ToInt32(splitted[1]);
        }

        public string Simplify()
        {
            if (top == bottom)
            {
                return "1";
            }
            if (top == 0)
            {
                return "0";
            }
            if (bottom == 0)
            {
                return "Divide by zero error.";
            }

            string simple = "";
            /*
             * get all prime factors of top as array
             * get all prime factors of bottom as array
             * check all primes and if there are common ones, remove them
             * top = multiply all of remaining factors
             * bottom = multiply all of remaining factors
             * return "top/bottom";
             * */
            return simple;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            foreach (int item in MyMath.PrimesUntil(50))
            {
                Console.WriteLine(item);
            }
        }
    }
}
