using System;
using System.ComponentModel;
using System.Reflection;

namespace Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            FuncActionPredicate.testFunc(5);
            FuncActionPredicate.testLambadas();
            Console.ReadLine();

            var grouping = new Grouping();
            grouping.groupRemainder1();
            Console.WriteLine(Environment.NewLine);
            grouping.groupRemainder();
            Console.WriteLine(Environment.NewLine);
            grouping.Linq44();

            Generics.testGeneric();

            Miscellaneous m = new Miscellaneous();
            m.structDemo();
            m.sortArray();
            m.checkAnagrams();

            FuncActionPredicate.testAction("This is a test");
            FuncActionPredicate.testPredicate("This is a test");
            FuncActionPredicate.testExpressionTree();

            Console.WriteLine(Environment.NewLine);

            Delegate.testSimpleDelegate();
            Delegate.testAdvanceDelegate();

            m.bubbleSort();
            m.testExtensionMethod();
            m.ComparerExample();

            Threading.testThread();
            Indexer.testIndexer();

            Shape.TestPolymorphism();

            var where = new Where();
            where.Linq5();

            Console.WriteLine(Environment.NewLine);

            var projection = new Projection();

            var type = typeof(Projection);
            var methodInfo = type.GetMethods();

            //Console.WriteLine("Count of attributes {0}\n", methodInfo.Length);
            MethodInfo mInfo = type.GetMethod("DataSetLinq6");

            CategoryAttribute catAtt = (CategoryAttribute)Attribute.GetCustomAttribute(mInfo, typeof(CategoryAttribute));
            DescriptionAttribute desAtt = (DescriptionAttribute)Attribute.GetCustomAttribute(mInfo, typeof(DescriptionAttribute));

            if (catAtt != null) { Console.WriteLine(catAtt.Category); }
            if (desAtt != null) { Console.WriteLine(desAtt.Description); }

            Console.WriteLine(Environment.NewLine);
            projection.DataSetLinq6();

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(Environment.NewLine);

            Console.ReadLine();
        }
    }
}
