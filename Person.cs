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

        public static readonly string[] boysNames = new[] {"Aaron",
"Adam",
"Adrian",
"Aiden",
"Albert ",
"Alexander",
"Alfred ",
"Andrew",
"Anthony",
"Anton",
"August",
"Axel",
"Ben",
"Benedikt",
"Benjamin",
"Bernd",
"Bruno",
"Caleb",
"Cameron",
"Carl",
"Carlo",
"Carsten",
"Carter",
"Charles",
"Christian",
"Christoph",
"Christopher",
"Clemens",
"Colton",
"Daniel",
"David",
"Dennis",
"Dominik",
"Dylan",
"Elias",
"Elijah",
"Emilio",
"Erik",
"Ethan",
"Eugen ",
"Fabian",
"Falk",
"Felix",
"Finn",
"Florian",
"Franz",
"Frederick",
"Fritz",
"Gabriel",
"Georg ",
"Gregor",
"Greyson",
"Hannes",
"Hans",
"Hauke",
"Heinz",
"Henry",
"Hugo",
"Ian",
"Isaac",
"Jack",
"Jackson",
"Jacob",
"Jakob",
"James",
"Jan",
"Jannik",
"Jannis",
"Janosch",
"Jasper",
"Jayden",
"Jeremiah",
"Jim",
"Joachim",
"Jochen",
"Johann",
"Johannes",
"John",
"Jonah",
"Jonas",
"Jonathan",
"Jordan",
"Jose",
"Joseph",
"Joshua",
"Julian",
"Julius",
"Justus",
"Kai",
"Karl",
"Kilian",
"Klaus",
"Konrad",
"Konstantin",
"Lennart",
"Jasper",
"Jonathan",
"Julian",
"Leo",
"Leon",
"Leonard",
"Leonardo",
"Levi",
"Liam",
"Lincoln",
"Linus",
"Lio",
"Logan",
"Lorenz",
"Lucas",
"Ludwig",
"Luis",
"Luka",
"Lukas",
"Luke",
"Magnus",
"Malte",
"Manuel",
"Mario",
"Marius",
"Mark",
"Markus",
"Marvin",
"Mason",
"Mateo",
"Mattes",
"Matthew",
"Matthias",
"Mattis",
"Maverick",
"Max",
"Maxim",
"Maximilian",
"Merten",
"Michael",
"Milan",
"Miles",
"Milow",
"Moe",
"Moritz",
"Nathan",
"Nicholas",
"Nico",
"Niklas",
"Nikolas",
"Noah",
"Olaf",
"Oliver",
"Oskar",
"Parker",
"Patrick",
"Paul",
"Peter",
"Phillip",
"Raphael",
"Richard",
"Robert",
"Roger",
"Roman",
"Rowan",
"Ryan",
"Samuel",
"Santiago",
"Sebastian",
"Siegfried",
"Simon",
"Stefan",
"Theo",
"Theodor",
"Thomas",
"Thorsten",
"Till",
"Tilo",
"Tim",
"Timo",
"Timotheus",
"Tobias",
"Tom",
"Toni",
"Udo",
"Valentin",
"Vincent",
"Waldemar",
"Wesley",
"Weston",
"William",
"Xavier"
 };
        public static readonly string[] girlsNames = new[] { "Abigail",
"Addison",
"Adeline",
"Alexandra",
"Alexis",
"Alice",
"Alina",
"Allison",
"Alyssa",
"Amelie",
"Amy",
"Anastasia",
"Andrea",
"Angelina",
"Anna",
"Annie",
"Antonia",
"Aria",
"Ariana",
"Arianna",
"Ariella",
"Ashley",
"Athena",
"Audrey",
"Aurelia",
"Aurora",
"Autumn",
"Ava",
"Avery",
"Ayla",
"Bailey",
"Bella",
"Brooklyn",
"Camila",
"Carla",
"Caroline",
"Cassidy",
"Charlotte",
"Chloe",
"Claire",
"Clara",
"Daisy",
"Delilah",
"Elena",
"Eliana",
"Elina",
"Elisa",
"Eliza",
"Elizabeth",
"Ellie",
"Ember",
"Emilia",
"Emily",
"Emma",
"Esther",
"Eva",
"Evelyn",
"Everly",
"Fiona",
"Freya",
"Frieda",
"Gabriella",
"Georgia",
"Gianna",
"Grace",
"Hailey",
"Hanna",
"Hannah",
"Harper",
"Helena",
"Ida",
"Iris",
"Isabel",
"Isabella",
"Jade",
"Jana",
"Jasmin",
"Jasmine",
"Johanna",
"Josephine",
"Julia",
"Juliette",
"Juna",
"Katharina",
"Katherine",
"Kaylee",
"Kiara",
"Kinsley",
"Kylie",
"Lara",
"Laura",
"Layla",
"Lea",
"Leila",
"Lena",
"Leonie",
"Lia",
"Liana",
"Liliana",
"Lily",
"Lina",
"Linda",
"Livia",
"Louisa",
"Lucia",
"Lucie",
"Lucy",
"Luisa",
"Luna",
"Lydia",
"Lyla",
"Mackenzie",
"Madeline",
"Madelyn",
"Madison",
"Malina",
"Mara",
"Margaret",
"Maria",
"Marie",
"Marla",
"Mary",
"Mathilda",
"Maya",
"Melanie",
"Melina",
"Melissa",
"Melody",
"Mia",
"Mila",
"Mina",
"Mira",
"Molly",
"Naomi",
"Natalia",
"Nathalie",
"Nina",
"Nora",
"Olivia",
"Paula",
"Paulina",
"Pauline",
"Penelope",
"Riley",
"Rosalie",
"Rose",
"Ruby",
"Samantha",
"Sara",
"Sarah",
"Scarlett",
"Skylar",
"Sofia",
"Sophia",
"Sophie",
"Stella",
"Taylor",
"Tilda",
"Valentina",
"Victoria",
"Violet",
"Vivian",
"Willow",
"Zoey"    };

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
        public bool IsTwin { get; set; }
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
            result.SetGeneratedName();
            result.Age = random.Next(minAge, maxAge);
            result.PHairStyle = (Hairstyle)EnumExtension.RandomEnum(typeof(Hairstyle));
            result.PHairColor = (Haircolor)EnumExtension.RandomEnum(typeof(Haircolor));
            result.PJob = result.Age >= 16 ? (Job)EnumExtension.RandomEnum(typeof(Job)) : Job.Unemployed;

            result.Parents = new List<Person>();
            result.Partners = new List<Person>();
            result.Children = new List<Person>();
            result.Siblings = new List<Person>();

            return result;
        }

        public static Person GenerateRandomPerson(Sex sex, int minAge = 0, int maxAge = 110)
        {
            Person result = Person.GenerateRandomPerson(minAge, maxAge);
            result.PSex = sex;
            result.Name = result.PSex == Sex.Female ? girlsNames[random.Next(girlsNames.Length)]
                                                    : boysNames[random.Next(boysNames.Length)];

            return result;
        }

        public static List<Person> GenerateListOfRelationships(Person startPerson, List<Person> result)
        {
            foreach (Person person in startPerson.Parents)
            {
                if (!result.Contains(person))
                {
                    result.Add(person);
                    result = GenerateListOfRelationships(person, result);
                }
            }

            foreach (Person person in startPerson.Partners)
            {
                if (!result.Contains(person))
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

        public void SetGeneratedName()
        {
            Name = PSex == Sex.Female ? girlsNames[random.Next(girlsNames.Length)]
                                        : boysNames[random.Next(boysNames.Length)];
        }


        public override string ToString()
        {
            string alive = IsAlive ? "[A]" : "[D]";
            string twin = IsTwin ? "[Twin]" : "";
            string adopted = IsAdopted ? "[Adopted]" : "";

            return $@"{Name} ({Age} {PSex}[{Generation}], {PJob}, {alive}{twin}{adopted} {PHairColor} {PHairStyle} Hair)
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
