using System;
using System.Runtime;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace BasicProgram
{
    class Program
    {
        static int currentValue = 0;
        static List<Tuple<int, int, int>> bestBag = new List<Tuple<int, int, int>>();
        static void Main(string[] args)

        {
            var summary = BenchmarkRunner.Run<KnapsackBenchmark>();

            // string[] inputWeight = Console.ReadLine().Split();
            // string[] inputValue = Console.ReadLine().Split();
            // List<Tuple<int, int, int>> Items = new List<Tuple<int, int, int>>();
            // for (int i = 0; i < inputWeight.Length; i++)
            // {
            //     Items.Add(new Tuple<int, int, int>(int.Parse(inputWeight[i]), int.Parse(inputValue[i]), i + 1));
            // }
            // int maxWeight = int.Parse(Console.ReadLine());

            // int[,] tableValue = new int[Items.Count() + 1, maxWeight + 1];

            // Table(tableValue, Items, maxWeight);

            // Rekursion(maxWeight, 0, Items, new List<Tuple<int, int, int>>());

            // Console.WriteLine(currentValue);
            // for (int i = 0; i < bestBag.Count; i++)
            // {
            //     Console.Write(bestBag[i].Item3 + " ");
            // }
            // Console.WriteLine();
        }

        public static void Table(int[,] table, List<Tuple<int, int, int>> Items, int maxW)
        {
            for (int w = 0; w <= maxW; w++)
            {
                table[0, w] = 0;
            }

            for (int i = 0; i < Items.Count(); i++)
            {
                Tuple<int, int, int> item = Items[i];
                int weight = item.Item1;
                int value = item.Item2;

                for (int w = 0; w <= maxW; w++)
                {
                    int newValue = table[i, w];
                        
                    // Counting the value
                    if (w >= weight)
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
            
            // for (int i = 0; i <= Items.Count(); i++)
            // {
            //     for (int w = 0; w <= maxW; w++)
            //     {
            //         Console.Out.Write(table[i, w] + " ");
            //     }
            //     Console.Out.WriteLine();
            // }

            // Tracing back the result of our table
            List<int> result = new List<int>();
            int traceI = Items.Count();
            int traceW = maxW;

            while (traceI > 0 & traceW > 0)
            {
                if (table[traceI, traceW] == table[traceI - 1, traceW]){

                }
                else{
                    result.Add(traceI);
                    traceW -= Items[traceI-1].Item1;
                }
                traceI -= 1;
            }

            // Console.WriteLine(table[Items.Count(), maxW]);
            // for (int i = result.Count - 1; i >= 0; i--){
            //     Console.Write(result[i] + " ");
            // }
            // Console.WriteLine();
        }


        public static void Rekursion(int maxWeigth, int index, List<Tuple<int, int, int>> allItems, List<Tuple<int, int, int>> itemsList)
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

    public class KnapsackBenchmark
    {
        private List<Tuple<int, int, int>> Items;
        private int maxWeight;
        private int[,] tableValue;

        public KnapsackBenchmark()
        {
            maxWeight = 7;
            Items = new List<Tuple<int, int, int>>()
            {
                Tuple.Create(3, 2, 1),
                Tuple.Create(1, 2, 2),
                Tuple.Create(3, 4, 3),
                Tuple.Create(4, 5, 4),
                Tuple.Create(2, 3, 5),
            };
            tableValue = new int[Items.Count + 1, maxWeight + 1];
        }

        [Benchmark]
        public void RunRekursion()
        {
            Program.Rekursion(maxWeight, 0, Items, new List<Tuple<int, int, int>>());
        }

        [Benchmark]
        public void RunTable()
        {
            Program.Table(tableValue, Items, maxWeight);
        }
    }
}
