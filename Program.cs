using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application
{
    class Program
    {
        private static bool Test()
        {
            var currentColor = Console.ForegroundColor;
            
            ICollection<TestCase<string, int>> testCases = TestCaseInit();

            int i = 1;

            bool allTestsPassed = true;

            foreach (var testCase in testCases)
            {
                if (CalculateMaxLength(testCase.Array) == testCase.ExpectedResult)
                {
                    System.Console.Write($"Test case { i }: result = ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    System.Console.Write("PASSED\n");
                    Console.ForegroundColor = currentColor;
                }
                else
                {
                    System.Console.Write("Test case 1: result = ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.Write("FAILED\n");
                    Console.ForegroundColor = currentColor;
                }

                i++;
            }

            return allTestsPassed;
        }
        
        private static ICollection<TestCase<string, int>> TestCaseInit()
        {
            ICollection<TestCase<string, int>> testCases = new List<TestCase<string, int>>();

            #region  Test_cases

            string[] test1 = { "co", "dil", "ity" };
            string[] test2 = { "abc", "yyy", "def", "csv" };
            string[] test3 = { "potato", "kayak", "banana", "racecar" };
            string[] test4 = { "eva", "jqw", "tyn", "jan" };

            #endregion
            #region Test_case_init

            TestCase<string, int> testCase1 = new TestCase<string, int>(test1, 5);
            TestCase<string, int> testCase2 = new TestCase<string, int>(test2, 9);
            TestCase<string, int> testCase3 = new TestCase<string, int>(test3, 0);
            TestCase<string, int> testCase4 = new TestCase<string, int>(test4, 9);

            #endregion
            #region Add_Test_Case_Collection

            testCases.Add(testCase1);
            testCases.Add(testCase2);
            testCases.Add(testCase3);
            testCases.Add(testCase4);

            #endregion
        
            return testCases;
        }
        static void Main(string[] args)
        {
            System.Console.Write($"{Test() ? }");
        }

        public static int CalculateMaxLength(string[] A)
        {
            int maxLength = 0;

            for (int i = 0; i < A.Length; i++)
            {
                int length = 0;

                string word = A[i];

                for (int j = 1; j < A.Length; j++)
                {
                    if (!CheckForSameLetters(word, A[j]) == false)
                    {
                        word += A[j];
                        length = word.Length;

                        if (maxLength < length)
                        {
                            maxLength = length;
                        }
                    }
                }
            }

            return maxLength;
        }

        public static bool CheckForSameLetters(string str1, string str2)
        {
            foreach (char c in str1.ToLower())
            {
                if (str2.Contains(c.ToString()))
                {
                    return false;
                }
            }

            return true;
        }
    }
}