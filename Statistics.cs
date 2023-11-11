using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTreeGenerator
{
    public class Statistics
    {
        public static void PrintStatistics(Person person, int generations)
        {
            List<Person> personList = Person.GenerateListOfRelationships(person, new List<Person> { person }).OrderBy(x => x.Generation).ToList();

            Console.WriteLine($"Statistics: Total Count: {personList.Count}");

            for (int i = 0; i <= generations; i++)
            {
                Console.WriteLine($"\t\t\tGen {i}: {personList.Where(x => x.Generation == i).Count()}");
            }

            foreach (var item in personList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
