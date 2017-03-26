using System;
using System.Text;

namespace Basics
{
    public static class Extension
    {

        public static void PrintArray(this int[] myArr)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < myArr.Length; i++)
            { sb.Append(myArr[i] + ","); }

            if (sb.Length > 1) { sb.Remove(sb.Length - 1, 1); }
            Console.WriteLine("\n" + sb.ToString() + "\n");
        }

        public static int WordCount(this string str)
        {
            string[] userString = str.Split(new char[] { ' ', '.', '?' },
                                        StringSplitOptions.RemoveEmptyEntries);
            int wordCount = userString.Length;
            return wordCount;
        }
        public static int TotalCharWithoutSpace(this string str)
        {
            int totalCharWithoutSpace = 0;
            string[] userString = str.Split(' ');
            foreach (string stringValue in userString)
            {
                totalCharWithoutSpace += stringValue.Length;
            }
            return totalCharWithoutSpace;
        }
    }
}
