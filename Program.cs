using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeProblems
{
    class Program
    {
        public static int strStr(string haystack, string needle)
        {
            bool needleFound = false;
            int needleIndex = 0;

            if (needle.Length == 0)
                return 0;

            for (int i = 0; i < haystack.Length; i++)
            {
                if (haystack[i] == needle[0])
                {
                    needleIndex = i;
                    needleFound = true;
                    for (int j = 0; j < needle.Length; j++)
                    {
                        if (haystack[i + j] == needle[j])
                            needleFound = true;
                        else
                            needleFound = false;
                    }

                    if (needleFound == true)
                        return needleIndex;
                }
            }

            if (needleFound == false)
                needleIndex = -1;

            return needleIndex;
        }


        public static int ReverseInt(int x)
        {
            if (x == 0)
                return 0;
            int res = 0;

            while (x != 0)
            {
                res = res * 10 + x % 10;
                x = x / 10;
                Console.WriteLine(res);
            }

            if (res > int.MaxValue)
                return 0;

            return res;
        }

        public static Boolean PalindromeNumber(int x)
        {
            return false;
        }

        public static int FindLucky(int[] arr)
        {
            Dictionary<int, int> numFreq = new Dictionary<int, int>();
            foreach (int num in arr)
            {
                if (numFreq.ContainsKey(num))
                {
                    numFreq[num] += 1;
                }
                else
                {
                    numFreq.Add(num, 1);
                }
            }

            int luckyNumber = -1;
            foreach(int num in arr)
            {
                int luckyNum;
                numFreq.TryGetValue(num, out luckyNum);

                if (num == luckyNum && num > luckyNumber)
                {
                    luckyNumber = num;
                }
            }

            return luckyNumber;
        }

        public static int NumSpecial(int[][] mat)
        {
            bool uniqueRow = false;
            bool uniqueColumn = false;
            int numOfSpecial = 0;

            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat[0].Length; j++)
                {
                    if (mat[i][j] == 1)
                    {
                        uniqueRow = checkRow(mat, j);
                        uniqueColumn = checkColumn(mat, i);

                        if (uniqueRow == true && uniqueColumn == true)
                        {
                            numOfSpecial++;
                        }
                    }
                }
            }

            return numOfSpecial;
        }

        public static bool checkRow(int[][] mat, int col)
        {
            int rowLength = mat.GetLength(0);
            int oneCount = 0;
            for (int i = 0; i < rowLength; i++)
            {
                if (mat[i][col] == 1)
                    oneCount++;
            }

            return oneCount == 1;
        }

        public static bool checkColumn(int[][] mat, int row)
        {
            int columnLength = mat[0].Length;
            int oneCount = 0;

            for (int i = 0; i < columnLength; i++)
            {
                if (mat[row][i] == 1)
                    oneCount++;
            }

            return oneCount == 1;
        }
        

        // Test Cases

        [TestFixture]
        class TestCases
        {
            [Test]
            public void NumSpecial_With1Special()
            {
                int[][] mat =
                {
                    new int[] {1,0,0},
                    new int[] {0,0,1},
                    new int[] {1,0,0}
                };

                int result = NumSpecial(mat);
                Assert.AreEqual(1, result);
            }

            [Test]
            public void NumSpecial_With3Special()
            {
                int[][] mat =
                {
                    new int[] {1,0,0},
                    new int[] {0,1,0},
                    new int[] {0,0,1}
                };

                int result = NumSpecial(mat);
                Assert.AreEqual(3, result);
            }

            [Test]
            public void NumSpecial_With2Special()
            {
                int[][] mat =
                {
                    new int[] {0,0,0,1},
                    new int[] {1,0,0,0},
                    new int[] {0,1,1,0},
                    new int[] {0,0,0,0}
                };

                int result = NumSpecial(mat);
                Assert.AreEqual(2, result);
            }

            [Test]
            public void NumSpecial_With3Special5RowsRCols()
            {
                int[][] mat =
                {
                    new int[] {0,0,0,0,0},
                    new int[] {1,0,0,0,0},
                    new int[] {0,1,0,0,0},
                    new int[] {0,0,1,0,0},
                    new int[] {0,0,0,1,1}
                };

                int result = NumSpecial(mat);
                Assert.AreEqual(2, result);
            }
        }
    }
}
