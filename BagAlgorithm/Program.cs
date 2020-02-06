using System;
using System.Collections.Generic;
using System.Linq;

namespace BagAlgorithm
{
    class BagAlgorithm
    {
        private int maxWeight = 100;

        private int nearestResult = 0;

        private Dictionary<int, int> items;

        private int[] mass;

        public BagAlgorithm(int[] mass)
        {
            this.mass = mass;
        }

        public void Work()
        {

            for(int i = 1; i < Math.Pow(2, mass.Length) ; i++) //Идём по номерам комбинаций предметов
            {
                Dictionary<int, int> dictionary = new Dictionary<int, int>(); //лучшая комбинация предметов
                List<int> itemList = new List<int>(); //номера предметов

                int j = i;
                int itemPosition = 0;

                //Console.WriteLine("new J");
                //проходимся по каждой комбинации, добавляя номера предметов, которые в ней задействуются
                while (j > 0) 
                {
                    //Console.WriteLine(j);
                    if (j % 2 == 1)
                    {
                        itemList.Insert(0,itemPosition);

                       // Console.WriteLine($"itemList.Add({itemPosition})");
                    }
                    itemPosition++;
                    j = j >> 1;
                    
                }

                //считаем массу предметов в комбинации и запоминаем их
                int sum = 0;
                for (int z = 0; z < itemList.Count; z++) 
                {
                    dictionary.Add(itemList[z], mass[itemList[z]]);
                    //Console.WriteLine($"добавили {mass[itemList[z]]}");
                    sum += mass[itemList[z]];
                }

                if (sum > nearestResult && sum <= maxWeight)
                {
                    items = dictionary;
                    nearestResult = sum;
                    //Console.WriteLine("ближайший результат: " + nearestResult);
                }
            }
        }

        public void ShowResult()
        {
            Console.WriteLine($"Ближайший результат: {nearestResult}");
            var sortedDict = from num in items
                             orderby num.Key ascending
                             select num; 
            foreach(var i in sortedDict)
            {
                Console.WriteLine($"Номер: {i.Key}, вес: {i.Value}");
            }
        }
    }

    class Test
    {
        private BagAlgorithm ba;

        public void Testing()
        {
            while (true)
            {
                string str = Console.ReadLine();

                DateTime beginTime = DateTime.Now;

                string[] strMass = str.Split(' ');
                int[] intMass = new int[strMass.Length];

                for(int i = 0; i < intMass.Length; i++)
                {
                    intMass[i] = Convert.ToInt32(strMass[i]);
                }

                ba = new BagAlgorithm(intMass);

                ba.Work();

                Console.WriteLine(DateTime.Now - beginTime);

                ba.ShowResult();
            }
        }
        
    }
    //34 70 88 91 60 9
    class Program
    {
        static void Main(string[] args)
        {
            Test t = new Test();
            t.Testing();
        }
    }
}
