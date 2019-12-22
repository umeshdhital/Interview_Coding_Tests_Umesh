using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeInterview
{
    public class Program
    {

        public static void Main(string[] args)
        {

            #region Get Sum of Digits In a Number

            //1 Get The Sum of all numbers (using LINQ)
            int inputNumber = 895689574;
            double sumOfDigits = inputNumber.ToString().Sum(x => char.GetNumericValue(x));
            Console.WriteLine($"The sum of all digits in {inputNumber} is {sumOfDigits}");

            //2 Get The Sum of all numbers (No LINQ) 
            inputNumber = 895689574;
            sumOfDigits = 0;
            foreach (char c in inputNumber.ToString())
            {
                sumOfDigits += char.GetNumericValue(c);
            }
            Console.WriteLine($"The sum of all digits in {inputNumber} is {sumOfDigits} without LINQ");

            //3 Get the Sum of all numbers - Best Solution (no conversion is required between char and numbers as in above 2 solutions)
            inputNumber = 505;
            int digit_sum = 0;
            while (inputNumber > 0)
            {
                digit_sum = digit_sum + inputNumber % 10;
                inputNumber = inputNumber / 10;
            }
            Console.WriteLine($"The sume of all digits = {digit_sum}");
            #endregion

            #region Get Sum of Int Array (using LINQ)
            int[] intArr = new int[] { 5, 10, 5, 2 };
            int sumOfArray = intArr.Aggregate((x, y) => x + y); //For Product of array, (x,y) => x* y;
            #endregion

            #region Find the maximum sum of digits of the product of two numbers

            //1 . Best way 
            int[] arr2 = { 4, 3, 5, 25 };
            int sumOfProductDigits = int.MinValue;
            for (int ii = 0; ii < arr2.Length - 1; ii++)
            {
                for (int jj = ii + 1; jj < arr2.Length; jj++)
                {
                    int product = arr2[ii] * arr2[jj];
                    sumOfProductDigits = Math.Max(sumOfProductDigits, Program.CalculateSumOfDigits(product));
                    /* Alternate way to calculate the sum 
                     int sumOfDigits =   product.ToString().Sum(c => char.GetNumericValue(c));
                     if(sumOfDigits > sumOfProductDigits)
                        sumOfProductDigits = sumOfDigits;
                    
                   */

                }
            }
            Console.WriteLine($"The max sum of products is = {sumOfProductDigits}");



            #endregion

            #region Find a pair with maximum product in array of Integers
            /*
                Input: arr[] = {1, 4, 3, 6, 7, 0}  
                Output: {6,7}  

                Input: arr[] = {-1, -3, -4, 2, 0, -5} 
                Output: {-4,-5}  
          */

            //1. Least efficient way : complexity O(n2)

            var resultArr1 = ReturnMaxProductPair(new int[] { 1, 4, 3, 6, 7, 0 });
            var resultArr2 = ReturnMaxProductPair(new int[] { -1, -3, -4, 2, 0, -5 });
            Console.WriteLine($" The pair of numbers are: { string.Join(" , ", resultArr1) }");
            Console.WriteLine($" The pair of numbers are: { string.Join(" , ", resultArr2) }");

            //2. Better way : complexity O(nLog n).

            var resultArr3 = ReturnMaxProductPairWithSorting(new int[] { 1, 4, 3, 6, 7, 0 });
            //var resultArr4 = ReturnMaxProductPairWithSorting(new int[] {  });


            #endregion

            #region Find a subarray whose sum is divisible by size of the array

            #endregion

            #region Convert RomanString passed into Integer Number
            Console.WriteLine($"The roman IV = {ConvertRomanToNumber("IV")}");
            Console.WriteLine($"The roman V = {ConvertRomanToNumber("V")}");
            Console.WriteLine($"The roman IX = {ConvertRomanToNumber("IX")}");
            Console.WriteLine($"The roman XII = {ConvertRomanToNumber("XII")}");

            #endregion


            
            Console.ReadLine();


           


        }

        public static int ConvertRomanToNumber(string roman)
        {
            /*
              In general, the string will be the sum of each character's numeric value
              For example : VII =5 + 1 + 1 = 7 ; III = 1+1+1 =3
              But exceptions are : IX = 9, IV = 4 etc, where IX is 1 less than 10 (i.e. 9) and IV is one less than 5 (i.e. 4)
            */
            int number = 0;
            Dictionary<char, int> Mapping = new Dictionary<char, int>()
            {
               {'I',1 },
                {'V',5 },
                {'X',10 },
                {'L',50 },
                {'C',100},
                {'D',500 },
                {'M',1000 }
            };

            //Check if all passed charcters are Roman valid characters
            if (! roman.All(x => Mapping.ContainsKey(x)))
            {
                throw new InvalidOperationException();
            }

            for (int i = 0; i < roman.Length; i++)
            {
                if (i + 1 < roman.Length && Mapping[roman[i + 1]] > Mapping[roman[i]])
                {
                    number -= Mapping[roman[i]];
                }
                else
                    number += Mapping[roman[i]];
            }
            return number;
        }


        public static int[] ReturnMaxProductPair(int[] inpurArr)
        {
            double currentProduct = 0;
            double maxProduct = double.MinValue;
            int[] returnArr = null;

            for (int i = 0; i < inpurArr.Length - 1; i++)
            {
                for (int j = i + 1; j < inpurArr.Length; j++)
                {
                    currentProduct = inpurArr[i] * inpurArr[j];
                    if (currentProduct > maxProduct)
                    {
                        returnArr = new int[] { inpurArr[i], inpurArr[j] };
                        maxProduct = currentProduct;
                    }
                }
            }
            return returnArr;
        }

        public static int[] ReturnMaxProductPairWithSorting(int[] inpurArr)
        {
            int size = inpurArr.Length;
            if (size < 2)
                throw new ArgumentException("The input array can't be empty");
            if (size == 2)
                return new int[] { inpurArr[0], inpurArr[1] };

            Array.Sort(inpurArr);
            //take 1st two min numbers and take last two max numbers. Calculate their products and compare
            var minNumber = inpurArr[0];
            var secondMinNumber = inpurArr[1];

            var largestNumber = inpurArr[size - 1];
            var secondLargestNumber = inpurArr[size - 2];

            if ( (minNumber * secondMinNumber) > (largestNumber * secondLargestNumber))
                return new int[] { minNumber, secondMinNumber };
            else
                return new int[] { largestNumber, secondLargestNumber };
        }


        public static int CalculateSumOfDigits(int number)
        {
            int totalSum = 0;
            while (number > 0)
            {
                totalSum += number % 10;
                number = number / 10;
            }
            return totalSum;
        }



    }
}
