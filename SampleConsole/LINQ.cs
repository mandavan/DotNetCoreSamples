using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConsole
{
    internal class LINQ
    {
        public void QuerySyntax()
        {
            string[] groupingQuery = { "carrots", "cabbage", "broccoli", "beans", "barley" };
            IEnumerable<IGrouping<char, string>> queryFoodGroups =
                from item in groupingQuery
                group item by item[0];
        }

        public void MethodSyntax()
        {

            List<string> fruits =
    new List<string> { "apple", "passionfruit", "banana", "mango",
                    "orange", "blueberry", "grape", "strawberry" };

            IEnumerable<string> query = fruits.Where(fruit => fruit.Length < 6).Select(f => f);
            fruits.First(f => f.Length > 6);
            fruits.Sort();
            foreach (string fruit in query)
            {
                Console.WriteLine(fruit);
            }

            foreach(var fruit in fruits.Where(f => f.Length > 6).Select(f => new { Length = f.Length, Xyz = 'A' }))
            {
                Console.WriteLine(fruit);
            }
            /*
             This code produces the following output:

             apple
             mango
             grape
            */
        }

        public IEnumerable<int> GetSingleDigitNumbers()
        {
            yield return 0;
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
            yield return 5;
            yield return 6;
            yield return 7;
            yield return 8;
            yield return 9;
        }
    }
}
