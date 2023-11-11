using FamilyTreeGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTreeGenerator
{
    public class Person
    {
        private static Random random = new Random();

        public static readonly string[] boysNames = new[] {"Noah",
"Ben",
"Finn",
"Leon",
"Elias",
"Emil",
"Theo",
"Luis",
"Henry",
"Liam",
"Luka",
"Jonas",
"Leo",
"Felix",
"Paul",
"Lukas",
"Jakob",
"Anton",
"Matteo",
"Maximilian",
"Oskar",
"Levi",
"Milan",
"Lio",
"David",
"Max",
"Jonah",
"Karl",
"Markus",
"Moritz",
"Linus",
"Alexander",
"Erik",
"Emilio",
"Milow",
"Raphael",
"Samuel",
"Jonathan",
"Mika",
"Julian",
"Adam",
"Malik",
"Carlo",
"Nico",
"Leonard",
"Tom",
"Aaron",
"Maxim",
"Theodor",
"Lian"};
        public static readonly string[] girlsNames = new[] { "Emilia",
"Elina",
     "Anna",
     "Emma",
     "Marie",
     "Sophia",
     "Sophie",
     "Charlotte",
     "Mia",
     "Amelia",
     "Mila",
     "Laura",
     "Leonie",
     "Hannah",
     "Lina",
     "Johanna",
     "Lena",
     "Alina",
     "Luisa",
     "Sarah",
     "Lotta",
     "Maria",
     "Ida",
     "Katharina",
     "Lea",
     "Malia",
     "Jana",
     "Amelie",
     "Josephine",
     "Mathilda",
     "Valentina",
     "Clara",
     "Luise",
     "Amy",
     "Melissa",
     "Juna",
     "Emily",
     "Julia",
     "Luna",
     "Elisa",
     "Melina",
     "Helena",
     "Lara",
     "Linda",
     "Nina",
     "Paula",
     "Lia",
     "Leni",
     "Hanna",
     "Mira"};

        public Person()
        {

        }

        // Person Data
        public string Name { get; set; }
        public int Age { get; set; }
        public Sex PSex { get; set; }
        public Hairstyle PHairStyle { get; set; }
        public Haircolor PHairColor { get; set; }
        public Job PJob { get; set; }
        public SkinColor PSkinColor { get; set; }
        public bool IsAdopted { get; set; }
        public bool IsAlive { get; set; }
        public int Generation { get; set; }

        // Relationships
        public List<Person> Parents { get; set; }
        public List<Person> Partners { get; set; }
        public List<Person> Children { get; set; }
        public List<Person> Siblings { get; set; }

        public static Person GenerateRandomPerson(int minAge = 0, int maxAge = 110)
        {

            Person result = new Person();
            result.PSex = (Sex)EnumExtension.RandomEnum(typeof(Sex));
            result.Name = result.PSex == Sex.Female ? girlsNames[random.Next(girlsNames.Length)]
                                                    : boysNames[random.Next(boysNames.Length)];
            result.Age = random.Next(minAge, maxAge);
            result.PHairStyle = (Hairstyle)EnumExtension.RandomEnum(typeof(Hairstyle));
            result.PHairColor = (Haircolor)EnumExtension.RandomEnum(typeof(Haircolor));
            result.PJob = result.Age >= 16 ? (Job)EnumExtension.RandomEnum(typeof(Job)) : Job.Jobless;

            result.Parents = new List<Person>();
            result.Partners = new List<Person>();
            result.Children = new List<Person>();
            result.Siblings = new List<Person>();

            return result;
        }

        public static Person GenerateRandomPerson(Sex sex, int minAge = 0, int maxAge = 110)
        {
            Person result = Person.GenerateRandomPerson(minAge, maxAge);
            result.PSex = (Sex)EnumExtension.RandomEnum(typeof(Sex));
            result.Name = result.PSex == Sex.Female ? girlsNames[random.Next(girlsNames.Length)]
                                                    : boysNames[random.Next(boysNames.Length)];

            return result;
        }

        public static List<Person> GenerateListOfRelationships(Person startPerson, List<Person> result)
        {
            foreach (Person person in startPerson.Partners)
            {
                if(!result.Contains(person))
                {
                    result.Add(person);
                    result = GenerateListOfRelationships(person, result);
                }
            }

            foreach (Person person in startPerson.Children)
            {
                if (!result.Contains(person))
                {
                    result.Add(person);
                    result = GenerateListOfRelationships(person, result);
                }
            }

            return result;
        }


        public override string ToString()
        {
            return $@"{Name} ({Age} {PSex}[{Generation}], {PJob}, {PHairColor} {PHairStyle} Hair)
                      Parents: {string.Join(",\n\t\t\t\t\t\t\t\t", Parents.Select(p => p.ToStringShort()))}
                      Partners: {string.Join(",\n\t\t\t\t\t\t\t\t", Partners.Select(p => p.ToStringShort()))}
                      Siblings: {string.Join(",\n\t\t\t\t\t\t\t\t", Siblings.Select(p => p.ToStringShort()))}
                      Children: {string.Join(",\n\t\t\t\t\t\t\t\t", Children.Select(p => p.ToStringShort()))}";
        }

        public string ToStringShort()
        {
            return $@"{Name} ({Age} {PSex}, {PJob}, {PHairColor} {PHairStyle} Hair)";
        }
    }
}
