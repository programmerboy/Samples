using System;
using System.Collections.Generic;
using System.Linq;

namespace Basics
{
    public class Miscellaneous
    {
        private static Dictionary<Comparer, string> boxes;
        List<int> lstRandomNumbers = new List<int>();
        Random random = new Random();
        int[] arrayToSort = new int[100];


        public Miscellaneous()
        {
            while (lstRandomNumbers.Count < 100)
            {
                int randomNumber = random.Next(0, 100);
                if (!lstRandomNumbers.Contains(randomNumber)) { lstRandomNumbers.Add(randomNumber); }
            }
        }

        public void testExtensionMethod()
        {
            string userSentance = string.Empty;
            int totalWords = 0;
            int totalCharWithoutSpace = 0;
            Console.WriteLine("Enter the your sentance");
            userSentance = Console.ReadLine();
            totalWords = userSentance.WordCount();
            Console.WriteLine("Total number of words is :" + totalWords);
            totalCharWithoutSpace = userSentance.TotalCharWithoutSpace();
            Console.WriteLine("Total number of character is :" + totalCharWithoutSpace);
        }

        public void sortArray()
        {
            var array = new string[] { "", "C", "D", "", "B", "A", "", "" };
            for (int i = 0; i < array.Length; i++)
            { Console.WriteLine("At Index {0} with value {1}", i, array[i]); }

            for (int a = 0; a < array.Length; a++)
            {
                for (int b = a; b < array.Length - 1; b++)
                {
                    //if (((IComparable)array[j - 1]).CompareTo(array[j]) > 0)
                    if (array[b].Equals(""))
                    {
                        var temp = array[b];
                        array[b] = array[b + 1];
                        array[b + 1] = temp;
                    }
                }
            }

            Console.WriteLine("");

            for (int i = 0; i < array.Length; i++)
            { Console.WriteLine("At Index {0} with value {1}", i, array[i]); }


            //Descending
            var array2 = new string[] { "", "A", "B", "", "C", "D", "", "" };
            for (int a = 0; a < array2.Length; a++)
            {
                for (int b = array2.Length - 1; b > a; b--)
                {
                    //if (((IComparable)array2[b - 1]).CompareTo(array2[b]) > 0) //Ascending
                    if (((IComparable)array2[b - 1]).CompareTo(array2[b]) < 0) //Descending
                    {
                        var temp = array2[b - 1];
                        array2[b - 1] = array2[b];
                        array2[b] = temp;
                    }
                }
            }

            Console.WriteLine("");

            for (int i = 0; i < array2.Length; i++)
            { Console.WriteLine("At Index {0} with value {1}", i, array2[i]); }


            //Ascending
            var array3 = new string[] { "", "A", "B", "", "C", "D", "", "" };
            for (int a = 0; a < array3.Length; a++)
            {
                for (int b = array3.Length - 1; b > a; b--)
                {
                    if (((IComparable)array3[b - 1]).CompareTo(array3[b]) > 0) //Ascending
                    {
                        var temp = array3[b - 1];
                        array3[b - 1] = array3[b];
                        array3[b] = temp;
                    }
                }
            }

            Console.WriteLine("");

            for (int i = 0; i < array3.Length; i++)
            { Console.WriteLine("At Index {0} with value {1}", i, array3[i]); }

        }

        public void bubbleSort()
        {

            arrayToSort = lstRandomNumbers.ToArray();
            arrayToSort.PrintArray();

            Console.WriteLine("\n**************\nAscending\n**************");
            for (int a = 0; a < arrayToSort.Length; a++)
            {
                for (int b = arrayToSort.Length - 1; b > a; b--)
                {
                    //if (((IComparable)arrayToSort[j - 1]).CompareTo(arrayToSort[j]) > 0)
                    if (arrayToSort[b - 1] > arrayToSort[b])
                    {
                        int temp = arrayToSort[b - 1];
                        arrayToSort[b - 1] = arrayToSort[b];
                        arrayToSort[b] = temp;
                    }
                }
            }

            //Sorted Ascending
            arrayToSort.PrintArray();

            int[] arrayToSort2 = lstRandomNumbers.ToArray();
            Console.WriteLine("\n**************\nDescending\n**************\n");
            for (int c = 0; c < arrayToSort2.Length; c++)
            {
                for (int d = arrayToSort2.Length - 1; d > c; d--)
                {
                    if (arrayToSort2[d - 1] < arrayToSort2[d])
                    {
                        int temp = arrayToSort2[d - 1];
                        arrayToSort2[d - 1] = arrayToSort2[d];
                        arrayToSort2[d] = temp;
                    }
                }
            }

            //Sorted Descending
            arrayToSort2.PrintArray();
        }

