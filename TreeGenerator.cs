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

        int maxGeneration = 3;

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


        readonly int chanceChildIsAdopted = 15;


        public TreeGenerator(int? seed)
        {
            random = seed.HasValue ? new Random(seed.Value) : new Random();

            GenerateTree();
        }

        public void GenerateTree()
        {
            startPerson = GenerateStartPerson();

            Statistics.PrintStatistics(startPerson, maxGeneration);
        }

        public Person GenerateStartPerson()
        {
            Person mainPerson = Person.GenerateRandomPerson();
            mainPerson.Generation = 0;

            int familySituation = random.Next(100 - chanceSingleWithoutChild - chancePartnerWithoutChild); // startPerson should always have children

            if (familySituation <= chancePartnerWithChild)
            {
                GeneratePartnerWithChild(mainPerson, false);
            }
            else if (familySituation <= chancePartnerWithChild + chanceSingleAdopted)
            {
                GenerateChildren(mainPerson, null, true);
            }
            else if (familySituation <= chancePartnerWithChild + chanceSingleAdopted + chancePartnerWithoutChild)
            {
                GeneratePartner(mainPerson, false);
            }
            else if (familySituation <= chancePartnerWithChild + chancePartnerWithoutChild + chanceSingleAdopted + chanceSingleWithoutChild)
            {

            }

            return mainPerson;
        }

        public Person GeneratePersonWithRelationships(Sex sex, int generation, int startAge, int maxAge)
        {
            Person mainPerson = Person.GenerateRandomPerson();
            mainPerson.Generation = generation;

            bool lastGeneration = mainPerson.Generation == maxGeneration;

            int chanceNoChild = 100 - chancePartnerWithChild - chanceSingleAdopted;
            int familySituation = random.Next(lastGeneration ? chanceNoChild : 100);

            if (familySituation <= chancePartnerWithoutChild)
            {
                GeneratePartner(mainPerson, false);
            }
            else if (familySituation <= chancePartnerWithoutChild + chanceSingleWithoutChild)
            {
                return mainPerson;
            }
            else if (familySituation <= chancePartnerWithoutChild + chanceSingleWithoutChild + chancePartnerWithChild)
            {
                GeneratePartnerWithChild(mainPerson, false);
            }
            else if (familySituation <= chancePartnerWithoutChild + chanceSingleWithoutChild + chancePartnerWithChild + chanceSingleAdopted)
            {
                GenerateChildren(mainPerson, null, true);
            }

            return mainPerson;
        }

        private void GeneratePartnerWithChild(Person mainPerson, bool remarried)
        {
            GeneratePartner(mainPerson, remarried);
            GenerateChildren(mainPerson, mainPerson.Partners.Last(), mainPerson.PSex == mainPerson.Partners.Last().PSex);
        }

        /// <summary>
        /// Generate the partner of the person
        /// </summary>
        /// <param name="mainPerson">the person for which the partner will be generated</param>
        /// <param name="remarries">is it the second partner for the person</param>
        private void GeneratePartner(Person mainPerson, bool remarries)
        {
            int partnerSituation = random.Next(100);

            Person partner = Person.GenerateRandomPerson(partnerSituation <= chancePartnerSameSex ? mainPerson.PSex : EnumExtension.ToggleEnumValue<Sex>(mainPerson.PSex), 14);
            partner.Generation = mainPerson.Generation;

            mainPerson.Partners.Add(partner);
            partner.Partners.Add(mainPerson);

            if (!remarries)
            {
                GenerateRemarry(mainPerson);
            }
        }

        /// <summary>
        /// Generate the children of a person
        /// </summary>
        /// <param name="mainPerson">the person who the children belong to</param>
        /// <param name="partner">the potential second parent of the children. can be null and therefore only one parent possible</param>
        /// <param name="isGaruanteedAdopted">generated children will be garuenteed to be adopted. Happens when same sex parents or single parents</param>
        private void GenerateChildren(Person mainPerson, Person partner, bool isGaruanteedAdopted)
        {
            int childSituation = random.Next(100);

            List<int> childrenPossibilites = new List<int> { chanceOneChild, chanceTwoChild, chanceThreeChild, chanceFourChild };

            int possiblityIndex = 0;
            int currentChance = 0;

            foreach (var item in childrenPossibilites)
            {
                int isAdoptedChance = random.Next(100);

                Person child = GeneratePersonWithRelationships((Sex)random.Next(0, 2), mainPerson.Generation + 1, 0, Math.Max(1, mainPerson.Age - 14));

                if (isGaruanteedAdopted || isAdoptedChance <= chanceChildIsAdopted)
                {
                    child.IsAdopted = true;
                }

                child.Parents.Add(mainPerson);

                mainPerson.Children.Add(child);

                if (partner != null)
                {
                    partner.Children.Add(child);
                    child.Parents.Add(partner);
                }

                currentChance += item;

                if (childSituation <= currentChance)
                    break;
            }

            foreach (var child in mainPerson.Children)
            {
                child.Siblings = mainPerson.Children.Where(x => x != child).ToList();
            }

        }

        /// <summary>
        /// Decides if the person remarries and if so with or without child
        /// </summary>
        /// <param name="mainPerson">the person who potentially remarries</param>
        private void GenerateRemarry(Person mainPerson)
        {
            int remarrySituation = random.Next(100);

            bool lastGeneration = mainPerson.Generation == maxGeneration;

            if (remarrySituation <= chanceRemarriedWithoutChild)
            {
                GeneratePartner(mainPerson, true);
            }
            else if(!lastGeneration && remarrySituation <= chanceRemarriedWithoutChild + chanceRemarriedWithChild)
            {
                GeneratePartnerWithChild(mainPerson, true);
            }
        }
    }
}
