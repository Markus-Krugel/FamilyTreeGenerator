using FamilyTreeGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTreeGenerator
{
    class TreeGenerator
    {
        Person startPerson;
        List<Person> allPersons = new List<Person>();

        Random random;

        // chances for the family situation of the person
        readonly int chancePartnerWithChild = 50;
        readonly int chancePartnerWithoutChild = 20;
        readonly int chanceSingleAdopted = 10;
        readonly int chanceSingleWithoutChild = 20;

        // chance that the partner is of the same sex
        readonly int chancePartnerSameSex = 10;

        // chances for remarrying
        readonly int chanceRemarriedWithChild = 5;
        readonly int chanceRemarriedWithoutChild = 5;

        // chances for the amount of children
        readonly int chanceOneChild = 30;
        readonly int chanceTwoChild = 50;
        readonly int chanceThreeChild = 15;
        readonly int chanceFourChild = 5;


        public TreeGenerator(int? seed)
        {
            random = seed.HasValue ? new Random(seed.Value) : new Random();

            for (int i = 0; i < 10; i++)
            {
                GenerateTree();
            }
        }

        public void GenerateTree()
        {
            startPerson = GeneratePersonWithRelationships();
        }

        public Person GeneratePersonWithRelationships()
        {
            Person mainPerson = Person.GenerateRandomPerson();

            GeneratePartnerWithChild(mainPerson, false);

            //int familySituation = random.Next(100);
            //
            //if (familySituation <= chancePartnerWithChild)
            //{
            //    GeneratePartnerWithChild(mainPerson, false);
            //}
            //else if (familySituation <= chancePartnerWithChild + chancePartnerWithoutChild)
            //{
            //
            //}
            //else if (familySituation <= chancePartnerWithChild + chancePartnerWithoutChild + chanceSingleAdopted)
            //{
            //
            //}
            //else if (familySituation <= chancePartnerWithChild + chancePartnerWithoutChild + chanceSingleAdopted + chanceSingleWithoutChild)
            //{
            //
            //}

            return mainPerson;
        }

        private void GeneratePartnerWithChild(Person mainPerson, bool remarried)
        {
            int partnerSituation = random.Next(100);
            int childSituation = random.Next(100);

            Person partner = Person.GenerateRandomPerson(partnerSituation <= chancePartnerSameSex ? mainPerson.PSex : EnumExtension.ToggleEnumValue<Sex>(mainPerson.PSex), 14);
            mainPerson.Partners.Add(partner);

            List<int> childrenPossibilites = new List<int> { chanceOneChild, chanceTwoChild, chanceThreeChild, chanceFourChild };

            int possiblityIndex = 0;
            int currentChance = 0;

            foreach (var item in childrenPossibilites)
            {
                Person child = Person.GenerateRandomPerson((Sex)random.Next(0,2), 0, Math.Max(1, mainPerson.Age - 14));
                child.Parents.Add(mainPerson);
                child.Parents.Add(partner);

                mainPerson.Children.Add(child);

                partner.Children.Add(child);

                currentChance += item;

                if (childSituation <= currentChance)
                    break;                    
            }

            foreach (var child in mainPerson.Children)
            {
                child.Siblings = mainPerson.Children.Where(x => x != child).ToList();
                Console.WriteLine(child);
                Console.WriteLine();
            }

            if (!remarried)
            {
                int remarrySituation = random.Next(100);

                if (remarrySituation <= chanceRemarriedWithChild)
                {
                    GeneratePartnerWithChild(mainPerson, true);
                }
                else if (remarrySituation <= chanceRemarriedWithChild + chanceRemarriedWithoutChild)
                {

                }
            }
        }
    }
}
