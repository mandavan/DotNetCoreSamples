using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConsole
{
    internal class LINQ
    {
        public void MethodSyntax()
        {
            List<string> fruits =
    new List<string> { "apple", "passionfruit", "banana", "mango",
                    "orange", "blueberry", "grape", "strawberry" };

            IEnumerable<string> query = fruits.Where(fruit => fruit.Length < 6);

            foreach (string fruit in query)
            {
                Console.WriteLine(fruit);
            }

            foreach(var fruit in fruits.Where(f => f.Length > 6).Select(f => new { Length = f.Length, Xyz = 'A' }).ToList())
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
