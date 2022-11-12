using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_Ch
{
    public class Inputs 
    {
        static public int inputInt(string message)
        {
            int ans = 0;
            while (true)
            {
                try
                {
                    Console.WriteLine(message);
                    ans = Convert.ToInt32(Console.ReadLine());
                    if (ans >= 0) return ans;
                    else throw new Exception("Less than 0 value");
                }
                catch
                {
                    Console.WriteLine("\nYou tap on wrong buttons, boy!\n");
                }
            }

            
        }
        static public string inputString(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        static public TimeFrame inputFrame()
        {
            while (true)
            {
                Console.WriteLine("Input TimeFrame:\n");
                string tmp = Console.ReadLine();
                try
                {
                    TimeFrame ans = (TimeFrame)Enum.Parse(typeof(TimeFrame), tmp, true);
                    return ans;
                }
                catch
                {
                    Console.WriteLine("\nInvalid argument!\n");
                }
            }
        }
        static public DateTime inputDateTime(string message)
        {
            int year = inputInt("Input year:\t");
            int month = 13;
            while (month > 12) { month = inputInt("Input month:\t"); }
            int day = 32;
            while (day > 31) { day = inputInt("Input day:\t"); }
            return new DateTime(year, month, day);
        }


        static public Person inputPerson()
        {
            string name = inputString("Input name:\n");
            string surename = inputString("Input surename:\n");
            DateTime birth = inputDateTime("input birthday:\n");
            Console.Clear();
            return new Person(name, surename, birth);
        }
        static public Person inputPerson(string message)
        {
            Console.WriteLine(message);
            string name = inputString("Input name:\n");
            string surename = inputString("Input surename:\n");
            DateTime birth = inputDateTime("input birthday:\n");
            Console.Clear();
            return new Person(name, surename, birth);
        }

        static public Paper inputPaper()
        {
            string title = inputString("Input title:\t");
            Person author = inputPerson("Input author:");
            DateTime date = inputDateTime("Input date of publication:\n");
            Console.Clear();
            return new Paper(title, author, date);
        }
        static public Paper inputPaper(Person person)
        {
            string title = inputString("Input title:\t");
            DateTime date = inputDateTime("Input date of publication:\n");
            Console.Clear();
            return new Paper(title, person, date);
        }

        static public ResearchTeam inputRT()
        {
            string theme = inputString("Input theme:\t");
            string name = inputString("Input name of team:\t");
            TimeFrame timeFrame = inputFrame();
            List<Paper> papers = new List<Paper>();
            List<Person> persons = new List<Person>();
            int count = inputInt("Input number of persons:\t");
            for (int i = 0; i < count; i++)
            {
                Person person = inputPerson();
                persons.Add(person);
            }
            for (int i = 0; i < count; i++)
            {
                Paper paper = inputPaper(persons[i]);
                papers.Add(paper);
            }
            ResearchTeam ans = new ResearchTeam(theme, name, timeFrame);
            ans.AddPersons(persons);
            ans.AddPapers(papers);
            Console.Clear();
            return ans;
        }
    }
}
