using System;

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
            for (int i = 0; i < inputWeight.Length; i++){
                Items.Add(new Tuple<int, int, int>(int.Parse(inputWeight[i]), int.Parse(inputValue[i]), i + 1));
            }
            int maxWeight = int.Parse(Console.ReadLine());

            Rekursion(maxWeight, 0, Items, new List<Tuple<int, int, int>>());

            Console.WriteLine(currentValue);
            for (int i = 0; i < bestBag.Count; i++){
                Console.Write(bestBag[i].Item3 + " ");
            }
            Console.WriteLine();
        }

        static void Rekursion(int maxWeigth, int index, List<Tuple<int, int, int>> allItems, List<Tuple<int, int, int>> itemsList)
        {
            Tuple<int, int> listInfo = Info(itemsList);
            int weight = listInfo.Item1;
            int value = listInfo.Item2;

            if (weight <= maxWeigth){
                if (value > currentValue){
                    currentValue = value;
                    bestBag = new List<Tuple<int, int, int>>(itemsList);
                }
            }
            else {
                    return;
            }

            for (int i = index + 1; i < allItems.Count; i++){
                List<Tuple<int, int, int>> newList = new List<Tuple<int, int, int>>(itemsList);
                newList.Add(allItems[i]);
                Rekursion(maxWeigth, i, allItems, newList);
            }
        }

        static Tuple<int, int> Info(List<Tuple<int, int, int>> list){
            int weight = 0;
            int value = 0;
            for (int i = 0; i < list.Count; i++){
                weight += list[i].Item1;
                value += list[i].Item2;
            }
            return new Tuple<int, int>(weight, value);
        }
    }
}
