using System;
using System.IO;

namespace Basics
{
    delegate int NumberChanger(int n);
    delegate void printString(string s);

    class Delegate
    {
        static int num = 10;
        private static FileStream fs;
        private static StreamWriter sw;

        private static int AddNum(int p)
        {
            num += p;
            return num;
        }

        private static int MultNum(int q)
        {
            num *= q;
            return num;
        }

        private static int getNum()
        {
            return num;
        }

        public static void testSimpleDelegate()
        {
            //create delegate instances
            NumberChanger nc1 = new NumberChanger(AddNum); // One way
            NumberChanger nc2 = MultNum; // Another way

            //calling the methods using the delegate objects
            nc1(25);
            Console.WriteLine("Value of Num: {0}", getNum());
            nc2(5);
            Console.WriteLine("Value of Num: {0}", getNum());
        }

        public static void testAdvanceDelegate()
        {
            //create delegate instances
            NumberChanger nc;
            NumberChanger nc1 = new NumberChanger(AddNum);
            NumberChanger nc2 = new NumberChanger(MultNum);
            nc = nc1;
            nc += nc2;

            //calling multicast
            nc(5);
            Console.WriteLine("Value of Num: {0}", getNum());
        }


        // this method prints to the console
        public static void writeToScreen(string str)
        {
            Console.WriteLine("The String is: {0}", str);
        }

        //this method prints to a file
        public static void writeToFile(string s)
        {
            fs = new FileStream("c:\\message.txt", FileMode.Append, FileAccess.Write);
            sw = new StreamWriter(fs);
            sw.WriteLine(s);
            sw.Flush();
            sw.Close();
            fs.Close();
        }

        // this method takes the delegate as parameter and uses it to
        // call the methods as required
        public static void sendString(printString ps)
        {
            ps("Hello World");
        }

        public static void printStringDelegate()
        {
            printString ps1 = new printString(writeToScreen);
            printString ps2 = new printString(writeToFile);
            sendString(ps1);
            sendString(ps2);
        }
    }
}