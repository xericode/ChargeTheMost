using System;
using System.Collections.Generic;
using System.Linq;

namespace ChargeTheMost
{
    class Program
    {
        static void Main(string[] args)
        {
            var length = Console.ReadLine();
            //should add some defensive programming here to check the user input is really an int
            var x = highestPrice(TuplesOfPrices, int.Parse(length));
            writeLog(x.ToString());
        }

        public static List<Tuple<int, int>> TuplesOfPrices
        {
            get
            {
                var table = new List<Tuple<int, int>>();
                table.Add(new Tuple<int, int>(1, 1));
                table.Add(new Tuple<int, int>(2, 2));
                table.Add(new Tuple<int, int>(3, 4));
                table.Add(new Tuple<int, int>(4, 5));
                table.Add(new Tuple<int, int>(5, 6));
                table.Add(new Tuple<int, int>(6, 7));
                table.Add(new Tuple<int, int>(7, 9));
                table.Add(new Tuple<int, int>(8, 10));
                table.Add(new Tuple<int, int>(9, 12));
                return table;
            }
        }
                
        public static int highestPrice(List<Tuple<int, int>> priceTable, int length)
        {
            //First check the table has highest price values            
            var goodPriceTable = new List<Tuple<int, int>>();
            foreach (var tItem in priceTable.OrderBy(x => x.Item1))
            {
                if (goodPriceTable.Count == 0)
                {
                    //this means all of the items will be based off of the first one being valid... esentially 
                    goodPriceTable.Add(tItem);
                    continue;
                }
                var price = _highestPrice(goodPriceTable, tItem.Item1);
                if (price <= tItem.Item2)
                {
                    goodPriceTable.Add(tItem);
                }
            }

            writeLog("Good Price Table");
            foreach (var item in goodPriceTable
                .OrderBy(i => i.Item1))
            {                
                writeLog($"len {item.Item1} = {item.Item2} unit price {decimal.Parse(item.Item2.ToString()) / decimal.Parse(item.Item1.ToString())}");
            }
            writeLog(string.Empty);
            writeLog("The most expensive combination is...");

            return _highestPrice(goodPriceTable, length,true);
        }
       
        
        private static int _highestPrice(List<Tuple<int, int>> priceTable, int length, bool log = false)
        {
            if (length == 0)
            {                
                return 0;
            }
            //test if length is in the table 
            var equalItem = priceTable.FirstOrDefault(x => x.Item1 == length);
            if (equalItem != null)
            {
                if (log)
                {
                    writeLog($"1 of length {equalItem.Item1} for {equalItem.Item2}");             
                }
                return equalItem.Item2;
            }

            //find the price that is the highest priced in the list per item (price/length) and that is shorter than the length
            var closestToItem = priceTable
                    .OrderByDescending(i => decimal.Parse(i.Item2.ToString()) / decimal.Parse(i.Item1.ToString()))
                    .ThenByDescending(i2 => i2.Item1)
                    .FirstOrDefault(x => x.Item1 < length);
            var moddity = length % closestToItem.Item1;
            var quotient = length / closestToItem.Item1;
            if (quotient > 0)
            {
                if (log)
                {
                    writeLog($"{quotient} of length {closestToItem.Item1}");
                }
            }
            return closestToItem.Item2 * quotient + _highestPrice(priceTable, moddity,log);
        }

        private static void writeLog(string text)
        {
            try
            {
                Console.WriteLine(text);
            }
            catch { }
        }

        

    }
}
