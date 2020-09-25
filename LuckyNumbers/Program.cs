using System;
using System.Collections.Generic;
using System.Linq;

namespace LuckyNumbers
{
    class Program
    {
        int powResult = 0;
        int sumOfPowers = 0;
        int temp = 0;
        readonly int[] tempArray = new int[6];
        readonly List<int> listOfPowers = new List<int>();

        public bool IsDuplicate()
        {
            bool[] duplicateArray = new bool[10];

            for (int i = 0; i < 10; i++)
            {
                duplicateArray[i] = false;
            }
            while (temp > 0)
            {
                int digit = temp % 10;

                if (duplicateArray[digit])
                {
                    return false;
                }

                duplicateArray[digit] = true;

                temp /= 10;
            }
            return true;
        }

        public int LuckyNumberCalculation(int checkedNumber)
        {

            int iterationNumber = 1;

            while (sumOfPowers != 1)
            {
                sumOfPowers = 0;
                int digitsLength = checkedNumber.ToString().Length;

                for (int i = digitsLength; i > 0; i--)
                {
                    tempArray[i] = checkedNumber % 10;
                    checkedNumber /= 10;
                }

                for (int i = 1; i <= digitsLength; i++)
                {
                    powResult = (int)Math.Pow(tempArray[i], 2);
                    sumOfPowers += powResult;
                }

                listOfPowers.Add(sumOfPowers);
                Console.WriteLine("Sum of Powers, in iteration number: " + iterationNumber + " is equal: " + sumOfPowers);
                iterationNumber++;

                if (listOfPowers.Count != listOfPowers.Distinct().Count())
                {
                    Console.WriteLine("Number is not lucky, because sum of powers doesn't containt duplicate power");
                    break;
                }
                else if (sumOfPowers == 1)
                {
                    Console.WriteLine("Number is lucky, because, sum of powers is equal: " + sumOfPowers);
                    return checkedNumber;
                }
                else
                {
                    temp++;
                    checkedNumber = sumOfPowers;
                }
            }

            return sumOfPowers;
        }

        static void Main()
        {
            int checkedNumber = 7;
            Program program = new Program();
            program.LuckyNumberCalculation(checkedNumber);
        }
    }
}
