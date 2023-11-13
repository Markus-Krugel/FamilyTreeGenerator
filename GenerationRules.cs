using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTreeGenerator
{
    public class GenerationRules
    {

        public int MaxGeneration { get; protected set; }

        // chances for the family situation of the person
        public int ChancePartnerWithChild { get; protected set; }
        public int ChancePartnerWithoutChild { get; protected set; }
        public int ChanceSingleAdopted { get; protected set; }
        public int ChanceSingleWithoutChild { get; protected set; }

        // chance that the partner is of the same sex
        public int ChancePartnerSameSex { get; protected set; }

        // chances for remarrying
        public int ChanceRemarriedWithChild { get; protected set; }
        public int ChanceRemarriedWithoutChild { get; protected set; }

        // chances for the amount of children
        public int ChanceOneChild { get; protected set; }
        public int ChanceTwoChild { get; protected set; }
        public int ChanceThreeChild { get; protected set; }
        public int ChanceFourChild { get; protected set; }


        public int ChanceIsTwin { get; protected set; }
        public int ChanceChildIsAdopted { get; protected set; }

        public static GenerationRules GetNormalRulesset()
        {
            return new GenerationRules()
            {
                MaxGeneration = 3,

                ChancePartnerWithChild = 40,
                ChancePartnerWithoutChild = 25,
                ChanceSingleAdopted = 15,
                ChanceSingleWithoutChild = 20,

                ChancePartnerSameSex = 10,

                ChanceRemarriedWithChild = 5,
                ChanceRemarriedWithoutChild = 5,

                ChanceOneChild = 40,
                ChanceTwoChild = 45,
                ChanceThreeChild = 10,
                ChanceFourChild = 5,

                ChanceIsTwin = 5,
                ChanceChildIsAdopted = 15
            };
        }

        public static GenerationRules GetMultiGenerationSmallFamilyRulesset()
        {
            return new GenerationRules()
            {
                MaxGeneration = 5,

                ChancePartnerWithChild = 40,
                ChancePartnerWithoutChild = 20,
                ChanceSingleAdopted = 20,
                ChanceSingleWithoutChild = 20,

                ChancePartnerSameSex = 25,

                ChanceRemarriedWithChild = 5,
                ChanceRemarriedWithoutChild = 5,

                ChanceOneChild = 60,
                ChanceTwoChild = 30,
                ChanceThreeChild = 5,
                ChanceFourChild = 5,

                ChanceIsTwin = 10,
                ChanceChildIsAdopted = 10
            };
        }
    }
}
