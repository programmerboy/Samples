using System;

namespace Basics
{
    class Indexer
    {
        private string[] namelist = new string[size];
        static public int size = 10;
        public Indexer()
        {
            for (int i = 0; i < size; i++)
            {
                namelist[i] = "N. A.";
            }
        }

        public string this[int index]
        {
            get
            {
                string tmp = String.Empty;

                if (index >= 0 && index <= size - 1)
                    tmp = namelist[index];

                return (tmp);
            }
            set
            {
                if (index >= 0 && index <= size - 1)
                    namelist[index] = value;
            }
        }
        public int this[string name]
        {
            get
            {
                int index = 0;
                while (index < size)
                {
                    if (namelist[index] == name)
                    {
                        return index;
                    }
                    index++;
                }
                return index;
            }
        }

        public static void testIndexer()
        {
            Indexer names = new Indexer();
            names[0] = "Zara";
            names[1] = "Riz";
            names[2] = "Nuha";
            names[3] = "Asif";
            names[4] = "Davinder";
            names[5] = "Sunil";
            names[6] = "Rubic";

            //using the first indexer with int parameter
            for (int i = 0; i < Indexer.size; i++)
            {
                Console.WriteLine(names[i]);
            }

            //using the second indexer with the string parameter
            Console.WriteLine(names["Nuha"]);
            Console.WriteLine();
        }
    }
}
