using System;
using static System.Math;

namespace NumberSystems
{
    class MyMath
    {
        public static bool IsPrime(int n)
        {
            bool prime = true;
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                {
                    prime = false;
                    break;
                }
            }
            return prime;
        }

        /*public static int[] PrimesUntil(int n)
        {
            int[] arr = new int[n];
            int indx = 0;
            //while indx is less than n
            int i = 2;
            while (i < n)
            {
                if (IsPrime(i))
                {
                    arr[indx] = i;
                    indx++;
                }
                i++;
            }
            //change the '0' factors to '1' so it doesnt affect the multiplication
            for (int j = 0; j < arr.Length; j++)
            {
                if (arr[j] == 0)
                {
                    arr[j] = 1;
                }
            }
            return arr;
        }

        public static int[] Factors(int num)
        {
            int[] factors = new int[num];
            int indx = 0;
            int[] primes = PrimesUntil(num);

            foreach (int prime in primes)
            {
                if (num % prime == 0)
                {
                    factors[indx] = prime;
                    indx++;

                    int first = prime;
                    int second = num / prime;
                }
            }

            return factors;
        }*/

        public static int[] NewFactors(int num)
        {
            int[] factors = new int[num];
            int indx = 0;

            int i = 2;
            while (num > 0)
            {
                /* if its perfectly divisible
                 *      num1 = i
                 *      num2 = num / i
                 *      
                 *      if num1 is prime
                 *          add to main factors
                 *      else
                 *          get its prime factors and add to main factors array
                 *      repeat for num2
                 *      */
                bool num1prime = false;
                bool num2prime = false;

                 if (num%i == 0)
                 {
                    int num1 = i;
                    int num2 = num / i;

                    if (IsPrime(num1))
                    {
                        num1prime = true;
                        factors[indx] = num1;
                        indx++;
                    }
                    else
                    {
                        int[] secondaryFactors = NewFactors(num1);
                        foreach (int item in secondaryFactors)
                        {
                            factors[indx] = item;
                            indx++;
                        }
                    }
                    if (IsPrime(num2))
                    {
                        num2prime = true;
                        factors[indx] = num2;
                        indx++;
                    }
                    else
                    {
                        int[] secondaryFactors = NewFactors(num2);
                        foreach (int item in secondaryFactors)
                        {
                            factors[indx] = item;
                            indx++;
                        }
                    }
                if (num1prime && num2prime)
                    {
                        break;
                    }
                }
            }
            //change remaining 0's to a 1
            int[] newarr = new int[indx + 1];
            for (int newindx = 0; newindx < indx; newindx++)
            {
                if (factors[newindx] == 0)
                {
                    newarr[newindx] = factors[newindx];
                    newindx++;
                }
            }
            return newarr;
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
            foreach (int item in MyMath.NewFactors(20))
            //foreach (int item in MyMath.PrimesUntil(50))
            {
                Console.WriteLine("Factor: {0}", item);
            }
        }
    }
}
