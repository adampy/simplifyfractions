using System;
using static System.Math;
using System.Linq;

namespace NumberSystems
{
    class MyMaths
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

        public static int[] PrimesUntil(int n)
        {
            int[] arr = new int[n];
            int indx = 0;
            //while indx is less than n
            int i = 2;
            while (i <= n)
            {
                if (IsPrime(i))
                {
                    arr[indx] = i;
                    indx++;
                }
                i++;
            }

            int[] temp = new int[indx];
            for (int j = 0; j < indx; j++)
            {
                temp[j] = arr[j];
            }
            arr = temp;
            return arr;
        }

        public static int[] Factors(int num)
        {
            int[] primes = PrimesUntil(num);
            int[] factors = new int[0];
            int lengthOfFactors = 0;

            for (int i = 0; i < primes.Length; i++)
            {
                int item = primes[i];
                if (num % item == 0)
                {
                    i--;
                    lengthOfFactors++;
                    num = num / item;

                    //add new item to factors
                    int[] temp = new int[lengthOfFactors];
                    for (int j = 0; j < factors.Length; j++)
                    {
                        temp[j] = factors[j];
                    }
                    temp[lengthOfFactors - 1] = item;
                    factors = temp;
                }
            }
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

            if (top % bottom == 0)
            {
                return Convert.ToString(top / bottom);
            }

            string simple = "";
            int[] topFactors = MyMaths.Factors(top);
            int[] bottomFactors = MyMaths.Factors(bottom);

            //remove common factors until a pass happens where none is removed
            bool changed = true;
            while (changed)
            {
                changed = false;
                for (int i = 0; i < topFactors.Length; i++)
                {
                    int item = topFactors[i];
                    if (bottomFactors.Contains(item))
                    {
                        //remove item from factors
                        //remove item's index element from bottom factors

                        changed = true;
                        int[] temptop = Program.RemoveFromArray(topFactors, i);
                        int[] tempbottom = Program.RemoveFromArray(bottomFactors, Program.GetIndex(bottomFactors, item));
                        topFactors = temptop;
                        bottomFactors = tempbottom;
                    }
                }
            }

            //make top and bottom readable as single integers
            int newNumerator = 1;
            int newDenominator = 1;

            foreach (int item in topFactors)
            {
                newNumerator *= item;
            }
            foreach (int item in bottomFactors)
            {
                newDenominator *= item;
            }

            simple = Convert.ToString(newNumerator) + "/" + Convert.ToString(newDenominator);
            return simple;
        }
    }
    class Program
    {
        public static void IntArrayPrinter(int[] arr)
        {
            foreach (int item in arr)
            {
                Console.Write("{0}, ", item);
            }
            Console.Write("\n");
        }

        public static int[] RemoveFromArray(int[] arr, int indx)
        {
            int[] temp = new int[arr.Length - 1];
            int pointer = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (i != indx)
                {
                    temp[pointer] = arr[i];
                    pointer++;
                }
            }
            return temp;
        }

        public static int GetIndex(int[] arr, int item)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == item)
                {
                    return i;
                }
            }
            return -1;
        }

        public static string Simplify(string input)
        {
            Fraction fraction = new Fraction(input);
            string simplified = fraction.Simplify();
            return simplified;
        }

        static void Main(string[] args)
        {
            /*foreach (int item in MyMaths.Factors(1753))
            //foreach (int item in MyMath.PrimesUntil(1753))
            {
                Console.WriteLine("Factor: {0}", item);
            }*/

            /*int[] test = { 4, 8, 2, 6, 9, 0, 1, 23, 6 };
            int[] newarr = RemoveFromArray(test, 5);
            IntArrayPrinter(newarr);*/

            string input = "start";
            while (input != "stop")
            {
                Console.Write("Fraction: ");
                input = Console.ReadLine();

                string str = Simplify(input);

                Console.WriteLine("Simplified fraction: {0}", str);
            }
        }
    }
}
