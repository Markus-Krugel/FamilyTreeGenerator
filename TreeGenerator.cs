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

        GenerationRules ruleset;

        public TreeGenerator(int? seed, GenerationRules rules)
        {
            random = seed.HasValue ? new Random(seed.Value) : new Random();

            ruleset = rules;

            GenerateTree();
        }

        public void GenerateTree()
        {
            startPerson = GenerateStartPerson();

            Statistics.PrintAllStatistics(startPerson, ruleset.MaxGeneration);
        }

        public Person GenerateStartPerson()
        {
            Person mainPerson = Person.GenerateRandomPerson();
            mainPerson.Generation = 0;

            int familySituation = random.Next(100 - ruleset.ChanceSingleWithoutChild - ruleset.ChancePartnerWithoutChild); // startPerson should always have children

            if (familySituation <= ruleset.ChancePartnerWithChild)
            {
                GeneratePartnerWithChild(mainPerson, false);
            }
            else if (familySituation <= ruleset.ChancePartnerWithChild + ruleset.ChanceSingleAdopted)
            {
                GenerateChildren(mainPerson, null, true);
            }
            else if (familySituation <= ruleset.ChancePartnerWithChild + ruleset.ChanceSingleAdopted + ruleset.ChancePartnerWithoutChild)
            {
                GeneratePartner(mainPerson, false);
            }
            else if (familySituation <= ruleset.ChancePartnerWithChild + ruleset.ChancePartnerWithoutChild + ruleset.ChanceSingleAdopted + ruleset.ChanceSingleWithoutChild)
            {

            }

            return mainPerson;
        }

        public Person GenerateRelationships(Person mainPerson)
        {
            bool lastGeneration = mainPerson.Generation == ruleset.MaxGeneration;

            int chanceNoChild = 100 - ruleset.ChancePartnerWithChild - ruleset.ChanceSingleAdopted;
            int familySituation = random.Next(lastGeneration ? chanceNoChild : 100);

            if (familySituation <= ruleset.ChancePartnerWithoutChild)
            {
                GeneratePartner(mainPerson, false);
            }
            else if (familySituation <= ruleset.ChancePartnerWithoutChild + ruleset.ChanceSingleWithoutChild)
            {
                return mainPerson;
            }
            else if (familySituation <= ruleset.ChancePartnerWithoutChild + ruleset.ChanceSingleWithoutChild + ruleset.ChancePartnerWithChild)
            {
                GeneratePartnerWithChild(mainPerson, false);
            }
            else if (familySituation <= ruleset.ChancePartnerWithoutChild + ruleset.ChanceSingleWithoutChild + ruleset.ChancePartnerWithChild + ruleset.ChanceSingleAdopted)
            {
                GenerateChildren(mainPerson, null, true);
                GenerateRemarry(mainPerson);
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

            Person partner = Person.GenerateRandomPerson(partnerSituation <= ruleset.ChancePartnerSameSex ? mainPerson.PSex : EnumExtension.ToggleEnumValue<Sex>(mainPerson.PSex), 14);
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

            List<int> childrenPossibilites = new List<int> { ruleset.ChanceOneChild, ruleset.ChanceTwoChild, ruleset.ChanceThreeChild, ruleset.ChanceFourChild };

            int possiblityIndex = 0;
            int currentchance = 0;

            foreach (var item in childrenPossibilites)
            {
                int isAdoptedchance = random.Next(100);
                int twinchance = random.Next(100);

                Person child;

                if (currentchance != 0 && twinchance <= ruleset.ChanceIsTwin)
                {
                    Person twin = mainPerson.Children.Last();
                    child = Person.GenerateRandomPerson(twin.PSex, twin.Age, twin.Age);
                    child.PHairStyle = twin.PHairStyle;
                    child.IsAdopted = twin.IsAdopted;

                    twin.IsTwin = true;
                    child.IsTwin = true;
                }
                else
                {
                    child = Person.GenerateRandomPerson((Sex)random.Next(0, 2), 0, Math.Max(1, mainPerson.Age - 14));

                    if (isGaruanteedAdopted || isAdoptedchance <= ruleset.ChanceChildIsAdopted)
                    {
                        child.IsAdopted = true;
                    }
                }

                child.Generation = mainPerson.Generation + 1;

                child = GenerateRelationships(child);

                child.Parents.Add(mainPerson);

                mainPerson.Children.Add(child);

                if (partner != null)
                {
                    partner.Children.Add(child);
                    child.Parents.Add(partner);
                }

                if (childSituation <= currentchance)
                    break;

                currentchance += item;
            }

            foreach (var child in mainPerson.Children)
            {
                child.Siblings = mainPerson.Children.Where(x => x != child).ToList();

                while(child.Siblings.Any(x=>x.Name == child.Name))
                {
                    child.SetGeneratedName();
                }

                if (child.Parents.Any(x => x.Name == child.Name))
                {
                    child.Name += " Jr";
                }
            }

        }

        /// <summary>
        /// Decides if the person remarries and if so with or without child
        /// </summary>
        /// <param name="mainPerson">the person who potentially remarries</param>
        private void GenerateRemarry(Person mainPerson)
        {
            int remarrySituation = random.Next(100);

            bool lastGeneration = mainPerson.Generation == ruleset.MaxGeneration;

            if (remarrySituation <= ruleset.ChanceRemarriedWithoutChild)
            {
                GeneratePartner(mainPerson, true);
            }
            else if(!lastGeneration && remarrySituation <= ruleset.ChanceRemarriedWithoutChild + ruleset.ChanceRemarriedWithChild)
            {
                GeneratePartnerWithChild(mainPerson, true);
            }
        }
    }
}
