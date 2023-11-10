using Stammbaumgenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTreeGenerator
{
    public enum Sex { Male, Female }
    public enum Hairstyle { Long, Short, Curly, Ponytail, Afro }
    public enum Haircolor { Red, Blond, Black, Brown, Blue, Pink }
    public enum Job { Cook, Astronaut, Doctor, Engineer, Attorney, Farmer }

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

        public string Name { get; set; }
        public int Age { get; set; }
        public Sex PSex { get; set; }
        public Hairstyle PHairStyle { get; set; }
        public Haircolor PHairColor { get; set; }
        public Job PJob { get; set; }

        public static Person GenerateRandomPerson()
        {

            Person result = new Person();
            result.PSex = (Sex)EnumExtension.RandomEnum(typeof(Sex));
            result.Name = result.PSex == Sex.Female ? girlsNames[random.Next(girlsNames.Length)]
                                                    : boysNames[random.Next(boysNames.Length)];
            result.Age = random.Next(0, 110);
            result.PHairStyle = (Hairstyle)EnumExtension.RandomEnum(typeof(Hairstyle));
            result.PHairColor = (Haircolor)EnumExtension.RandomEnum(typeof(Haircolor));
            result.PJob = (Job)EnumExtension.RandomEnum(typeof(Job));

            return result;
        }

        public override string ToString()
        {
            return $@"{Name} ({Age} {PSex}, {PJob}, {PHairColor} {PHairStyle} Hair)";
        }
    }
}
