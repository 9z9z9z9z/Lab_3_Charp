using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Lab_4_Ch
{
    public delegate KeyValuePair<TKey, TValue> GenerateElement<TKey, TValue>(int j);
    public delegate TKey KeySelector<TKey>(ResearchTeam rt);

    public class Program
    {
        static public KeyValuePair<int, string> generator(int i)
        {
            string value = (i * i * i * i * i * i * i).ToString();
            int key = i;
            return new KeyValuePair<int, string>(key, value);
        }
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;

            KeySelector<string> keySelector = delegate (ResearchTeam rt)
            {
                return rt.GetHashCode().ToString();
            };

            ResearchTeam rt = new ResearchTeam();
            Paper paper1 = new Paper("Try C++", new Person(), new DateTime(2003, 8, 8));
            Paper paper2 = new Paper("Zry C++", new Person("Emil", "Markov", new DateTime(2003, 8, 10)), new DateTime(2003, 8, 10));
            Paper paper3 = new Paper("Ary C++", new Person("Dmitry", "Panfiov", new DateTime(2003, 8, 12)), new DateTime(2003, 8, 12));
            rt.addPapers(paper1, paper2, paper3);

            ResearchTeamCollection<string> researchTeamCollection = new ResearchTeamCollection<string>(keySelector);
            researchTeamCollection.AddDefaults(3);

            TestCollections<int, string> testCollections = new TestCollections<int, string>(100000, generator);

            Console.WriteLine("\n====================================\nTask\t№1.\n====================================\n");
            rt.sortByAuthor();
            Console.WriteLine(rt);
            rt.sortByData();
            Console.WriteLine(rt);
            rt.sortByTitle();
            Console.WriteLine(rt);

            Console.WriteLine("\n====================================\nTask\t№2.\n====================================\n");

            Console.WriteLine(researchTeamCollection.MaxDateTimeElement.ToShortDateString());
            foreach (var item in researchTeamCollection.TimeFrameGroup(TimeFrame.Long))
            {
                Console.WriteLine(item.ToString());
            }
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var item in researchTeamCollection.grouping)
            {
                Console.WriteLine(item.Key);
                foreach (var part in item)
                {
                    Console.WriteLine(part.ToString());
                }
            }

            Console.WriteLine("\n====================================\nTask\t№3.\n====================================\n");
            testCollections.searchInKeyList();
            testCollections.searchInValueList();
            testCollections.searchInStrDict();
            testCollections.searchInKeyDict();

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
