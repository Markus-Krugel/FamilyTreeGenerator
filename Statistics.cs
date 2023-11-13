using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTreeGenerator
{
    public class Statistics
    {
        public static void PrintAllStatistics(Person person, int generations)
        {
            List<Person> personList = Person.GenerateListOfRelationships(person, new List<Person> { person }).OrderBy(x => x.Generation).ToList();

            Console.WriteLine($"Statistics: Total Count: {personList.Count}");

            PrintGenerationsStatistics(person, generations);

            Console.WriteLine("---------------------------------------------");

            PrintFamilyStatistics(person);

            Console.WriteLine("---------------------------------------------");

            PrintPersonStatistics(person);

            Console.WriteLine("---------------------------------------------");

            //PrintAllPersons(person);
        }

        public static void PrintGenerationsStatistics(Person person, int generations)
        {
            List<Person> personList = Person.GenerateListOfRelationships(person, new List<Person> { person }).OrderBy(x => x.Generation).ToList();

            for (int i = 0; i <= generations; i++)
            {
                Console.WriteLine($"\t\t\tGen {i}: {personList.Where(x => x.Generation == i).Count()}");
            }
        }

        public static void PrintFamilyStatistics(Person person)
        {
            List<Person> personList = Person.GenerateListOfRelationships(person, new List<Person> { person }).OrderBy(x => x.Generation).ToList();

            int totalCount = personList.Count();

            int singleCount = personList.Where(x => !x.Partners.Any() && !x.Children.Any()).Count();
            int singlePercentage = GetPercentage(totalCount, singleCount);

            int singleAdoptedCount = personList.Where(x => !x.Partners.Any() && x.Children.Any()).Count();
            int singleAdoptedPercentage = GetPercentage(totalCount, singleAdoptedCount);

            int marriedChildCount = personList.Where(x => x.Partners.Count() == 1 && x.Children.Any()).Count();
            int marriedChildPercentage = GetPercentage(totalCount, marriedChildCount);

            int marriedWithoutChildCount = personList.Where(x => x.Partners.Any() && !x.Children.Any()).Count();
            int marriedWithoutChildPercentage = GetPercentage(totalCount, marriedWithoutChildCount);

            int remarriedCount = personList.Where(x => x.Partners.Count() > 1).Count();
            int remarriedPercentage = GetPercentage(totalCount, remarriedCount);

            Console.WriteLine($@"Single: {singleCount} ({singlePercentage}%)
Single Adopted: {singleAdoptedCount} ({singleAdoptedPercentage}%)
Married with Child: {marriedChildCount} ({marriedChildPercentage}%)
Married without Child: {marriedWithoutChildCount} ({marriedWithoutChildPercentage}%)
Remarried {remarriedCount} ({remarriedPercentage}%)");
        }
        
        public static void PrintPersonStatistics(Person person)
        {
            List<Person> personList = Person.GenerateListOfRelationships(person, new List<Person> { person }).OrderBy(x => x.Generation).ToList();

            int totalCount = personList.Count();

            int maleCount = personList.Where(x => x.PSex == Sex.Male).Count();
            int malePercentage = GetPercentage(totalCount, maleCount);

            int femaleCount = personList.Where(x => x.PSex == Sex.Female).Count();
            int femalePercentage = GetPercentage(totalCount, femaleCount);

            int adoptedCount = personList.Where(x => x.IsAdopted).Count();
            int adoptedPercentage = GetPercentage(totalCount, adoptedCount);

            int aliveCount = personList.Where(x => x.IsAlive).Count();
            int alivePercentage = GetPercentage(totalCount, aliveCount);

            int deadCount = personList.Where(x => !x.IsAlive).Count();
            int deadPercentage = GetPercentage(totalCount, deadCount);

            int twinCount = personList.Where(x => x.IsTwin).Count();
            int twinPercentage = GetPercentage(totalCount, twinCount);

            Console.WriteLine($@"Male/Female {maleCount}/{femaleCount} ({malePercentage}/{femalePercentage}%)
Adopted {adoptedCount} ({adoptedPercentage}%)
Alive/Dead {aliveCount}/{deadCount} ({alivePercentage}/{deadPercentage}%)
Twin {twinCount} ({twinPercentage}%)");
        }

        public static void PrintAllPersons(Person person)
        {
            List<Person> personList = Person.GenerateListOfRelationships(person, new List<Person> { person }).OrderBy(x => x.Generation).ToList();

            foreach (var item in personList)
            {
                Console.WriteLine(item);
            }
        }

        private static int GetPercentage(int totalCount, int count)
        {
            return totalCount != 0 ? (int)((double)count / totalCount * 100) : 0;
        }
    }
}
