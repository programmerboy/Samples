using Basics.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Basics
{
    class Grouping
    {
        private Helper helper;

        public Grouping()
        {
            helper = new Helper();
        }

        public void groupRemainder1()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var query = numbers.GroupBy(i => i % 2);
            foreach (var group in query)
            {
                Console.WriteLine("Key: {0}", group.Key);
                foreach (var number in group)
                {
                    Console.WriteLine(number);
                }
            }
        }

        public void groupRemainder()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var test =
                 from n in numbers
                 select new { Number = n, Remainder = n % 5 };

            Console.WriteLine("Numbers with a their remainders");
            foreach (var n in test)
            { Console.WriteLine("Number {0}, Remainder {1}", n.Number, n.Remainder); }


            var numberGroups =
                from n in numbers
                group n by n % 5 into g
                select new { Remainder = g.Key, Numbers = g };

            foreach (var g in numberGroups)
            {
                Console.WriteLine("Numbers with a remainder of {0} when divided by 5:", g.Remainder);
                foreach (var n in g.Numbers)
                {
                    Console.WriteLine(n);
                }
            }
        }

        public void Linq41()
        {
            string[] words = { "blueberry", "chimpanzee", "abacus", "banana", "apple", "cheese" };

            var wordGroups =
                from w in words
                group w by w[0] into g
                select new { FirstLetter = g.Key, Words = g };

            foreach (var g in wordGroups)
            {
                Console.WriteLine("Words that start with the letter '{0}':", g.FirstLetter);
                foreach (var w in g.Words)
                {
                    Console.WriteLine(w);
                }
            }
        }

        public void Linq42()
        {
            List<Product> products = helper.GetProductList();

            var orderGroups =
                from p in products
                group p by p.Category into g
                select new { Category = g.Key, Products = g };

            ObjectDumper.Write(orderGroups, 1);
        }

        public void Linq43()
        {
            List<Customer> customers = helper.GetCustomerList();

            var customerOrderGroups =
                from c in customers
                select
                    new
                    {
                        c.CompanyName,
                        YearGroups =
                            from o in c.Orders
                            group o by o.OrderDate.Year into yg
                            select
                                new
                                {
                                    Year = yg.Key,
                                    MonthGroups =
                                        from o in yg
                                        group o by o.OrderDate.Month into mg
                                        select new { Month = mg.Key, Orders = mg }
                                }
                    };

            ObjectDumper.Write(customerOrderGroups, 3);
        }

        public void Linq44()
        {
            string[] anagrams = { "from   ", " salt", " earn ", "  last   ", " near ", " form  " };

            //var distinct = anagrams.Select(r => r.Trim()).Distinct(new AnagramEqualityComparer());
            //ObjectDumper.Write(distinct, 1);

            var orderGroups = anagrams.GroupBy(w => w.Trim(), new AnagramEqualityComparer());
            ObjectDumper.Write(orderGroups, 1);
        }

        public class AnagramEqualityComparer : IEqualityComparer<string>
        {
            public bool Equals(string x, string y)
            {
                return getCanonicalString(x) == getCanonicalString(y);
            }

            public int GetHashCode(string obj)
            {
                return getCanonicalString(obj).GetHashCode();
            }

            private string getCanonicalString(string word)
            {
                char[] wordChars = word.ToCharArray();
                Array.Sort<char>(wordChars);
                return new string(wordChars);
            }
        }
    }
}
