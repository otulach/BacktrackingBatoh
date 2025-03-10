using System;
using System.Runtime;

namespace BasicProgram
{
    class Program
    {
        static int currentValue = 0;
        static List<Tuple<int, int, int>> bestBag = new List<Tuple<int, int, int>>();
        static void Main(string[] args)

        {
            string[] inputWeight = Console.ReadLine().Split();
            string[] inputValue = Console.ReadLine().Split();
            List<Tuple<int, int, int>> Items = new List<Tuple<int, int, int>>();
            for (int i = 0; i < inputWeight.Length; i++)
            {
                Items.Add(new Tuple<int, int, int>(int.Parse(inputWeight[i]), int.Parse(inputValue[i]), i + 1));
            }
            int maxWeight = int.Parse(Console.ReadLine());

            int[,] tableValue = new int[Items.Count() + 1, maxWeight + 1];

            Rekursion(maxWeight, 0, Items, new List<Tuple<int, int, int>>());


            Console.WriteLine(currentValue);
            for (int i = 0; i < bestBag.Count; i++)
            {
                Console.Write(bestBag[i].Item3 + " ");
            }
            Console.WriteLine();
        }
        static void Table(int[,] table, List<Tuple<int, int, int>> Items, int maxW)
        {
            for (int i = 0; i < Items.Count(); i++)
            {
                Tuple<int, int, int> item = Items[i];
                int weight = item.Item1;
                int value = item.Item2;

                for (int w = 0; w <= maxW; w++)
                {
                    int newValue = table[i, w];
                        
                    // Counting the value
                    if (weight >= w)
                    {
                        int countedValue = value + table[i , w - weight];
                        if (countedValue > newValue)
                        {
                            newValue = countedValue;
                        }
                    }
                    table[i + 1, w] = newValue;
                }
            }
        }


        static void Rekursion(int maxWeigth, int index, List<Tuple<int, int, int>> allItems, List<Tuple<int, int, int>> itemsList)
        {
            Tuple<int, int> listInfo = Info(itemsList);
            int weight = listInfo.Item1;
            int value = listInfo.Item2;

            if (weight <= maxWeigth)
            {
                if (value > currentValue)
                {
                    currentValue = value;
                    bestBag = new List<Tuple<int, int, int>>(itemsList);
                }
            }
            else
            {
                return;
            }

            for (int i = index + 1; i < allItems.Count; i++)
            {
                List<Tuple<int, int, int>> newList = new List<Tuple<int, int, int>>(itemsList);
                newList.Add(allItems[i]);
                Rekursion(maxWeigth, i, allItems, newList);
            }
        }

        static Tuple<int, int> Info(List<Tuple<int, int, int>> list)
        {
            int weight = 0;
            int value = 0;
            for (int i = 0; i < list.Count; i++)
            {
                weight += list[i].Item1;
                value += list[i].Item2;
            }
            return new Tuple<int, int>(weight, value);
        }
    }
}