        public void biDirectionalBubbleSort()
        {
            for (int i = 0; i < lstRandomNumbers.Count; i++)
            { arrayToSort[i] = lstRandomNumbers[i]; }


            int limit = arrayToSort.Length;
            int st = -1;
            bool swapped = false;
            do
            {
                swapped = false;
                st++;
                limit--;

                for (int j = st; j < limit; j++)
                {
                    if (((IComparable)arrayToSort[j]).CompareTo(arrayToSort[j + 1]) > 0)
                    {
                        int temp = arrayToSort[j];
                        arrayToSort[j] = arrayToSort[j + 1];
                        arrayToSort[j + 1] = temp;
                        swapped = true;
                    }
                }
                for (int j = limit - 1; j >= st; j--)
                {
                    if (((IComparable)arrayToSort[j]).CompareTo(arrayToSort[j + 1]) > 0)
                    {
                        var temp = arrayToSort[j];
                        arrayToSort[j] = arrayToSort[j + 1];
                        arrayToSort[j + 1] = temp;
                        swapped = true;
                    }
                }
            } while (st < limit && swapped);
        }

        public void checkAnagrams()
        {
            string[] anagrams = { "from   ", " salt", " earn ", "  last   ", " near ", " form  ", "morf", "aren", "tasl" };
            var anagramSet = anagrams.GroupBy(r => r.Trim(), new MyStringComparer()).Select(a => new { MainWord = a.Key, Anagram = a.Select(b => new { Value = b.Trim() }) });

            var anagramSDistinct = anagrams.Select(r => r.Trim()).Distinct(new MyStringComparer());
            Console.WriteLine("Distinct Words");
            foreach (var item in anagramSDistinct)
            { Console.WriteLine(item); }

            Console.WriteLine("\n**************\nAnagrams\n**************");
            foreach (var item in anagramSet)
            {
                Console.WriteLine("Main Word = > " + item.MainWord);
                foreach (var w in item.Anagram)
                { if (!item.MainWord.Equals(w.Value)) Console.WriteLine(w.Value); }
            }
        }

        public void ComparerExample()
        {
            BoxSameDimensionsComparer boxDim = new BoxSameDimensionsComparer();
            boxes = new Dictionary<Comparer, string>(boxDim);

            Console.WriteLine("Boxes equality by dimensions:");
            Comparer redBox = new Comparer(8, 4, 8);
            Comparer greenBox = new Comparer(8, 6, 8);
            Comparer blueBox = new Comparer(8, 4, 8);
            Comparer yellowBox = new Comparer(8, 8, 8);
            AddBox(redBox, "red");
            AddBox(greenBox, "green");
            AddBox(blueBox, "blue");
            AddBox(yellowBox, "yellow");

            foreach (var item in boxes)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("Boxes equality by volume:");

            BoxSameVolume boxVolume = new BoxSameVolume();
            boxes = new Dictionary<Comparer, string>(boxVolume);
            Comparer pinkBox = new Comparer(8, 4, 8);
            Comparer orangeBox = new Comparer(8, 6, 8);
            Comparer purpleBox = new Comparer(4, 8, 8);
            Comparer brownBox = new Comparer(8, 8, 4);
            AddBox(pinkBox, "pink");
            AddBox(orangeBox, "orange");
            AddBox(purpleBox, "purple");
            AddBox(brownBox, "brown");

            foreach (var item in boxes)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private static void AddBox(Comparer bx, string name)
        {
            try
            {
                boxes.Add(bx, name);
                Console.WriteLine("Added {0}, Count = {1}, HashCode = {2}", name, boxes.Count.ToString(), bx.GetHashCode());
            }
            catch (ArgumentException)
            {
                Console.WriteLine("A box equal to {0} is already in the collection.", name);
            }
        }


        public void structDemo()
        {
            StructDemo d = new StructDemo();
            d.c = 100;
            M(d);
            Console.WriteLine(d.c);
        }

        private void M(StructDemo dd)
        {
            dd.c = 200;
            Console.WriteLine(dd.c);
        }

        struct StructDemo
        {
            public int c;
        }
    }
}