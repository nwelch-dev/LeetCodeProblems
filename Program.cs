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
        static void Main(string[] args)
        {
            //Console.WriteLine("NeedleIndex: {0}", strStr("", ""));

            //reverseInt(123);

            /*
            int[] arr = { 5, 4, 7, 8, 4, 8, 8, 3, 7, 7, 6, 3, 7, 6, 5, 6, 8, 4, 5, 7, 4, 7, 7, 5, 2, 5, 6, 6, 8, 1, 6, 8, 8, 8, 9, 3, 2, 9 };
            Console.WriteLine(FindLucky(arr));
            */
        }
    }
}
