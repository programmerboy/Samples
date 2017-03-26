using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Basics
{
    class FuncActionPredicate
    {
        static Func<double, double> squareRoot = r => r * r;
        static Func<string, string> convert = delegate (string s) { return s.ToLower(); };
        static Func<string, string> convertMethod = UppercaseString;
        static Func<int, int, int> multiplier = (x, y) => x * y;
        static string[] words = { "orange", "apple", "Article", "elephant", "four" };

        static Action<string> writeToConsole = y => Console.WriteLine(y);
        static Predicate<string> isGreaterThan5 = a => a.Length > 5;


        private static string UppercaseString(string inputString)
        {
            return inputString.ToUpper();
        }

        public static void testFunc(int x)
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            Console.WriteLine("Square Root of {0} is {1} -->", x, squareRoot(x));
            Console.WriteLine(String.Format("Multiplier --> {0}", multiplier(5, 6)));
            Console.WriteLine(String.Format("Words Example --> {0}", words.Select(convert)));
            Console.WriteLine(String.Format("Numbers Example --> {0}", numbers.Sum()));
            Console.WriteLine(String.Format("Func (convert) with an Annonymous --> {0}", convert("I WAS ORIGINALLY UPPERCASE")));
            Console.WriteLine(String.Format("Func (convert) with a Delegate --> {0}", convertMethod("i was originally lower case")));

            Func<String, int, bool> predicate = (str, index) => str.Length == index;

            IEnumerable<String> aWords = words.Where(predicate).Select(str => str);

            foreach (String word in aWords)
                Console.WriteLine(word);
        }

        public static void testLambadas()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            int oddNumbers = numbers.Count(n => n % 2 == 1);
            var firstNumbersLessThan6 = numbers.TakeWhile(n => n < 6);
            var firstLargerThanIndexNumbers = numbers.TakeWhile((n, index) => n >= index);
            var firstLargerThanIndexNumbers2 = numbers.SkipWhile((n, index) => n >= index);

            Console.WriteLine(String.Format("Count --> {0}", oddNumbers));
            Console.WriteLine(String.Format("firstNumbersLessThan6 --> {0}", string.Join(", ", firstNumbersLessThan6)));
            Console.WriteLine(String.Format("firstLargerThanIndexNumbers --> {0}", string.Join(", ", firstLargerThanIndexNumbers)));
            Console.WriteLine(String.Format("firstLargerThanIndexNumbers2 --> {0}", string.Join(", ", firstLargerThanIndexNumbers2)));
        }

        public static void testAction(string x)
        {
            writeToConsole(x);
        }

        public static void testPredicate(string x)
        {
            Console.WriteLine(isGreaterThan5(x));
        }

        public static void testExpressionTree()
        {
            // Expression Tree is not a delegate

            BinaryExpression b1 = Expression.MakeBinary(ExpressionType.Add, Expression.Constant(5), Expression.Constant(10));
            BinaryExpression b2 = Expression.MakeBinary(ExpressionType.Add, Expression.Constant(10), Expression.Constant(4));
            BinaryExpression b3 = Expression.MakeBinary(ExpressionType.Subtract, b1, b2);

            int result = Expression.Lambda<Func<int>>(b3).Compile()();

            Console.WriteLine("Result of Expression Tree {0}", result);
        }
    }
}
